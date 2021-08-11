using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Dtos.NotaFiscalDtos;
using Teste.Models;

namespace Teste.Data.Repositories.Contracts
{
    public interface INotaFiscalRepository
    {
        Task<IEnumerable<GetNotaFiscalDto>> GetByCliente(Guid clienteId);
        Task<NotaFiscal> Get(Guid clinteId, int modelo, int serie, int numero);
        void Add(NotaFiscal notaFiscal);
        void Update(NotaFiscal notaFiscal);
    }
}