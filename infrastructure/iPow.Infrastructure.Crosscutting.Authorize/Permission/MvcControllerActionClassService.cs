using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class MvcControllerActionClassService : IMvcControllerActionClassService
    {
        iPow.Domain.Repository.IMvcControllerActionClassRepository mvcControllerActionClassRepository;

        public MvcControllerActionClassService(iPow.Domain.Repository.IMvcControllerActionClassRepository mvcControllerActionClass)
        {
            if (mvcControllerActionClass == null)
            {
                throw new ArgumentNullException(" mvcControllerActionClassRepository is null");
            }
            mvcControllerActionClassRepository = mvcControllerActionClass;
        }

        public bool Add(Data.DataSys.Sys_MvcControllerActionClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    mvcControllerActionClassRepository.Add(entity);
                    mvcControllerActionClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<Data.DataSys.Sys_MvcControllerActionClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            mvcControllerActionClassRepository.Add(item);
                        }
                    }
                    mvcControllerActionClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(Data.DataSys.Sys_MvcControllerActionClass entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    entity.State = false;
                    mvcControllerActionClassRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<Data.DataSys.Sys_MvcControllerActionClass> entity, Data.DataSys.Sys_AdminUser operUser)
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
                            mvcControllerActionClassRepository.Modify(item);
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

        public bool Delete(IList<int> idList, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = mvcControllerActionClassRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = Delete(delete, operUser);
                }
            }
            return res;
        }


        public bool DeleteTrue(Data.DataSys.Sys_MvcControllerActionClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    mvcControllerActionClassRepository.Delete(entity);
                    mvcControllerActionClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<Data.DataSys.Sys_MvcControllerActionClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            mvcControllerActionClassRepository.Delete(item);
                        }
                    }
                    mvcControllerActionClassRepository.Uow.Commit();
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
                var delete = mvcControllerActionClassRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    mvcControllerActionClassRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            mvcControllerActionClassRepository.Modify(item);
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

        public Data.DataSys.Sys_MvcControllerActionClass Get(int Id)
        {
            var data = mvcControllerActionClassRepository.GetList(e => e.Id == Id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> GetList()
        {
            var res = mvcControllerActionClassRepository.GetList().AsQueryable();
            return res;
        }


        public bool NameHasClass(string name)
        {
            var res = mvcControllerActionClassRepository.GetList(e => e.Name == name).Any();
            return res;
        }
    }
}
