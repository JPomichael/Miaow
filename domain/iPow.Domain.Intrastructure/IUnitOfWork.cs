using System;

namespace iPow.Domain.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

        /// <summary>
        /// Commits the and refresh changes.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Rollbacks the changes.
        /// </summary>
        void Rollback();
    }
}
