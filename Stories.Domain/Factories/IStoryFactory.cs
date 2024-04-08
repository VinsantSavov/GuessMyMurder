using Common.Domain.Interfaces;

using Stories.Domain.Models.Characters;
using Stories.Domain.Models.Stories;

namespace Stories.Domain.Factories
{
    public interface IStoryFactory : IFactory<Story>
    {
        IStoryFactory WithCreatorId(Guid creatorId);

        IStoryFactory WithTitle(string title);

        IStoryFactory WithPlot(string plot);

        IStoryFactory WithCharacter(Character character);
    }
}
