namespace Teste.HttpResponses
{
    public interface IResponse
    {
        int StatusCode { get; set; }
        object Response { get; set; }
        bool? Error { get; set; }
    }
}