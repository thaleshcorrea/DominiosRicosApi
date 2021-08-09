using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Dtos.NFE_notaDtos;

namespace Teste.Services.NFE_notaServices
{
    public interface INFE_notaService
    {
        Task<IEnumerable<GetNFE_notaDto>> GetAll();

        Task Update(UpdateNFE_notaDto updateNFE_NotaDto);

        Task Insert(InsertNFE_notaDto insertNFE_NotaDto);
    }
}