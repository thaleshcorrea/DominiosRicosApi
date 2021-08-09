namespace Teste.Models
{
    public class NotaFiscal
    {
        public NotaFiscal(
            int numero, 
            int serie, 
            int modelo, 
            Cliente cliente)
        {
            Numero = numero;
            Serie = serie;
            Modelo = modelo;
            Cliente = cliente;
        }

        public int Id { get; private set; }
        public int Numero { get; private set; }
        public int Serie { get; private set; }
        public int Modelo { get; private set; }
        public int ClienteId { get; private set; }
        public Cliente Cliente { get; set; }
    }
}