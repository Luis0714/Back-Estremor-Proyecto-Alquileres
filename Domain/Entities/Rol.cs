using Domain.Common;

namespace Domain.Entities
{
    public class Rol : AuditableBaseEntity
    {
        public int RolId { get; set; }
        public string? Nombre { get; set; }
    }
}
