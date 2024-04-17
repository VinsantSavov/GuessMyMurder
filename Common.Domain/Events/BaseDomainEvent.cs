namespace Common.Domain.Events
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        protected BaseDomainEvent()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; }
    }
}
