using Common.Application;
using Common.Application.Exceptions;

using Stories.Domain.Repositories;
using Stories.Domain.Models.Stories;

namespace Stories.Application.Stories.Commands.DeleteCharacter
{
    public class DeleteCharacterCommand : EntityCommand<Guid>
    {
        public int CharacterId { get; }

        public class DeleteCharacterCommandHandler
        {
            private readonly IStoryDomainRepository _storyRepository;

            public DeleteCharacterCommandHandler(IStoryDomainRepository storyRepository)
            {
                this._storyRepository = storyRepository;
            }

            public async Task Handle(DeleteCharacterCommand request)
            {
                var story = await this._storyRepository.GetAsync(request.Id);

                if (story == null)
                {
                    throw new NotFoundException(nameof(Story), request.Id.ToString());
                }

                story.RemoveCharacter(request.CharacterId);
            }
        }
    }
}
