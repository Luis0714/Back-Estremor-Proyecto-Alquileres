using Ardalis.Specification;
using Domain.Entities;

namespace Application.Espesification
{
    public class RolPorNameSpecification : Specification<Rol>
    {
        public RolPorNameSpecification(string? Nombre)
        {
            if (!string.IsNullOrEmpty(Nombre))
                Query.Where(rol => rol.Nombre == Nombre);
        }
    }
}
