using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class AdminUserClassService : IAdminUserClassService
    {
        iPow.Domain.Repository.IAdminUserClassRepository adminUserClassRepository;

        public AdminUserClassService(iPow.Domain.Repository.IAdminUserClassRepository userClass)
        {
            if (userClass == null)
            {
                throw new ArgumentNullException("adminUserClassRepository is null");
            }
            adminUserClassRepository = userClass;
        }

        public bool Add(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass enitty, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (enitty != null)
            {
                try
                {
                    adminUserClassRepository.Add(enitty);
                    adminUserClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<Data.DataSys.Sys_AdminUserClass> entity, Data.DataSys.Sys_AdminUser operUser)
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
                            adminUserClassRepository.Add(item);
                        }
                    }
                    adminUserClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    entity.State = false;
                    adminUserClassRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<Data.DataSys.Sys_AdminUserClass> entity, Data.DataSys.Sys_AdminUser operUser)
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
                            adminUserClassRepository.Modify(item);
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
                var data = adminUserClassRepository.GetList(e => idList.Contains(e.Id));
                try
                {
                    foreach (var item in data)
                    {
                        if (item != null)
                        {
                            item.State = false;
                            adminUserClassRepository.Modify(item);
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

        public bool DeleteTrue(Data.DataSys.Sys_AdminUserClass entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    adminUserClassRepository.Delete(entity);
                    adminUserClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<Data.DataSys.Sys_AdminUserClass> entity, Data.DataSys.Sys_AdminUser operUser)
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
                            adminUserClassRepository.Delete(item);
                        }
                    }
                    adminUserClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<int> idList, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = adminUserClassRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if(delete != null &&delete.Count >  0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        public bool Modify(Data.DataSys.Sys_AdminUserClass entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    adminUserClassRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<Data.DataSys.Sys_AdminUserClass> entity, Data.DataSys.Sys_AdminUser operUser)
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
                            adminUserClassRepository.Modify(item);
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

        public Data.DataSys.Sys_AdminUserClass Get(int id)
        {
            var data = adminUserClassRepository.GetList(e => e.Id == id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass> GetList()
        {
            var res = adminUserClassRepository.GetList().AsQueryable();
            return res;
        }

        public bool NameHasClass(string name)
        {
            var res = adminUserClassRepository.GetList(e => e.Name == name).Any();
            return res;
        }
    }
}
