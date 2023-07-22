using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(property => property.UserId);
            builder.Property(property => property.Name)
                                                 .HasMaxLength(250)
                                                 .IsRequired();
            builder.Property(property => property.Image)
                                                 .IsRequired();
            builder.Property(property => property.LastName)
                                                 .HasMaxLength(250)
                                                 .IsRequired();
            builder.Property(property => property.SecondLastName)
                                                 .HasMaxLength(250);
            builder.Property(property => property.DateOfBirth)
                                                 .IsRequired();
            builder.Property(property => property.numberPhone)
                                                 .HasMaxLength(50)
                                                 .IsRequired();
            builder.Property(property => property.Email)
                                                .HasMaxLength(100)
                                                .IsRequired()
                                                ;
            builder.Property(property => property.Address);
            builder.Property(property => property.RolId)
                                                .IsRequired();
            builder.Property(property => property.DocumentTypeId)
                                                .IsRequired();
            builder.Property(property => property.Document)
                                                .IsRequired();
            builder.Property(property => property.Password)
                                                .IsRequired();
            builder.Property(property => property.Edad);
            builder.Property(property => property.CreatedBy);
            builder.Property(property => property.LastModifiedBy);


        }
    }
}
