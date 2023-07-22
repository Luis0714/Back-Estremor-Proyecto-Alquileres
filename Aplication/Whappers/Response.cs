namespace Application.Whappers
{
    public class Response<T>
    {
        public Response() 
        { 

        }
        public Response(T data)
        {
            Succeeded = true;
            Data = data;
        }
        public Response(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }
        public bool Succeeded  { get; set; }
        public List<string>? Errors  { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
