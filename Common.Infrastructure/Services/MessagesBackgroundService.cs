using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Common.Domain.Events;
using Common.Infrastructure.Events;
using Common.Infrastructure.Persistence;

namespace Common.Infrastructure.Services
{
    internal class MessagesBackgroundService : BackgroundService
    {
        private readonly MessagesDbContext _dbContext;
        private readonly IEventPublisher _eventPublisher;

        public MessagesBackgroundService(
            MessagesDbContext dbContext,
            IEventPublisher eventPublisher)
        {
            this._dbContext = dbContext;
            this._eventPublisher = eventPublisher;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await this.ProcessPendingMessagesAsync(cancellationToken);
        }

        private async Task ProcessPendingMessagesAsync(CancellationToken cancellationToken)
        {
            var messages = await this._dbContext
                .Messages
                .Where(m => !m.Published)
                .ToListAsync(cancellationToken);

            foreach (var message in messages)
            {
                var domainEvent = message.Data as IDomainEvent;

                if (domainEvent is null)
                {
                    continue;
                }

                await this._eventPublisher.PublishAsync(domainEvent);

                message.MarkAsPublished();
            }

            await this._dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
