using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DocumentsTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentsTypes");
            builder.HasKey(property => property.DocumentTypeId);
            builder.Property(property => property.Name)
                                                 .HasMaxLength(300)
                                                 .IsRequired();
        }
    }
}
