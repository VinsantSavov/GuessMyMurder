using System.ComponentModel.DataAnnotations;

namespace Common.Domain.Models.Entities
{
    public class BaseModel<TKey> : IDatabaseModel, IAuditInfo
    {
        [Key]
        public TKey Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? ModifiedOn { get; private set; }
    }
}
