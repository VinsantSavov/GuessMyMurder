using Common.Domain.Events;

namespace Common.Infrastructure.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync(IDomainEvent domainEvent);
    }
}
