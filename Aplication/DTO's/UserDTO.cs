namespace Application.DTO_s
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? numberPhone { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
        public int DocumentTypeId { get; set; }
        public string? Address { get; set; }
        public int RolId { get; set; }
        public int Edad {get; set; }
        public RolDto? Rol { get; set; }
    }
}
