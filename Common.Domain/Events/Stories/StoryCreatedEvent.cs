namespace Common.Domain.Events.Stories
{
    public class StoryCreatedEvent : BaseDomainEvent
    {
        public StoryCreatedEvent(
            Guid id,
            string title,
            string plot)
        {
            this.Id = id;
            this.Title = title;
            this.Plot = plot;
        }

        public Guid Id { get; }

        public string Title { get; }

        public string Plot { get; }
    }
}
