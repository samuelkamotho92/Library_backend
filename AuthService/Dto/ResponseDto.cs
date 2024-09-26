using System.Net;

namespace AuthService.Dto
{
    public class ResponseDto
    {
        public string Message { get; set; }

        public HttpStatusCode statusCode { get; set; }

        public Object result { get;set; }

    }
}
