namespace Stories.Application.Stories.Queries.UserStories
{
    public class GetUserStoriesQuery
    {
        public Guid UserId { get; set; }

        public class GetUserStoriesQueryHandler
        {
            private readonly IStoryQueryRepository _storyQueryRepository;

            public GetUserStoriesQueryHandler(IStoryQueryRepository storyQueryRepository)
            {
                this._storyQueryRepository = storyQueryRepository;
            }

            public async Task<IEnumerable<GetUserStoriesResponseModel>> Handle(GetUserStoriesQuery request)
                => await this._storyQueryRepository.GetUserStoriesAsync<GetUserStoriesResponseModel>(request.UserId);
        }
    }
}
