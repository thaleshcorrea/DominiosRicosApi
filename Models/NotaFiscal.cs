using System;
using Flunt.Validations;

namespace Teste.Models
{
    public class NotaFiscal : Entity
    {
        public NotaFiscal() { }

        public NotaFiscal(
            int numero,
            int serie,
            int modelo,
            DateTime dataEmissao,
            int status,
            string motivo,
            Guid clienteId)
        {
            Numero = numero;
            Serie = serie;
            Modelo = modelo;
            DataEmissao = dataEmissao;
            Status = status;
            Motivo = motivo;
            ClienteId = clienteId;
        }

        public int Numero { get; private set; }
        public int Serie { get; private set; }
        public int Modelo { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public int Status { get; private set; }
        public string Motivo { get; set; }
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; set; }

        public void UpdateDataEmissao(DateTime dataEmissao)
        {
            DataEmissao = dataEmissao;
        }

        public void UpdateStatus(int status)
        {
            Status = status;
        }

        public void UpdateMotivo(string motivo)
        {
            Motivo = motivo;
        }
    }
}