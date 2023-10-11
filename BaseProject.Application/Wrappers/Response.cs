namespace BaseProject.Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = "")
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        public Response(string message, Dictionary<string, string[]> errors)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; } = new();
        public T Data { get; set; }

    }
}