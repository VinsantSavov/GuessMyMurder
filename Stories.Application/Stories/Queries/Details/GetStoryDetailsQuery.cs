using MediatR;

using Stories.Application.Stories.Queries.Common;

namespace Stories.Application.Stories.Queries.Details
{
    public class GetStoryDetailsQuery : IRequest<StoryResponseModel>
    {
        public Guid StoryId { get; set; }

        public class GetStoryDetailsQueryHandler : IRequestHandler<GetStoryDetailsQuery, StoryResponseModel>
        {
            private IStoryQueryRepository _storyQueryRepository;

            public GetStoryDetailsQueryHandler(IStoryQueryRepository storyQueryRepository)
            {
                this._storyQueryRepository = storyQueryRepository;
            }

            public async Task<StoryResponseModel> Handle(
                GetStoryDetailsQuery request, 
                CancellationToken cancellationToken)
                => await this._storyQueryRepository.GetStoryAsync<StoryResponseModel>(request.StoryId);
        }
    }
}
