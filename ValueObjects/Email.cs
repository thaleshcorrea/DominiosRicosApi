using Flunt.Validations;

namespace Teste.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(
                new Contract<Email>()
                    .Requires()
                    .IsEmail(Endereco, "Email.Endereco", "E-mail inválido")
            );
        }
        public string Endereco { get; private set; }
    }
}