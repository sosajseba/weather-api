namespace Api.Responses
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public Response(T data, bool succeded, string message)
        {
            Succeeded = succeded;
            Message = message;
            Data = data;
        }
        public Response(bool succeded, string message)
        {
            Succeeded = succeded;
            Message = message;
        }
    }
}