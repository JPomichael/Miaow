using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class AdminUserClassService : IAdminUserClassService
    {

        iPow.Domain.Repository.IAdminUserClassRepository adminUserClassRepository;

        public AdminUserClassService(iPow.Domain.Repository.IAdminUserClassRepository UserClass)
        {
            if (UserClass == null)
            {
                throw new ArgumentNullException("adminUserClassRepository is null");
            }
            adminUserClassRepository = UserClass;
        }

        public void Add(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass adminUserClass, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            adminUserClassRepository.Add(adminUserClass);
            adminUserClassRepository.Uow.Commit();

        }

        public bool NameHasClass(string name)
        {
            var res = adminUserClassRepository.GetList(e => e.Name == name).Any();
            return res;
        }


        public void Delete(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass adminUserClass)
        {
            adminUserClassRepository.Delete(adminUserClass);
            adminUserClassRepository.Uow.Commit();

        }

        public bool Delete(List<int> userIdList)
        {
            var data = adminUserClassRepository.GetList(e => userIdList.Contains(e.Id));
            foreach (var item in data)
            {
                adminUserClassRepository.Delete(item);
            }
            var res = false;
            try
            {
                adminUserClassRepository.Uow.Commit();
                res = true;
            }
            catch (Exception ex)
            {
            }
            return res;
        }
        public bool Delete(List<string> userIdList)
        {
            var idList = new List<int>();
            foreach (var item in userIdList)
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

        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass adminUserClass, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            adminUserClassRepository.Modify(adminUserClass);
            adminUserClassRepository.Uow.Commit();

        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass> GetList()
        {
            var res = adminUserClassRepository.GetList().AsQueryable();
            return res;
        }
    }
}
