namespace Stories.Application.Stories.Queries.StoryCharacters
{
    public class GetStoryCharactersQuery
    {
        public Guid StoryId { get; set; }

        public class GetStoryCharactersQueryHandler
        {
            private readonly IStoryQueryRepository _storyQueryRepository;

            public GetStoryCharactersQueryHandler(IStoryQueryRepository storyQueryRepository)
            {
                this._storyQueryRepository = storyQueryRepository;
            }

            public async Task<IEnumerable<GetStoryCharactersResponseModel>> Handle(GetStoryCharactersQuery request)
                => await this._storyQueryRepository.GetStoryCharactersAsync<GetStoryCharactersResponseModel>(request.StoryId);
        }
    }
}
