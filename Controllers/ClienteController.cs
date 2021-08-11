using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Dtos.ClienteDtos;
using Teste.Services.Contracts;

namespace Teste.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly INotaFiscalService _notaFiscalService;
        public ClienteController(IClienteService clienteService, INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _clienteService.Get();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("{clienteId}")]
        public async Task<IActionResult> GetById(Guid clienteId)
        {
            var response = await _clienteService.GetById(clienteId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("{clienteId}/notas_fiscais")]
        public async Task<IActionResult> GetNotaFiscalByCliente(Guid clienteId)
        {
            var response = await _clienteService.GetNotasFiscais(clienteId);
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