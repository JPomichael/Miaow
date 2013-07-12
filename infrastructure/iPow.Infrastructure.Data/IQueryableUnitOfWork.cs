using System.Data.Entity;

using iPow.Domain.Infrastructure;

namespace iPow.Infrastructure.Data
{
    /// <summary>
    /// The UnitOfWork contract for EF implementation
    /// <remarks>
    /// This contract extend IUnitOfWork for use with EF code
    /// </remarks>
    /// </summary>
    public interface IQueryableUnitOfWork :
        iPow.Domain.Infrastructure.IUnitOfWork,
        iPow.Infrastructure.Data.ISql
    {

        /// <summary>
        /// Creates the object set.
        /// 系统自成的EF
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        System.Data.Objects.IObjectSet<T> CreateObjectSet<T>() where T : class;


        /// <summary>
        /// Attach this item into "ObjectStateManager"
        /// </summary>
        /// <typeparam name="TValueObject">The type of entity</typeparam>
        /// <param name="item">The item <</param>
        void Add<T>(T item) where T : class;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam name="TValueObject">The type of entity</typeparam>
        /// <param name="item">The entity item to set as modifed</param>
        void Modify<T>(T item) where T : class;

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Delete<T>(T item) where T : class;
    }
}
