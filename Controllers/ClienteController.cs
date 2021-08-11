using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Dtos.ClienteDtos;
using Teste.Services.ClienteServices;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _clienteService.Get();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClienteDto addClienteDto)
        {
            var response = await _clienteService.Add(addClienteDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateClienteDto updateClienteDto)
        {
            var response = await _clienteService.Update(updateClienteDto);
            if (response.Error ?? false)
            {
                return StatusCode(response.StatusCode, response);
            }
            else 
            {
                return StatusCode(response.StatusCode);
            }
        }
    }
}