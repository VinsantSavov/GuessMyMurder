namespace Stories.Application.Stories.Queries.All
{
    public class GetAllStoriesQuery
    {
        public class GetAllStoriesQueryHandler
        {
            private readonly IStoryQueryRepository _storyRepository;

            public GetAllStoriesQueryHandler(IStoryQueryRepository storyRepository)
            {
                this._storyRepository = storyRepository;
            }

            public async Task<IEnumerable<GetAllStoriesResponseModel>> Handle(GetAllStoriesQuery request)
                => await this._storyRepository.GetAllStoriesAsync<GetAllStoriesResponseModel>();
        }
    }
}
