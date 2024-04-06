using Games.Domain.Models.Games;
using Games.Domain.Models.Players;
using Common.Domain.Models.Entities;

namespace Games.Domain.Models.Votes
{
    public class Vote : BaseModel<int>
    {
        public Player Player {  get; private set; }

        public Game Game { get; private set; }

        public int CharacterId { get; private set; }
    }
}
