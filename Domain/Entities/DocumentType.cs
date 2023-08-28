using Domain.Common;

namespace Domain.Entities
{
    public class DocumentType : AuditableBaseEntity
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
    }
}
