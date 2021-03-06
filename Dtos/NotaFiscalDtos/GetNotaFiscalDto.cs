using System;

namespace Teste.Dtos.NotaFiscalDtos
{
    public class GetNotaFiscalDto
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public int Serie { get; set; }
        public int Modelo { get; set; }
        public DateTime DataEmissao { get; set; }
        public int Status { get; set; }
        public string Motivo { get; set; }
        public Guid ClienteId { get; set; }
        public string ClienteNome { get; set; }
    }
}