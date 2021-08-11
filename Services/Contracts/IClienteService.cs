using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Dtos.ClienteDtos;
using Teste.Models;
using Teste.HttpResponses;

namespace Teste.Services.Contracts
{
    public interface IClienteService
    {
        Task<BasicResponse<BasicObject>> Get();
        Task<BasicResponse<BasicObject>> GetById(Guid clienteId);
        Task<BasicResponse<BasicObject>> Add(AddClienteDto addClienteDto);
        Task<BasicResponse<BasicObject>> Update(UpdateClienteDto updateClienteDto);
        Task<BasicResponse<BasicObject>> GetNotasFiscais(Guid clienteId);
    }
}