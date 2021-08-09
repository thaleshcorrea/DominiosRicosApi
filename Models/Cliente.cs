using System.Collections.Generic;

namespace Teste.Models
{
    public class Cliente
    {
        public Cliente(
            string nome, 
            string cpfCnpj)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }

        public IList<NotaFiscal> NotasFiscais { get;set; }
    }
}