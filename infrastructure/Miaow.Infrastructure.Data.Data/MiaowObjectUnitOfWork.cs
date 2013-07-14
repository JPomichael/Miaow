using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data
{
    public class MiaowObjectUnitOfWork : IQueryableUnitOfWork
    {
        private string conn = string.Empty;

        private Miaow.Infrastructure.Data.DataSys.MiaowsysEntities db = null;

        public MiaowObjectUnitOfWork()
        {
            conn = System.Configuration.ConfigurationManager.ConnectionStrings["MiaowsysEntities"].ToString();
            db = new DataSys.MiaowsysEntities(conn);
        }

        #region iqueryable unit of work

        public System.Data.Objects.IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return db.CreateObjectSet<T>();
        }

        public void Add<T>(T item) where T : class
        {
            db.AddObject(typeof(T).Name, item);
        }
 
        public void Modify<T>(T item) where T : class
        {
            Commit();
        }

        public void Delete<T>(T item) where T : class
        {
            db.DeleteObject(item);
        }

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        #region isql

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            Miaow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
                    "execute query", "execute query " + sqlQuery, string.Empty);
            return db.ExecuteStoreQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            Miaow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0, string.Empty, string.Empty,
                    "execute command", "execute command " + sqlCommand, string.Empty);
            return db.ExecuteStoreCommand(sqlCommand, parameters);
        }

        #endregion

        #region uow

        public void Commit()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Refresh()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
