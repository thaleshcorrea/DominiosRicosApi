using System;
using System.Threading.Tasks;
using Teste.Dtos.NotaFiscalDtos;
using Teste.HttpResponses;

namespace Teste.Services.Contracts
{
    public interface INotaFiscalService
    {
        Task<BasicResponse<BasicObject>> GetByCliente(Guid clienteId);
        Task<BasicResponse<BasicObject>> Save(SaveNotaFiscalDto notaFiscalDto);
    }
}