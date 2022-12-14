using EP.CursoMvc.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EP.CursoMvc.Domain.Tests.ValueObjects
{
    [TestClass]
    public class CPFValidation
    {
        [TestMethod]
        public void CPF_Valido_True()
        {
            // Arrange
            var CPFTest = "30390600822";

            // Act
            var result = CPF.Validar(CPFTest);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("303.906.008-22")]
        [DataRow("30390600821")]
        [DataRow("11111111111")]
        [DataRow("111111111")]
        [DataRow("11111111111111")]
        public void CPF_Valido_False(string cpf)
        {
            // Act
            var result = CPF.Validar(cpf);

            // Assert
            Assert.IsFalse(result);
        }
    }
}