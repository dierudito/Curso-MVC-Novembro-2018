using System.Collections.Generic;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryRead<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
    }
}