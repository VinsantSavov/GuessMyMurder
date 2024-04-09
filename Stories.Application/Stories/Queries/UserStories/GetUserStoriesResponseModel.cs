using Stories.Application.Stories.Queries.Common;

namespace Stories.Application.Stories.Queries.UserStories
{
    public class GetUserStoriesResponseModel
    {
        internal GetUserStoriesResponseModel(IEnumerable<StoryResponseModel> stories)
        {
            this.Stories = stories;
        }

        public IEnumerable<StoryResponseModel> Stories { get; }
    }
}
