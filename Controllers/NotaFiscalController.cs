using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Dtos.NotaFiscalDtos;
using Teste.Services.Contracts;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/notas_fiscais")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalService _notaFiscalService;
        public NotaFiscalController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpPut]
        public async Task<IActionResult> Save(SaveNotaFiscalDto saveNotaFiscalDto)
        {
            var response = await _notaFiscalService.Save(saveNotaFiscalDto);
            return StatusCode(response.StatusCode, response);
        }
    }
}