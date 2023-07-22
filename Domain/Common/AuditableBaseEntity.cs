namespace Domain.Common
{
    public class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
