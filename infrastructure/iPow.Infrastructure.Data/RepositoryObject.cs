using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using iPow.Domain.Infrastructure;

namespace iPow.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class RepositoryObject<T> :
        iPow.Domain.Infrastructure.IRepository<T> where T : class
    {
        #region Members

        IQueryableUnitOfWork uow;

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        public IUnitOfWork Uow
        {
            get
            {
                return uow;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public RepositoryObject(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            else
            {
                uow = unitOfWork;
            }
        }

        #endregion

        #region repository

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Add(T item)
        {
            if (item != (T)null)
            {
                uow.Add(item);
                //GetObjectSet().AddObject(item); // add new item in this set
            }
            else
            {
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
                    "add object is null " + typeof(T).ToString(), string.Empty, string.Empty);
            }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Delete(T item)
        {
            if (item != (T)null)
            {
                uow.Delete(item);
                //GetObjectSet().DeleteObject(item);
            }
            else
            {
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
                    "delete object is null " + typeof(T).ToString(), string.Empty, string.Empty);
            }
        }

        /// <summary>
        /// Modifies the specified item.
        /// 没有实现这个方法 
        /// 调用的是 uow.SetModified 而 uow没有实现这个方法
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Modify(T item)
        {
            if (item != (T)null)
            {
                uow.Modify(item);
            }
            else
            {
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
                    "modify object " + typeof(T).ToString(), string.Empty, string.Empty);
            }
        }
      
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetList()
        {
            //在这里，就可以不加日志操作了
            //iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
            //        "get all list object " + typeof(T).ToString(), string.Empty, string.Empty);
            return uow.CreateObjectSet<T>().AsQueryable();
        }

        /// <summary>
        /// Alls the matching.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList(Domain.Infrastructure.Specification.ISpecification<T> specification)
        {
            //在这里，就可以不加日志操作了
            //iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
            //        "get list object by specification " + typeof(T).ToString(), string.Empty, string.Empty);
            return uow.CreateObjectSet<T>().Where(specification.SatisfiedBy()).AsQueryable();
        }

        /// <summary>
        /// Gets the paged.
        /// </summary>
        /// <typeparam name="KProperty">The type of the property.</typeparam>
        /// <param name="pi">The pi.</param>
        /// <param name="take">The take.</param>
        /// <param name="orderby">The orderby.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList<KProperty>(int pi, int take, System.Linq.Expressions.Expression<Func<T, KProperty>> orderby, bool ascending)
        {
            //在这里，就可以不加日志操作了
            //iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
            //      "get list object by paged " + typeof(T).ToString(), string.Empty, string.Empty);

            var set = uow.CreateObjectSet<T>();
            pi = (pi - 1) < 0 ? 0 : (pi - 1);
            if (ascending)
            {
                return set.OrderBy(orderby).Skip(pi * take).Take(take).AsQueryable();
            }
            else
            {
                return set.OrderByDescending(orderby).Skip(pi * take).Take(take).AsQueryable();
            }
        }

        /// <summary>
        /// Gets the filtered.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            //在这里，就可以不加日志操作了
            //iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
            //      "get list object by filter " + typeof(T).ToString(), string.Empty, string.Empty);

            return uow.CreateObjectSet<T>().Where(filter).AsQueryable();
        }

        #endregion
    }
}