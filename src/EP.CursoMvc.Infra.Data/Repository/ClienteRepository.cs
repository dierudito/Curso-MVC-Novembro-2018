using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Infra.Data.Context;

namespace EP.CursoMvc.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CursoMvcContext context) : base(context){}

        public IEnumerable<Cliente> ObterAtivos()
        {
            const string sql = @"SELECT * FROM Clientes c " +
                               "WHERE c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override Cliente ObterPorId(Guid id)
        {
            //throw new Exception("THE TRETA HAS BEEN PLANTED!!!!");

            const string sql = @"SELECT * FROM Clientes c " +
                               "LEFT JOIN Enderecos e " +
                               "ON c.Id = e.ClienteId " +
                               "WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                (c,e) =>
                {
                    c.AdicionarEndereco(e);
                    return c;
                }, new {uid = id}).FirstOrDefault();

            //return Db.Clientes.AsNoTracking().Include("Enderecos").FirstOrDefault(c => c.Id == id);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();

            Atualizar(cliente);
        }
    }
}