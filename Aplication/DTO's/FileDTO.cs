using Microsoft.AspNetCore.Http;

namespace Application.DTO_s
{
    public class FileDto
    {
        public IFormFile? Image { get; set; }
        public string? Ruta { get; set; }
    }
}
