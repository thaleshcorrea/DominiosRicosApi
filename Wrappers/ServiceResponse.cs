namespace Teste.Wrappers
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            
        }

        public ServiceResponse(int statusCode, string error)
        {
            StatusCode = statusCode;
            Success = false;
            Errors = new string[] { error };
        }

        public ServiceResponse(in t statusCode, T data)
        {
            StatusCode = statusCode;
            Success = true;
            Data = data;
        }

        public int StatusCode { get; set; }
        public bool Success { get;set; }
        public string Message { get; set; }
        public T Data { get;set; }
        public string[] Errors { get; set; }
    }
}