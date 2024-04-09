using Common.Application;

using Stories.Domain.Repositories;

namespace Stories.Application.Stories.Commands.Delete
{
    public class DeleteStoryCommand : EntityCommand<Guid>
    {
        public class DeleteStoryCommandHandler
        {
            private readonly IStoryDomainRepository _storyRepository;

            public DeleteStoryCommandHandler(IStoryDomainRepository storyRepository)
            {
                this._storyRepository = storyRepository;
            }

            public async Task Handle(DeleteStoryCommand request)
                => await this._storyRepository.DeleteAsync(request.Id);
        }
    }
}
