using Games.Domain.Models.Votes;
using Games.Domain.Models.Players;
using Common.Domain.Models.Entities;

namespace Games.Domain.Models.Games
{
    public class Game : BaseModel<Guid>, IDeletableEntity
    {
        public Guid CreatorId { get; private set; }

        public Guid StoryId { get; private set; }

        public int GuiltyCharacterId {  get; private set; }

        public GameType Type { get; private set; }

        public int GameEndingTimeInMinutes {  get; private set; }

        public int PlayersCount {  get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime? DeletedOn { get; private set; }

        public virtual ICollection<Player> Players { get; private set; }

        public virtual IReadOnlyCollection<int> CharactersIds { get; private set; }

        public virtual ICollection<Vote> Votes { get; private set; }

        public virtual IDictionary<Guid, GameStatus> PlayersGameStatuses { get; private set; }

        public virtual IDictionary<Guid, int> PlayersVotes { get; private set; }

        public bool CanPlayerJoin(Guid playerId)
        {
            if (playerId == Guid.Empty
                || this.Players.Count >= this.PlayersCount
                || this.Players.Any(p => p.Id == playerId))
            {
                return false;
            }

            return true;
        }

        public Game Join(Player player)
        {
            if (this.CanPlayerJoin(player.Id))
            {
                this.Players.Add(player);
            }

            return this;
        }
    }
}
