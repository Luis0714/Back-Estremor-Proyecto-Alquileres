using Ardalis.Specification;
using DocumentType = Domain.Entities.DocumentType;

namespace Application.Espesification
{
    public class DocumentTypeForNameSpecification : Specification<DocumentType>
    {
        public DocumentTypeForNameSpecification(string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Query.Where(documentType => documentType.Name == name);
            }
        }
    }
}
