using Games.Domain.Models.Games;
using Games.Domain.Models.Players;
using Common.Domain.Models.Entities;

namespace Games.Domain.Models.Notes
{
    public class Note : BaseModel<int>, IDeletableEntity
    {
        public Player Creator { get; private set; }

        public Game Game { get; private set; }

        public string Title {  get; private set; }

        public string Description { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime? DeletedOn { get; private set; }
    }
}
