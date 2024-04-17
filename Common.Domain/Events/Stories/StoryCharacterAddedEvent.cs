namespace Common.Domain.Events.Stories
{
    public class StoryCharacterAddedEvent : BaseDomainEvent
    {
        public StoryCharacterAddedEvent(
            Guid id,
            int characterId)
        {
            this.Id = id;
            this.CharacterId = characterId;
        }

        public Guid Id { get; }

        public int CharacterId {  get; }
    }
}
