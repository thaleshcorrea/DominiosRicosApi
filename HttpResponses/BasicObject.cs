namespace Teste.HttpResponses
{
    public class BasicObject
    {
        public BasicObject(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}