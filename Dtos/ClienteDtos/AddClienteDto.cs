using Flunt.Notifications;
using Flunt.Validations;
using Teste.Shared;

namespace Teste.Dtos.ClienteDtos
{
    public class AddClienteDto : Notifiable<Notification>, IValidatable
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<AddClienteDto>()
                    .Requires()
                    .IsNotEmpty(Nome, "Cliente.Nome", "Nome não pode ser vazio")
                    .IsGreaterOrEqualsThan(Documento.Length, 11, "Cliente.Documento", "Documento inválido")
            );
        }
    }
}