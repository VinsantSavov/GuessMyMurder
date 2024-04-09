using Common.Application;
using Common.Application.Exceptions;

using Stories.Domain.Repositories;
using Stories.Domain.Models.Stories;
using Stories.Domain.Models.Characters;

namespace Stories.Application.Stories.Commands.AddCharacter
{
    public class AddCharacterCommand : EntityCommand<Guid>
    {
        public Character Character {  get; }

        public class AddCharacterCommandHandler
        {
            private IStoryDomainRepository _storyRepository;

            public AddCharacterCommandHandler(IStoryDomainRepository storyRepository)
            {
                this._storyRepository = storyRepository;
            }

            public async Task<AddCharacterResponseModel> Handle(AddCharacterCommand request)
            {
                var story = await this._storyRepository.GetAsync(request.Id);

                if (story == null)
                {
                    throw new NotFoundException(nameof(Story), request.Id.ToString());
                }

                story.AddCharacter(request.Character);

                await this._storyRepository.SaveChangesAsync();

                return new AddCharacterResponseModel(request.Character.Id);
            }
        }
    }
}
