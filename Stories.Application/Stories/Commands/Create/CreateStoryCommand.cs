using Common.Application;

using Stories.Domain.Factories;
using Stories.Domain.Repositories;

namespace Stories.Application.Stories.Commands.Create
{
    public class CreateStoryCommand : EntityCommand<Guid>
    {
        public Guid CreatorId { get; set; }

        public string Title { get; set; }

        public string Plot { get; set; }

        public class CreateStoryCommandHandler
        {
            private readonly IStoryFactory _storyFactory;
            private readonly IStoryDomainRepository _storyRepository;

            public CreateStoryCommandHandler(
                IStoryFactory storyFactory,
                IStoryDomainRepository storyRepository)
            {
                this._storyFactory = storyFactory;
                this._storyRepository = storyRepository;
            }

            public async Task<CreateStoryResponseModel> Handle(CreateStoryCommand request)
            {
                this._storyFactory.WithCreatorId(request.CreatorId)
                                  .WithTitle(request.Title)
                                  .WithPlot(request.Plot);

                var story = this._storyFactory.Build();

                await this._storyRepository.SaveAsync(story);

                return new CreateStoryResponseModel(story.Id);
            }
        }
    }
}
