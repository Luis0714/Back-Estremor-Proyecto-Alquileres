namespace Application.Whappers
{
    public class PagesResponse<T> : Response<T>
    {
        public PagesResponse(T data, int pageNumber,int pageZise)
        {
            PageNumber = pageNumber;
            PageZise = pageZise;
            this.data = data;
            this.message = null;
            this.succeeded = true;
            this.errors = null;
        }

        public int PageNumber { get; set; }
        public int PageZise { get; set; }


    }
}
