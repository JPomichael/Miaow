using System;
using System.Linq;
using System.Linq.Expressions;

namespace iPow.Domain.Infrastructure.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public sealed class NotSpecification<T> : Specification<T> where T : class
    {
        #region Members

        Expression<Func<T, bool>> originalCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for NotSpecificaiton
        /// </summary>
        /// <param name="original">Original specification</param>
        public NotSpecification(ISpecification<T> original)
        {
            if (original == (ISpecification<T>)null)
            {
                throw new ArgumentNullException("originalSpecification");
            }
            else
            {
                originalCriteria = original.SatisfiedBy();
            }
        }

        /// <summary>
        /// Constructor for NotSpecification
        /// </summary>
        /// <param name="originalSpecification">Original specificaiton</param>
        public NotSpecification(Expression<Func<T, bool>> originalSpecification)
        {
            if (originalSpecification == (Expression<Func<T, bool>>)null)
            {
                throw new ArgumentNullException("originalSpecification");
            }
            else
            {
                originalCriteria = originalSpecification;
            }
        }

        #endregion

        #region Override Specification methods

        /// <summary>
        /// Satisfieds the by.
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(originalCriteria.Body),
                                                         originalCriteria.Parameters.Single());
        }

        #endregion
    }
}
