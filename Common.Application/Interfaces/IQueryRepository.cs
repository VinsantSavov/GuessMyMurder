using Common.Domain.Interfaces;

namespace Common.Application.Interfaces
{
    public interface IQueryRepository<TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
