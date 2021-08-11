using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste.Data.Context;
using Teste.Data.Repositories.Contracts;
using Teste.Dtos.NotaFiscalDtos;
using Teste.Mappers;
using Teste.Models;

namespace Teste.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly DataContext _context;
        public NotaFiscalRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Add(notaFiscal);
        }

        public async Task<NotaFiscal> Get(Guid clienteId, int modelo, int serie, int numero)
        {
            return await _context.NotasFiscais.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClienteId == clienteId
                    && x.Modelo == modelo
                    && x.Numero == numero
                    && x.Serie == serie);
        }

        public async Task<IEnumerable<GetNotaFiscalDto>> GetByCliente(Guid clienteId)
        {
            return await _context.NotasFiscais.AsNoTracking()
                .Where(x => x.ClienteId == clienteId)
                .Select(x => new GetNotaFiscalDto
                {
                    Id = x.Id,
                    Modelo = x.Modelo,
                    Serie = x.Serie,
                    Numero = x.Numero,
                    DataEmissao = x.DataEmissao,
                    Status = x.Status,
                    Motivo = x.Motivo,
                    ClienteId = x.ClienteId,
                    ClienteNome = x.Cliente.Nome,
                })
                .OrderBy(x => x.DataEmissao)
                .OrderBy(x => x.Numero)
                .ToListAsync();
        }

        public void Update(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Update(notaFiscal);
        }
    }
}