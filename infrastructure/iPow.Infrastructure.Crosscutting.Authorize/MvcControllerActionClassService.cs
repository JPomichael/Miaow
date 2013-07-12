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

        public void Add(Data.DataSys.Sys_MvcControllerActionClass mvcControllerActionClass, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            mvcControllerActionClassRepository.Add(mvcControllerActionClass);
            mvcControllerActionClassRepository.Uow.Commit();
        }

        public void Delete(Data.DataSys.Sys_MvcControllerActionClass mvcControllerActionClass)
        {
            mvcControllerActionClassRepository.Delete(mvcControllerActionClass);
            mvcControllerActionClassRepository.Uow.Commit();
        }

        public bool Delete(List<int> actionIdList)
        {
            var data = mvcControllerActionClassRepository.GetList(e => actionIdList.Contains(e.Id));
            foreach (var item in data)
            {
                mvcControllerActionClassRepository.Delete(item);
            }
            var res = false;
            try
            {
                mvcControllerActionClassRepository.Uow.Commit();
                res = true;
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public bool Delete(List<string> actionIdList)
        {
            var idList = new List<int>();
            foreach (var item in actionIdList)
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

        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass mvcControllerActionClass )
        {
            mvcControllerActionClassRepository.Modify(mvcControllerActionClass);
            mvcControllerActionClassRepository.Uow.Commit();
        }

        public bool NameHasClass(string name)
        {
            var res = mvcControllerActionClassRepository.GetList(e => e.Name == name).Any();
            return res;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> GetList()
        {
            var res = mvcControllerActionClassRepository.GetList().AsQueryable();
            return res;
        }
    }
}
