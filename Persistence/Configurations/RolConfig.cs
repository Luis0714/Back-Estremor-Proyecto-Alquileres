using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RolConfig: IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rols");
            builder.HasKey(property => property.RolId);
            builder.Property(property => property.Nombre)
                                                 .HasMaxLength(300)
                                                 .IsRequired();
        }
    }
}
