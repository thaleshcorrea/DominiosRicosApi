using System;
using Flunt.Notifications;
using Flunt.Validations;
using Teste.Shared;

namespace Teste.Dtos.ClienteDtos
{
    public class UpdateClienteDto : Notifiable<Notification>, IValidatable
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<UpdateClienteDto>()
                    .Requires()
                    .IsNotEmpty(Nome, "Cliente.Nome", "Nome não pode ser vazio")
            );
        }
    }
}