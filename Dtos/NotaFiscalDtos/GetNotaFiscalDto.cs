namespace Teste.Dtos.NFE_notaDtos
{
    public class GetNFE_notaDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public string ClienteNome { get; set; }
        public int ClienteId { get;set; }
    }
}