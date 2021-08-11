using System.Collections.Generic;
using System.Linq;
using Teste.ValueObjects;

namespace Teste.Models
{
    public class Cliente : Entity
    {
        public Cliente() { }

        public Cliente(
            string nome,
            Documento documento,
            Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
        }

        public string Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }

        public IList<NotaFiscal> NotasFiscais { get; set; }

        public void AdicionarNotaFiscal(NotaFiscal notaFiscal)
        {
            NotasFiscais.Add(notaFiscal);
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarEmail(string endereco)
        {
            Email = new(endereco);
        }
    }
}