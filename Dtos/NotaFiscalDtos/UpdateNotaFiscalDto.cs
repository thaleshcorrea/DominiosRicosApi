namespace Teste.Dtos.NFE_notaDtos
{
    public class UpdateNFE_notaDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public int ClienteId { get;set; }
    }
}