using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Repositories.NotaFiscalRepositories
{
    public interface INotaFiscalRepository
    {
        Task<bool> CheckIfExists(int modelo, int serie, int numero);
        Task<IEnumerable<NotaFiscal>> Get();
        void Add(NotaFiscal notaFiscal);
        void Update(NotaFiscal notaFiscal);
        void Delete(Guid Id);
    }
}