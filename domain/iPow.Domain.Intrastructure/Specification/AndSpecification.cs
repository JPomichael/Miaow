using System;
using System.Linq.Expressions;

namespace iPow.Domain.Infrastructure.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class AndSpecification<T> : CompositeSpecification<T> where T : class
    {
        #region Members

        private ISpecification<T> rightSpecification = null;
        private ISpecification<T> leftSpecification = null;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default constructor for AndSpecification
        /// </summary>
        /// <param name="left">Left side specification</param>
        /// <param name="right">Right side specification</param>
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            if (left == (ISpecification<T>)null)
            {
                throw new ArgumentNullException("leftSide");
            }
            if (right == (ISpecification<T>)null)
            {
                throw new ArgumentNullException("rightSide");
            }
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        #endregion

        #region Composite Specification overrides

        /// <summary>
        /// Gets the left side specification.
        /// </summary>
        /// <value>The left side specification.</value>
        public override ISpecification<T> LeftSideSpecification
        {
            get { return leftSpecification; }
        }

        /// <summary>
        /// Gets the right side specification.
        /// </summary>
        /// <value>The right side specification.</value>
        public override ISpecification<T> RightSideSpecification
        {
            get { return rightSpecification; }
        }

        /// <summary>
        /// Satisfieds the by.
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = leftSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = rightSpecification.SatisfiedBy();
            return (left.And(right));
        }

        #endregion
    }
}
