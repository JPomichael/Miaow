using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Infrastructure.Data.DataSys;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class MvcControllerClassService : IMvcControllerClassService
    {
        iPow.Domain.Repository.IMvcControllerClassRepository controllerClassRepository;

        public MvcControllerClassService(iPow.Domain.Repository.IMvcControllerClassRepository controllerClass)
        {
            if (controllerClass == null)
            {
                throw new ArgumentNullException("controllerClassService is null");
            }
            controllerClassRepository = controllerClass;
        }

        public bool Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    controllerClassRepository.Add(entity);
                    controllerClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            controllerClassRepository.Add(item);
                        }
                    }
                    controllerClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    entity.State = false;
                    controllerClassRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            item.State = false;
                            controllerClassRepository.Modify(item);
                        }
                    }
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = controllerClassRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = Delete(delete, operUser);
                }
            }
            return res;
        }

        public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    controllerClassRepository.Delete(entity);
                    controllerClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            controllerClassRepository.Delete(item);
                        }
                    }
                    controllerClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }


        public bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = controllerClassRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    controllerClassRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            controllerClassRepository.Modify(item);
                        }
                    }
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public Sys_MvcControllerClass Get(int Id)
        {
            var data = controllerClassRepository.GetList(e => e.Id == Id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> GetList()
        {
            var res = controllerClassRepository.GetList().AsQueryable();
            return res;
        }

        public Sys_MvcControllerClass GetClassModelById(int id)
        {
            return controllerClassRepository.GetList(d => d.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// 检查是否已经存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool NameAndRemarkHasClass(string name, string remark)
        {
            var res = controllerClassRepository.GetList(e => e.Name == name && e.Remark == remark).Any();
            return res;
        }
    }
}
