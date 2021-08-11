using Microsoft.AspNetCore.Mvc;
using Teste.Dtos.NFE_notaDtos;
using Teste.Services.NotaFiscalServices;

namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalService _notaFiscalService;
        public NotaFiscalController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }
    }
}