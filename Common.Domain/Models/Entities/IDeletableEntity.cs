namespace Common.Domain.Models.Entities
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; }

        DateTime? DeletedOn { get; }
    }
}
