using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Dtos.ClienteDtos;
using Teste.Models;

namespace Teste.Repositories.ClienteRepositories
{
    public interface IClienteRepository
    {
        Task<bool> CheckCpfCnpj(string documento);
        Task<IEnumerable<GetClienteDto>> Get();
        Task<Cliente> GetById(Guid id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Guid Id);
    }
}