using Common.Domain.Constants;
using Common.Domain.Interfaces;
using Common.Domain.Models;
using Common.Domain.Models.Entities;

using Stories.Domain.Constants;
using Stories.Domain.Exceptions;
using Stories.Domain.Models.Characters;

namespace Stories.Domain.Models.Stories
{
    public class Story : BaseModel<Guid>, IAggregateRoot
    {
        private readonly HashSet<Character> _characters;

        internal Story(
            Guid creatorId,
            string title,
            string plot)
        {
            this.ValidateCreatorId(creatorId);
            this.ValidateTitle(title);
            this.ValidatePlot(plot);

            this.CreatorId = creatorId;
            this.Title = title;
            this.Plot = plot;
            this._characters = new HashSet<Character>();
        }

        public Guid CreatorId { get; private set; }

        public string Title { get; private set; }

        public string Plot { get; private set; }

        public virtual IReadOnlyCollection<Character> Characters => this._characters;

        public Story UpdateTitle(string title)
        {
            this.ValidateTitle(title);

            this.Title = title;

            return this;
        }

        public Story UpdatePlot(string plot)
        {
            this.ValidatePlot(plot);

            this.Plot = plot;

            return this;
        }

        public Story AddCharacter(Character character)
        {
            this.ValidateCharactersCount(this._characters);

            this._characters.Add(character);

            return this;
        }

        public Story AddCharacter(
            string firstName, 
            string lastName, 
            string spotlight)
        {
            this.ValidateCharactersCount(this._characters);

            var character = new Character(firstName, lastName, spotlight);
            this._characters.Add(character);

            return this;
        }

        public Story UpdateCharacter(
            Character character, 
            string firstName, 
            string lastName, 
            string spotlight)
        {
            character.UpdateFirstName(firstName)
                     .UpdateLastName(lastName)
                     .UpdateSpotlight(spotlight);

            return this;
        }

        public Story RemoveCharacter(Character character)
        {
            this._characters.Remove(character);

            return this;
        }

        public Story RemoveCharacter(int characterId)
        {
            this._characters.RemoveWhere(c => c.Id == characterId);

            return this;
        }

        #region Validation

        private void ValidateCreatorId(Guid creatorId)
            => Guard.ForInvalidGuid<InvalidStoryException>(creatorId);

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidStoryException>(
                title,
                StringConstants.MinNameLength,
                StringConstants.MaxNameLength);

        private void ValidatePlot(string plot)
            => Guard.ForStringLength<InvalidStoryException>(
                plot,
                StringConstants.MinStoryLength,
                StringConstants.MaxStoryLength);

        private void ValidateCharactersCount(IReadOnlyCollection<Character> characters)
            => Guard.ForCollectionCount<InvalidStoryException>(
                characters.Count + 1,
                maxCount: CharactersConstants.MaxCharactersInStoryCount);

        #endregion
    }
}
