using System;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EP.CursoMvc.Domain.Tests.Specifications
{
    [TestClass]
    public class CpfSpecificationTests
    {
        [TestMethod]
        public void CpfSpecification_Valido_True()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Eduardo",
                CPF = "30390600822",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var cpfSpec = new ClienteDeveTerCpfValidoSpecification();

            // Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CpfSpecification_Valido_False()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Eduardo",
                CPF = "30390600821",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var cpfSpec = new ClienteDeveTerCpfValidoSpecification();

            // Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            // Assert
            Assert.IsFalse(result);
        }
    }
}