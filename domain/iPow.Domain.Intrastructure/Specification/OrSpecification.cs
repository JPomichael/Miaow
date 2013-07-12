using System;
using System.Linq.Expressions;

namespace iPow.Domain.Infrastructure.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class OrSpecification<T> : CompositeSpecification<T> where T : class
    {
        #region Members

        private ISpecification<T> rightSpecification = null;
        private ISpecification<T> leftSpecification = null;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default constructor for AndSpecification
        /// </summary>
        /// <param name="leftSide">Left side specification</param>
        /// <param name="rightSide">Right side specification</param>
        public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == (ISpecification<T>)null)
            {
                throw new ArgumentNullException("leftSide");
            }
            if (rightSide == (ISpecification<T>)null)
            {
                throw new ArgumentNullException("rightSide");
            }
            this.leftSpecification = leftSide;
            this.rightSpecification = rightSide;
        }

        #endregion

        #region Composite Specification overrides

        /// <summary>
        /// Left side specification
        /// </summary>
        public override ISpecification<T> LeftSideSpecification
        {
            get { return leftSpecification; }
        }

        /// <summary>
        /// Righ side specification
        /// </summary>
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
            return (left.Or(right));
        }

        #endregion
    }
}
