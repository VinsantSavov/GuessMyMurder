using Common.Application.Interfaces;

using Stories.Domain.Models.Stories;

namespace Stories.Application.Stories
{
    public interface IStoryQueryRepository : IQueryRepository<Story>
    {
        Task<TModel> GetStoryAsync<TModel>(Guid storyId);

        Task<IEnumerable<TModel>> GetAllStoriesAsync<TModel>();

        Task<IEnumerable<TModel>> GetUserStoriesAsync<TModel>(Guid userId);

        Task<IEnumerable<TModel>> GetStoryCharactersAsync<TModel>(Guid storyId);
    }
}
