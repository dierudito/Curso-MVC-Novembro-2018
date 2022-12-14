using DomainValidation.Validation;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Specifications;
using EP.CursoMvc.Domain.Specifications.Clientes;
using EP.CursoMvc.Domain.Value_Objects;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            //var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeSpecification();
            var clienteNomeCurto = new GenericSpecification<Cliente>(c => c.Nome.Length >= 2);
            var clienteEmailVazio = new GenericSpecification<Cliente>(c => !string.IsNullOrWhiteSpace(c.Email));
            var CPFCliente = new GenericSpecification<Cliente>(c => CPF.Validar(c.CPF));

            Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
            Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido."));
            Add("clienteMaioridade", new Rule<Cliente>(clienteMaioridade, "Cliente não tem maioridade para cadastro."));
            Add("clienteNomeCurto", new Rule<Cliente>(clienteNomeCurto, "O nome do cliente precisa ter mais de 2 caracteres"));
            Add("clienteEmailVazio", new Rule<Cliente>(clienteEmailVazio, "O e-mail não pode estar em branco"));
        }
    }
}