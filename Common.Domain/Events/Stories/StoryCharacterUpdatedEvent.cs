namespace Common.Domain.Events.Stories
{
    public class StoryCharacterUpdatedEvent : BaseDomainEvent
    {
        public StoryCharacterUpdatedEvent(
            Guid id,
            int characterId,
            string firstName,
            string lastName,
            string? spotlight)
        {
            this.Id = id;
            this.CharacterId = characterId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Spotlight = spotlight;
        }

        public Guid Id { get; }

        public int CharacterId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string? Spotlight { get; }
    }
}
