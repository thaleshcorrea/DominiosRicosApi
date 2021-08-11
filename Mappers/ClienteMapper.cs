using Teste.Dtos.ClienteDtos;
using Teste.Models;

namespace Teste.Mappers
{
    public static class ClienteMapper
    {
        public static GetClienteDto ClienteToGetClienteDto(Cliente cliente)
        {
            return new GetClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento.Numero,
                Email = cliente.Email.Endereco,
            };
        }
    }
}