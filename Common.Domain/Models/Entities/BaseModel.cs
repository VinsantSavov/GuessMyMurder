using System.ComponentModel.DataAnnotations;

using Common.Domain.Events;

namespace Common.Domain.Models.Entities
{
    public abstract class BaseModel<TKey> : IDatabaseModel, IAuditInfo
    {
        private ICollection<IDomainEvent> _events;

        protected BaseModel()
        {
            this._events = new List<IDomainEvent>();
        }

        [Key]
        public TKey Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        public IReadOnlyCollection<IDomainEvent> Events
            => this._events.ToList().AsReadOnly();

        public void ClearEvents() => this._events.Clear();

        protected void RaiseEvent(IDomainEvent domainEvent)
            => this._events.Add(domainEvent);
    }
}
