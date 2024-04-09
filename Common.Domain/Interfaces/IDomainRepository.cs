namespace Common.Domain.Interfaces
{
    public interface IDomainRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        Task SaveAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
