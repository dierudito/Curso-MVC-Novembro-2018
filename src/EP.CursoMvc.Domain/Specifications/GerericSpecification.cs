using System;
using System.Linq.Expressions;
using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Specifications
{
    public class GenericSpecification<T> : ISpecification<T> where T : Entity
    {
        public Expression<Func<T, bool>> Expression { get; }

        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }

    }
}