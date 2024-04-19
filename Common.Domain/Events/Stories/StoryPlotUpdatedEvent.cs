namespace Common.Domain.Events.Stories
{
    public class StoryPlotUpdatedEvent : IDomainEvent
    {
        public StoryPlotUpdatedEvent(
            Guid id,
            string plot)
        {
            this.Id = id;
            this.Plot = plot;
        }

        public Guid Id { get; }

        public string Plot { get; }
    }
}
