using System;
using System.Linq;
using EP.CursoMvc.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EP.CursoMvc.Domain.Tests.Moldels
{
    [TestClass]
    public class ClienteTests
    {
        // AAA => Arrange, Act, Assert

        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarTrue()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Eduardo",
                CPF = "30390600822",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980,01,01)
            };

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarFalse()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "E",
                CPF = "30390600821",
                Email = "teste2teste.com",
                DataNascimento = DateTime.Now
            };

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e=>e.Message == "Cliente informou um CPF inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maioridade para cadastro."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "O nome do cliente precisa ter mais de 2 caracteres"));
        }
    }
}