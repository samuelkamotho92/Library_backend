using System.Net;

namespace Library.Dto
{
    public class ResponseDto
    {
        public string Message { get; set; } = string.Empty;

        public HttpStatusCode statusCode { get; set; }

        public object Result {  get; set; } 
    }
}
