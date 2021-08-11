using System;
using Flunt.Notifications;
using Teste.Shared;

namespace Teste.Dtos.NotaFiscalDtos
{
    public class SaveNotaFiscalDto : Notifiable<Notification>, IValidatable
    {
        public int Numero { get; set; }
        public int Serie { get; set; }
        public int Modelo { get; set; }
        public DateTime DataEmissao { get; set; }
        public int Status { get; set; }
        public string Motivo { get; set; }
        public Guid ClienteId { get; set; }

        public void Validate()
        {
            
        }
    }
}