using Stories.Application.Stories.Queries.Common;

namespace Stories.Application.Stories.Queries.Details
{
    public class GetStoryDetailsQuery
    {
        public Guid StoryId { get; set; }

        public class GetStoryDetailsQueryHandler
        {
            private IStoryQueryRepository _storyQueryRepository;

            public GetStoryDetailsQueryHandler(IStoryQueryRepository storyQueryRepository)
            {
                this._storyQueryRepository = storyQueryRepository;
            }

            public async Task<StoryResponseModel> Handle(GetStoryDetailsQuery request)
                => await this._storyQueryRepository.GetStoryAsync<StoryResponseModel>(request.StoryId);
        }
    }
}
