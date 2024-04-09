using Stories.Application.Stories.Queries.Common;

namespace Stories.Application.Stories.Queries.StoryCharacters
{
    public class GetStoryCharactersResponseModel
    {
        internal GetStoryCharactersResponseModel(IEnumerable<StoryCharacterResponseModel> characters)
        {
            this.Characters = characters;
        }

        public IEnumerable<StoryCharacterResponseModel> Characters { get; }
    }
}
