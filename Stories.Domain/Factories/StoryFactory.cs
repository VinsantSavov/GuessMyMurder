using Stories.Domain.Exceptions;
using Stories.Domain.Models.Characters;
using Stories.Domain.Models.Stories;

namespace Stories.Domain.Factories
{
    public class StoryFactory : IStoryFactory
    {
        private Guid _creatorId = default;
        private string _title = string.Empty;
        private string _plot = string.Empty;
        private HashSet<Character> _characters = new HashSet<Character>();

        private bool _isCreatorIdSet = false;
        private bool _isTitleSet = false;
        private bool _isPlotSet = false;

        public IStoryFactory WithCreatorId(Guid creatorId)
        {
            this._creatorId = creatorId;
            _isCreatorIdSet = true;

            return this;
        }

        public IStoryFactory WithTitle(string title)
        {
            this._title = title;
            this._isTitleSet = true;

            return this;
        }

        public IStoryFactory WithPlot(string plot)
        {
            this._plot = plot;
            this._isPlotSet = true;

            return this;
        }

        public IStoryFactory WithCharacter(Character character)
        {
            this._characters.Add(character);

            return this;
        }

        public Story Build()
        {
            if (!this._isCreatorIdSet
                || !this._isTitleSet
                || !this._isPlotSet)
            {
                throw new InvalidStoryException("A story must have creator, title and plot!");
            }

            return new Story(this._creatorId, this._title, this._plot);
        }
    }
}
