namespace Teste.HttpResponses
{
    public class BasicResponse<T> : IResponse
    {
        public BasicResponse(T response)
        {
            Response = response;
            StatusCode = 200;
            Error = false;
        }

        public BasicResponse(T response, int statusCode, bool error = false)
        {
            StatusCode = statusCode;
            Response = response;
            Error = error;
        }

        public int StatusCode { get; set; }
        public object Response { get; set; }
        public bool? Error { get; set; }
    }
}