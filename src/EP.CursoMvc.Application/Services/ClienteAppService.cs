using System;
using System.Collections.Generic;
using AutoMapper;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Application.Services
{
    public class ClienteAppService : AppServiceBase, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteRepository clienteRepository, 
                                 IClienteService clienteService,
                                 IUnitOfWork uow) : base(uow)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.DefinirComoAtivo();
            cliente.AdicionarEndereco(endereco);

            var clienteReturn = _clienteService.Adicionar(cliente);

            //BeginTransaction();
            //// blablablabalbla
            //try
            //{
            //    Commit();
            //}
            //catch (Exception)
            //{
            //    Rollback();
            //}

            if (clienteReturn.ValidationResult.IsValid)
            {
                if (!SaveChanges())
                {
                    AdicionarErrosValidacao(cliente.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco.");
                }
            }

            clienteEnderecoViewModel.Cliente.ValidationResult = clienteReturn.ValidationResult;
            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            if (!cliente.EhValido()) return clienteViewModel;

            var clienteReturn = _clienteService.Atualizar(cliente);

            if (clienteReturn.ValidationResult.IsValid)
            {
                if (!SaveChanges())
                {
                    AdicionarErrosValidacao(cliente.ValidationResult, "Ocorreu um erro no momento de salvar os dados no banco.");
                }
            }

            clienteViewModel.ValidationResult = clienteReturn.ValidationResult;
            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}