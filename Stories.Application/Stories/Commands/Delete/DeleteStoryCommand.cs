using MediatR;

using Common.Application;

using Stories.Domain.Repositories;

namespace Stories.Application.Stories.Commands.Delete
{
    public class DeleteStoryCommand : EntityCommand<Guid>, IRequest
    {
        public class DeleteStoryCommandHandler : IRequestHandler<DeleteStoryCommand>
        {
            private readonly IStoryDomainRepository _storyRepository;

            public DeleteStoryCommandHandler(IStoryDomainRepository storyRepository)
            {
                this._storyRepository = storyRepository;
            }

            public async Task Handle(
                DeleteStoryCommand request,
                CancellationToken cancellationToken)
                => await this._storyRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
