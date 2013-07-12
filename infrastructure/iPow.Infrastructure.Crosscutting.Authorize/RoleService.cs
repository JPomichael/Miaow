using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class RoleService : IRoleService
    {
        iPow.Domain.Repository.IRolesRepository roleRespoitory;

        public RoleService(iPow.Domain.Repository.IRolesRepository role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("roleRespoitory is null");
            }
            roleRespoitory = role;
        }

        public void Add(iPow.Infrastructure.Data.DataSys.Sys_Roles role)
        {
            roleRespoitory.Add(role);
            roleRespoitory.Uow.Commit();
        }

        public void Delete(iPow.Infrastructure.Data.DataSys.Sys_Roles role)
        {
            roleRespoitory.Delete(role);
            roleRespoitory.Uow.Commit();
        }

        public bool Delete(List<int> roleIdList)
        {
            var deleteModel = roleRespoitory.GetList(e => roleIdList.Contains(e.Id));
            foreach (var item in deleteModel)
            {
                roleRespoitory.Delete(item);
            }
            var res = false;
            try
            {
                roleRespoitory.Uow.Commit();
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public bool Delete(List<string> roleIdList)
        {
            var idList = new List<int>();
            foreach (var item in roleIdList)
            {
                var id = -1;
                int.TryParse(item, out id);
                if (id > 0)
                {
                    idList.Add(id);
                }
            }
            return Delete(idList);
        }


        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_Roles role)
        {
            roleRespoitory.Modify(role);
            roleRespoitory.Uow.Commit();
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_Roles> GetList()
        {
            var res = roleRespoitory.GetList().AsQueryable();
            return res;
        }

        public int GetNewRoleId()
        {
            var res = roleRespoitory.GetList().Max(e => e.RoleID) + 1;
            return res;
        }

        public Data.DataSys.Sys_Roles GetRoleById(int id)
        {
            var model = roleRespoitory.GetList(e => e.Id == id).FirstOrDefault() ;
            return model;
        }
    }
}
