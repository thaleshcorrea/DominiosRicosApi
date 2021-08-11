using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Dtos.ClienteDtos;
using Teste.Models;
using Teste.Wrappers;

namespace Teste.Services.ClienteServices
{
    public interface IClienteService
    {
        Task<BasicResponse<BasicObject>> Get();
        Task<BasicResponse<BasicObject>> Add(AddClienteDto addClienteDto);
        Task<BasicResponse<BasicObject>> Update(UpdateClienteDto updateClienteDto);
    }
}