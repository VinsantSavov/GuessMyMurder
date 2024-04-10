using Common.Application.Interfaces;

using Stories.Domain.Models.Stories;

namespace Stories.Application.Stories
{
    public interface IStoryQueryRepository : IQueryRepository<Story>
    {
        Task<TModel> GetStoryAsync<TModel>(Guid storyId, CancellationToken cancellationToken = default);

        Task<IEnumerable<TModel>> GetAllStoriesAsync<TModel>(CancellationToken cancellationToken = default);

        Task<IEnumerable<TModel>> GetUserStoriesAsync<TModel>(Guid userId, CancellationToken cancellationToken = default);

        Task<IEnumerable<TModel>> GetStoryCharactersAsync<TModel>(Guid storyId, CancellationToken cancellationToken = default);
    }
}
