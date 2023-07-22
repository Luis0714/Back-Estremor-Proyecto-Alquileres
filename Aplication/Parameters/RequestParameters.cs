namespace Application.Parameters
{
    public class RequestParameters
    {
        public int PageNumber { get; set; }
        public int PageZise { get; set; }

        public RequestParameters()
        {
            PageNumber = 1;
            PageZise = 10;
        }

        public RequestParameters(int pageNumber, int pageZise)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageZise = pageZise < 1 ? 10 : pageNumber;
        }
    }
}
