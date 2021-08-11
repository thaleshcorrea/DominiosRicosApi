using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Data.Context;
using Teste.Dtos.ClienteDtos;
using Teste.Models;

namespace Teste.Repositories.ClienteRepositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public async Task<bool> CheckCpfCnpj(string documento)
        {
            return await _context.Clientes
                .AnyAsync(x => x.Documento.Numero.Equals(documento));
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetClienteDto>> Get()
        {
            return await _context.Clientes.AsNoTracking()
                .Select(x => new GetClienteDto{
                    Id = x.Id,
                    Nome = x.Nome,
                    Documento = x.Documento.Numero,
                    Email = x.Email.Endereco
                })
                .ToListAsync();
        }

        public async Task<Cliente> GetById(Guid id)
        {
            return await _context.Clientes.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }
    }
}