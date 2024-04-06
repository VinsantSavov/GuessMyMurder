using Common.Domain.Models;

namespace Games.Domain.Models.Games
{
    public class GameStatus : Enumeration
    {
        public readonly static GameStatus NotStarted = new GameStatus(0, nameof(NotStarted));
        public readonly static GameStatus WaitingForPlayers = new GameStatus(1, nameof(WaitingForPlayers));
        public readonly static GameStatus Started = new GameStatus(2, nameof(Started));
        public readonly static GameStatus Finished = new GameStatus(3, nameof(Finished));
        public readonly static GameStatus Cancelled = new GameStatus(4, nameof(Cancelled));

        private GameStatus(int value, string name)
            : base(value, name)
        {
        }
    }
}
