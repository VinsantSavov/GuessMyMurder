using Common.Application;
using Common.Application.Exceptions;

using Stories.Domain.Repositories;
using Stories.Domain.Models.Stories;

namespace Stories.Application.Stories.Commands.Edit
{
    public class EditStoryCommand : EntityCommand<Guid>
    {
        public string Title { get; }

        public string Plot {  get; }

        public class EditStoryCommandHandler
        {
            private readonly IStoryDomainRepository _storyRepository;

            public EditStoryCommandHandler(IStoryDomainRepository storyRepository)
            {
                this._storyRepository = storyRepository;
            }

            public async Task<EditStoryResponseModel> Handle(EditStoryCommand request)
            {
                var story = await this._storyRepository.GetAsync(request.Id);

                if (story == null)
                {
                    throw new NotFoundException(nameof(Story), request.Id.ToString());
                }

                story.UpdateTitle(request.Title)
                     .UpdatePlot(request.Plot);

                await this._storyRepository.SaveChangesAsync();

                return new EditStoryResponseModel(story.Id);
            }
        }
    }
}
