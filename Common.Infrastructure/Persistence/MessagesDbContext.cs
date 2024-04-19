using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Common.Infrastructure.Events;
using Common.Domain.Models.Entities;
using Common.Infrastructure.Configurations;

namespace Common.Infrastructure.Persistence
{
    public abstract class MessagesDbContext : DbContext
    {
        private readonly IEventPublisher _eventPublisher;

        protected MessagesDbContext(
            DbContextOptions options,
            IEventPublisher eventPublisher)
            : base(options)
            => this._eventPublisher = eventPublisher;

        public DbSet<Message> Messages { get; set; }

        protected abstract Assembly ConfigurationsAssembly { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entities = this.ChangeTracker
                .Entries<IDatabaseModel>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var eventMessages = entity
                    .Events
                    .ToDictionary(
                        domainEvent => domainEvent,
                        domainEvent => new Message(domainEvent));

                entity.ClearEvents();

                foreach (var (domainEvent, message) in eventMessages)
                {
                    this.Add(message);

                    await this._eventPublisher.PublishAsync(domainEvent);

                    message.MarkAsPublished();

                    await base.SaveChangesAsync(cancellationToken);
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
