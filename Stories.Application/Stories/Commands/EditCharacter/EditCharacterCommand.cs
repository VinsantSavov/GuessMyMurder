using MediatR;

using Common.Application;
using Common.Application.Exceptions;

using Stories.Domain.Repositories;
using Stories.Domain.Models.Stories;
using Stories.Domain.Models.Characters;

namespace Stories.Application.Stories.Commands.EditCharacter
{
    public class EditCharacterCommand : EntityCommand<Guid>, IRequest<EditCharacterResponseModel>
    {
        public int CharacterId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Spotlight { get; }

        public class EditCharacterCommandHandler : IRequestHandler<EditCharacterCommand, EditCharacterResponseModel>
        {
            private readonly IStoryDomainRepository _storyRepository;

            public EditCharacterCommandHandler(IStoryDomainRepository storyRepository) 
            {
                this._storyRepository = storyRepository;
            }

            public async Task<EditCharacterResponseModel> Handle(
                EditCharacterCommand request,
                CancellationToken cancellationToken)
            {
                var story = await this._storyRepository.GetAsync(request.Id, cancellationToken);

                if (story == null)
                {
                    throw new NotFoundException(nameof(Story), request.Id.ToString());
                }

                var character = story.Characters.FirstOrDefault(c => c.Id == request.CharacterId);

                if (character == null)
                {
                    throw new NotFoundException(nameof(Character), request.CharacterId.ToString());
                }

                story.UpdateCharacter(character, request.FirstName, request.LastName, request.Spotlight);

                await this._storyRepository.SaveChangesAsync(cancellationToken);

                return new EditCharacterResponseModel(character.Id);
            }
        }
    }
}
