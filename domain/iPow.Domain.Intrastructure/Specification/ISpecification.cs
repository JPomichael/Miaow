using System;
using System.Linq.Expressions;

namespace iPow.Domain.Infrastructure.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T> where T : class
    {
        /// <summary>
        /// Satisfieds the by.
        /// </summary>
        /// <returns></returns>
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
