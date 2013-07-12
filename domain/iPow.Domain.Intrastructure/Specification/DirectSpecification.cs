using System;
using System.Linq.Expressions;

namespace iPow.Domain.Infrastructure.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public sealed class DirectSpecification<T>: Specification<T> where T : class
    {
        #region Members

        Expression<Func<T, bool>> matchingCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor for Direct Specification
        /// </summary>
        /// <param name="matching">A Matching Criteria</param>
        public DirectSpecification(Expression<Func<T, bool>> matching)
        {
            if (matching == (Expression<Func<T, bool>>)null)
            {
                throw new ArgumentNullException("matchingCriteria");
            }
            else
            {
                matchingCriteria = matching;
            }
        }

        #endregion

        #region Override

        /// <summary>
        /// Satisfieds the by.
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            return matchingCriteria;
        }

        #endregion
    }
}
