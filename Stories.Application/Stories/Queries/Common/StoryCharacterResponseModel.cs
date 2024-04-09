using Common.Application.Mapping;

using Stories.Domain.Models.Characters;

namespace Stories.Application.Stories.Queries.Common
{
    public class StoryCharacterResponseModel : IMapFrom<Character>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string? Spotlight { get; private set; }
    }
}
