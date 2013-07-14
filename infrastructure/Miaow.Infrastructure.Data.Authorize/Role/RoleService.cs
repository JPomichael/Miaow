using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Authorize
{
    public class RoleService : IRoleService
    {
        Miaow.Domain.Repository.IRolesRepository roleRespoitory;

        public RoleService(Miaow.Domain.Repository.IRolesRepository role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("roleRespoitory is null");
            }
            roleRespoitory = role;
        }

        public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_Roles entity, 
            Miaow.Infrastructure.Data.DataSys.sys_administrator operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    roleRespoitory.Add(entity);
                    roleRespoitory.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_Roles> entity,
            Miaow.Infrastructure.Data.DataSys.sys_administrator operUser)
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
                            roleRespoitory.Add(item);
                        }
                    }
                    roleRespoitory.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(Data.DataSys.Sys_Roles entity, Data.DataSys.sys_administrator operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<Data.DataSys.Sys_Roles> entity, Data.DataSys.sys_administrator operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<int> idList, Data.DataSys.sys_administrator operUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_Roles entity, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    roleRespoitory.Delete(entity);
                    roleRespoitory.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_Roles> entity, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser)
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
                            roleRespoitory.Delete(item);
                        }
                    }
                    roleRespoitory.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = roleRespoitory.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_Roles entity, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    roleRespoitory.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<Data.DataSys.Sys_Roles> entity, Data.DataSys.sys_administrator operUser)
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
                            roleRespoitory.Modify(item);
                        }
                    }
                    res = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return res;
        }

        public Data.DataSys.Sys_Roles Get(int id)
        {
            var model = roleRespoitory.GetList(e => e.Id == id).FirstOrDefault();
            return model;
        }

        public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_Roles> GetList()
        {
            var res = roleRespoitory.GetList().AsQueryable();
            return res;
        }

        public int GetNewRoleId()
        {
            var res = roleRespoitory.GetList().Max(e => e.RoleID) + 1;
            return res;
        }
    }
}
