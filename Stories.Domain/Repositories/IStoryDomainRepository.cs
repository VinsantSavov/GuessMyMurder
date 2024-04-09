using Common.Domain.Interfaces;

using Stories.Domain.Models.Stories;

namespace Stories.Domain.Repositories
{
    public interface IStoryDomainRepository : IDomainRepository<Story>
    {
        Task<bool> AddAsync(Story story);

        Task<Story> GetAsync(Guid storyId);

        Task<bool> DeleteAsync(Guid storyId);

        Task<bool> DeleteCharacterAsync(Guid storyId, int characterId);
    }
}
