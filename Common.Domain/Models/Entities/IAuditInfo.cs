namespace Common.Domain.Models.Entities
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; }

        DateTime? ModifiedOn { get; }
    }
}
