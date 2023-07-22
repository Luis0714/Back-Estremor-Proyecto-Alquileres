namespace Application.Whappers
{
    public class PagesResponse<T> : Response<T>
    {
        public PagesResponse(T data, int pageNumber,int pageZise)
        {
            PageNumber = pageNumber;
            PageZise = pageZise;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public int PageNumber { get; set; }
        public int PageZise { get; set; }


    }
}
