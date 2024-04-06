using Games.Domain.Exceptions;
using Games.Domain.Models.Votes;
using Games.Domain.Models.Games;
using Common.Domain.Models.Entities;

namespace Games.Domain.Models.Players
{
    public class Player : BaseModel<Guid>
    {
        public Guid UserId { get; private set; }

        public string ProfilePicture { get; private set; }

        public string Description { get; private set; }

        public int Rating { get; private set; }

        public virtual IReadOnlyCollection<Game> Games { get; private set; }

        public virtual ICollection<Vote> Votes { get; private set; }

        public bool CanVote(Game game, int characterId)
        {
            if (!this.Games.Any(g => g.Id == game.Id)
                || !game.CharactersIds.Contains(characterId)
                || this.Votes.Any(v => v.Game.Id == game.Id))
            {
                return false;
            }

            return true;
        }

        /*public Player Vote(Guid gameId, int characterId)
        {
            if (this.CanVote(playerId, characterId))
            {
                Game.PlayersVotes.Add(playerId, characterId);
            }

            return this;
        }

        public Player StartGame()
        {
            if (Game.PlayersIds.Contains(this.Id)
                && Game.PlayersGameStatuses.ContainsKey(this.Id))
            {
                Game.PlayersGameStatuses[this.Id] = GameStatus.Started;
            }

            return this;
        }

        public Player FinishGame()
        {
            this.ValidateGameStarted();

            Game.PlayersGameStatuses[this.Id] = GameStatus.Finished;

            return this;
        }

        private void ValidateGameStarted()
        {
            if (!Game.PlayersIds.Contains(this.Id)
                || !Game.PlayersGameStatuses.ContainsKey(this.Id)
                || Game.PlayersGameStatuses[this.Id] != GameStatus.Started)
            {
                throw new InvalidGameException($"Player with id: {this.Id} didn't start the game!");
            }
        }*/
    }
}
