using System;
using System.Linq.Expressions;

namespace iPow.Domain.Infrastructure.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public sealed class TrueSpecification<TEntity>:Specification<TEntity>where TEntity:class
    {
        #region Specification overrides

        /// <summary>
        /// Satisfieds the by.
        /// </summary>
        /// <returns></returns>
        public override System.Linq.Expressions.Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            bool result = true;
            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
