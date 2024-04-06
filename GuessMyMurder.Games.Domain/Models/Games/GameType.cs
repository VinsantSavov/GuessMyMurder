using Common.Domain.Models;

namespace Games.Domain.Models.Games
{
    public class GameType : Enumeration
    {
        public static readonly GameType Friendly = new GameType(0, nameof(Friendly));
        public static readonly GameType Competitive = new GameType(1, nameof(Competitive));

        private GameType(int value, string name) 
            : base(value, name)
        {
        }
    }
}
