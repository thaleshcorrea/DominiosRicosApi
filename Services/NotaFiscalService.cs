using System;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Teste.Data;
using Teste.Data.Repositories.Contracts;
using Teste.Dtos.NotaFiscalDtos;
using Teste.HttpResponses;
using Teste.Models;
using Teste.Services.Contracts;

namespace Teste.Services
{
    public class NotaFiscalService : Notifiable<Notification>, INotaFiscalService
    {
        private BasicObject response = null;
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public NotaFiscalService(
            INotaFiscalRepository notaFiscalRepository, 
            IClienteRepository clienteRepository,
            IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<BasicResponse<BasicObject>> GetByCliente(Guid clienteId)
        {
            var notasFiscais = await _notaFiscalRepository.GetByCliente(clienteId);
            response = new BasicObject("Notas fiscais por cliente", notasFiscais);
            return new BasicResponse<BasicObject>(response);
        }

        public async Task<BasicResponse<BasicObject>> Save(SaveNotaFiscalDto notaFiscalDto)
        {
            // validar informacoes da requisicao
            notaFiscalDto.Validate();
            if (!notaFiscalDto.IsValid)
            {
                response = new BasicObject("Valores informados inválidos", notaFiscalDto.Notifications);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status400BadRequest);
            }

            // Verificar se o cliente informado existe
            Cliente cliente = await _clienteRepository.GetById(notaFiscalDto.ClienteId);
            if (cliente is null)
            {
                response = new BasicObject("Cliente não encontrado.", null);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status400BadRequest);
            }

            NotaFiscal notaFiscal = await _notaFiscalRepository
                .Get(notaFiscalDto.ClienteId, notaFiscalDto.Modelo, notaFiscalDto.Serie, notaFiscalDto.Numero);
            if (notaFiscal is null) // insere a nota se nao existir
            {
                notaFiscal = AddNotaFiscal(notaFiscalDto, cliente);
            }
            else // altera as informacoes da nota se ja existir
            {
                notaFiscal.UpdateDataEmissao(notaFiscalDto.DataEmissao);
                notaFiscal.UpdateStatus(notaFiscalDto.Status);
                notaFiscal.UpdateMotivo(notaFiscalDto.Motivo);
                _notaFiscalRepository.Update(notaFiscal);
            }
            await _unitOfWork.Commit();

            response = new BasicObject("Nota fiscal salva com sucesso", notaFiscal);
            return new BasicResponse<BasicObject>(response);
        }

        private NotaFiscal AddNotaFiscal(SaveNotaFiscalDto notaFiscalDto, Cliente cliente)
        {
            NotaFiscal notaFiscal = new(
                  notaFiscalDto.Numero,
                  notaFiscalDto.Serie,
                  notaFiscalDto.Modelo,
                  notaFiscalDto.DataEmissao,
                  notaFiscalDto.Status,
                  notaFiscalDto.Motivo,
                  cliente.Id);
            _notaFiscalRepository.Add(notaFiscal);
            return notaFiscal;
        }
    }
}