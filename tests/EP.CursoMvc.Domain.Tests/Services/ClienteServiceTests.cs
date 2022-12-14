using System;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EP.CursoMvc.Domain.Tests.Services
{
    [TestClass]
    public class ClienteServiceTests
    {
        [TestMethod]
        public void ClienteService_AdicionarCliente_RetornarComSucesso()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Eduardo",
                CPF = "30390600822",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var repo = MockRepository.GenerateStub<IClienteRepository>();
            var clienteService = new ClienteService(repo);

            // Act
            var result = clienteService.Adicionar(cliente);

            // Assert
            Assert.IsTrue(result.ValidationResult.IsValid);
        }
    }
}