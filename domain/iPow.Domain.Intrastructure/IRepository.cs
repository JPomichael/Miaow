using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using iPow.Domain.Infrastructure.Specification;

namespace iPow.Domain.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        IUnitOfWork Uow { get; }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Add(T item);

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Delete(T item);

        /// <summary>
        /// Modifies the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Modify(T item);

        #region IEnumerable

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetList();

        /// <summary>
        /// Alls the matching.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        IQueryable<T> GetList(iPow.Domain.Infrastructure.Specification.ISpecification<T> specification);

        /// <summary>
        /// Gets the paged.
        /// </summary>
        /// <typeparam name="KProperty">The type of the property.</typeparam>
        /// <param name="pi">The pi.</param>
        /// <param name="take">The take.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns></returns>
        IQueryable<T> GetList<KProperty>(int pi, int take, System.Linq.Expressions.Expression<Func<T, KProperty>> orderby, bool ascending);

        /// <summary>
        /// Gets the filtered.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> filter);

        #endregion
    }
}
