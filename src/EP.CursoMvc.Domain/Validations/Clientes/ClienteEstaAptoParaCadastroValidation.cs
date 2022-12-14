using DomainValidation.Validation;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Specifications.Clientes;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteEstaAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteUnicoCpf = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var clienteUnicoEmail = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("clienteUnicoCpf", new Rule<Cliente>(clienteUnicoCpf, "Já existe um cliente com este CPF"));
            base.Add("clienteUnicoEmail", new Rule<Cliente>(clienteUnicoEmail, "Já existe um cliente com este E-mail"));
        }
    }
}