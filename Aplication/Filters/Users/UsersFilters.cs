namespace Application.Filters.Users
{
    public class UsersFilters
    {
        public int PageNumber { get; set; }

        public UsersFilters(int pageNumber, int pageZise)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber; ;
            PageZise = pageZise < 1 ? 5:pageZise;
        }

        public int PageZise { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }


    }
}
