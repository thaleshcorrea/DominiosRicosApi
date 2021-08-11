using System;
using Flunt.Notifications;

namespace Teste.Dtos.ClienteDtos
{
    public class GetClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
    }
}