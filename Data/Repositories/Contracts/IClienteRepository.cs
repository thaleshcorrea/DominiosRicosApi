using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Dtos.ClienteDtos;
using Teste.Models;

namespace Teste.Data.Repositories.Contracts
{
    public interface IClienteRepository
    {
        Task<bool> CheckCpfCnpj(string documento);
        Task<IEnumerable<GetClienteDto>> Get();
        Task<GetClienteNotasFiscaisDto> GetNotasFiscais(Guid clienteId);
        Task<Cliente> GetById(Guid id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
    }
}