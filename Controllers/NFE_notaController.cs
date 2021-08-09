using Microsoft.AspNetCore.Mvc;
using Teste.Dtos.NFE_notaDtos;

namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NFE_notaController : ControllerBase
    {
        public NFE_notaController()
        {
            
        }

        [HttpPut]
        public IActionResult Update(UpdateNFE_notaDto updateNFE_NotaDto)
        {
            return Ok();
        }
    }
}