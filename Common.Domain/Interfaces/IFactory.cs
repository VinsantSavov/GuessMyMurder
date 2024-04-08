namespace Common.Domain.Interfaces
{
    public interface IFactory<TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
