using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Interfaces
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterTodosPaginado(int s, int t);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}