using Common.Domain.Events;

namespace Common.Domain.Models.Entities
{
    public interface IDatabaseModel
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}
