using MediatR;

namespace Stories.Application.Stories.Queries.UserStories
{
    public class GetUserStoriesQuery : IRequest<IEnumerable<GetUserStoriesResponseModel>>
    {
        public Guid UserId { get; set; }

        public class GetUserStoriesQueryHandler : IRequestHandler<GetUserStoriesQuery, IEnumerable<GetUserStoriesResponseModel>>
        {
            private readonly IStoryQueryRepository _storyQueryRepository;

            public GetUserStoriesQueryHandler(IStoryQueryRepository storyQueryRepository)
            {
                this._storyQueryRepository = storyQueryRepository;
            }

            public async Task<IEnumerable<GetUserStoriesResponseModel>> Handle(
                GetUserStoriesQuery request,
                CancellationToken cancellationToken)
                => await this._storyQueryRepository.GetUserStoriesAsync<GetUserStoriesResponseModel>(request.UserId, cancellationToken);
        }
    }
}
