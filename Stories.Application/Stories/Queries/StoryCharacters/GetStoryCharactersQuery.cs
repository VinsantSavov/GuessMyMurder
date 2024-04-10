using MediatR;

namespace Stories.Application.Stories.Queries.StoryCharacters
{
    public class GetStoryCharactersQuery : IRequest<IEnumerable<GetStoryCharactersResponseModel>>
    {
        public Guid StoryId { get; set; }

        public class GetStoryCharactersQueryHandler : IRequestHandler<GetStoryCharactersQuery, IEnumerable<GetStoryCharactersResponseModel>>
        {
            private readonly IStoryQueryRepository _storyQueryRepository;

            public GetStoryCharactersQueryHandler(IStoryQueryRepository storyQueryRepository)
            {
                this._storyQueryRepository = storyQueryRepository;
            }

            public async Task<IEnumerable<GetStoryCharactersResponseModel>> Handle(
                GetStoryCharactersQuery request,
                CancellationToken cancellationToken)
                => await this._storyQueryRepository.GetStoryCharactersAsync<GetStoryCharactersResponseModel>(request.StoryId, cancellationToken);
        }
    }
}
