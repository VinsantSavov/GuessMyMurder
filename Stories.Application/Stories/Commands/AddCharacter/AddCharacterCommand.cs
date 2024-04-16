using MediatR;

using Common.Application;
using Common.Application.Exceptions;

using Stories.Domain.Repositories;
using Stories.Domain.Models.Stories;

namespace Stories.Application.Stories.Commands.AddCharacter
{
    public class AddCharacterCommand : EntityCommand<Guid>, IRequest<AddCharacterResponseModel>
    {
        public string? FirstName {  get; }

        public string? LastName { get; }

        public string? Spotlight { get; }

        public class AddCharacterCommandHandler : IRequestHandler<AddCharacterCommand, AddCharacterResponseModel>
        {
            private readonly IStoryDomainRepository _storyRepository;

            public AddCharacterCommandHandler(IStoryDomainRepository storyRepository)
            {
                this._storyRepository = storyRepository;
            }

            public async Task<AddCharacterResponseModel> Handle(
                AddCharacterCommand request,
                CancellationToken cancellationToken)
            {
                var story = await this._storyRepository.GetAsync(request.Id, cancellationToken);

                if (story == null)
                {
                    throw new NotFoundException(nameof(Story), request.Id.ToString());
                }

                story.AddCharacter(request.FirstName, request.LastName, request.Spotlight);

                await this._storyRepository.SaveChangesAsync(cancellationToken);

                return new AddCharacterResponseModel();
            }
        }
    }
}
