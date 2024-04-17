namespace Common.Domain.Events.Stories
{
    public class StoryCharacterRemovedEvent : BaseDomainEvent
    {
        public StoryCharacterRemovedEvent(
            Guid id,
            int characterId)
        {
            this.Id = id;
            this.CharacterId = characterId;
        }

        public Guid Id { get; }

        public int CharacterId { get; }
    }
}
