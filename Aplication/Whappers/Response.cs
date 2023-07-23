namespace Application.Whappers
{
    public class Response<T>
    {
        public Response() 
        { 

        }
        public Response(T data)
        {
            this.succeeded = true;
            this.data = data;
        }
        public Response(T data, string message)
        {
            this.succeeded = true;
            this.message = message;
            this.data = data;
        }

        public Response(string message)
        {
            this.succeeded = true;
            this.message = message;
        }
        public bool succeeded  { get; set; }
        public List<string>? errors  { get; set; }
        public string? message { get; set; }
        public T? data { get; set; }
    }
}
