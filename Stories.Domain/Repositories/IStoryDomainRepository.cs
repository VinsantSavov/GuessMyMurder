using Common.Domain.Interfaces;

using Stories.Domain.Models.Stories;

namespace Stories.Domain.Repositories
{
    public interface IStoryDomainRepository : IDomainRepository<Story>
    {
        Task<bool> AddAsync(Story story, CancellationToken cancellationToken = default);

        Task<Story> GetAsync(Guid storyId, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid storyId, CancellationToken cancellationToken = default);

        Task<bool> DeleteCharacterAsync(Guid storyId, int characterId, CancellationToken cancellationToken = default);
    }
}
