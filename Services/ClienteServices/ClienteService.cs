using System;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using Teste.Data;
using Teste.Dtos.ClienteDtos;
using Teste.Models;
using Teste.Repositories.ClienteRepositories;
using Teste.ValueObjects;
using Teste.Wrappers;

namespace Teste.Services.ClienteServices
{
    public class ClienteService : Notifiable<Notification>, IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;
        private BasicObject response = null;

        public ClienteService(
            IUnitOfWork unitOfWork,
            IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BasicResponse<BasicObject>> Add(AddClienteDto addClienteDto)
        {
            addClienteDto.Validate();
            if (!addClienteDto.IsValid)
            {
                response = new("Dados do cliente invalidos", addClienteDto.Notifications);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status400BadRequest, true);
            }

            // Verificar se documento já está cadastrado
            AddNotifications(
                new Contract<ClienteService>()
                    .Requires()
                    .IsFalse(await _clienteRepository.CheckCpfCnpj(addClienteDto.Documento), "Documento", "Documento já cadastrado")
            );

            // Criar vos
            Documento documento = new(addClienteDto.Documento);
            Email email = new(addClienteDto.Email);

            // Criar cliente
            Cliente cliente = new(addClienteDto.Nome, documento, email);

            // Agrupar notificaçoes
            AddNotifications(documento, email);
            if (!IsValid)
            {
                response = new("Não foi possivel inserir o cliente", Notifications);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status400BadRequest, true);
            }

            _clienteRepository.Add(cliente);

            try
            {
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                response = new(ex.Message, null);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status500InternalServerError);
            }

            response = new("Cliente adicionado com sucesso", cliente.Id);
            return new BasicResponse<BasicObject>(response, StatusCodes.Status201Created);
        }

        public async Task<BasicResponse<BasicObject>> Get()
        {
            var clientes = await _clienteRepository.Get();
            response = new BasicObject("Listagem de clientes", clientes);
            return new BasicResponse<BasicObject>(response);
        }

        public async Task<BasicResponse<BasicObject>> Update(UpdateClienteDto updateClienteDto)
        {
            updateClienteDto.Validate();
            if (!updateClienteDto.IsValid)
            {
                response = new("Dados do cliente invalidos", updateClienteDto.Notifications);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status400BadRequest, true);
            }

            // Buscar cliente no banco
            Cliente cliente = await _clienteRepository.GetById(updateClienteDto.Id);
            // Verificar se o cliente informado foi encontrado ou nao
            if(cliente is null)
            {
                response = new BasicObject("Cliente não econtrado", null);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status404NotFound, true);
            }

            // Atualizar informaçoes
            cliente.AlterarNome(updateClienteDto.Nome);
            cliente.AlterarEmail(updateClienteDto.Email);

            // Agrupar notificaçoes
            AddNotifications(cliente.Email);
            if (!IsValid)
            {
                response = new("Não foi possivel inserir o cliente", Notifications);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status400BadRequest);
            }

            _clienteRepository.Update(cliente);

            try
            {
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                response = new(ex.Message, null);
                return new BasicResponse<BasicObject>(response, StatusCodes.Status500InternalServerError);
            }

            response = new("Cliente alterado com sucesso", null);
            return new BasicResponse<BasicObject>(response, StatusCodes.Status204NoContent);
        }
    }
}