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

        public void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass type)
        {
            controllerClassRepository.Add(type);
            controllerClassRepository.Uow.Commit();
        }

        public void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass type)
        {
            controllerClassRepository.Delete(type);
            controllerClassRepository.Uow.Commit();
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

        public bool Delete(List<int> userIdList)
        {
            var data = controllerClassRepository.GetList(e => userIdList.Contains(e.Id));
            foreach (var item in data)
            {
                controllerClassRepository.Delete(item);
            }
            var res = false;
            try
            {
                controllerClassRepository.Uow.Commit();
                res = true;
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass type)
        {
            controllerClassRepository.Modify(type);
            controllerClassRepository.Uow.Commit();
        }

        /// <summary>
        /// 检查是否已经存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool NameAndRemarkHasClass(string name, string remark)
        {
            var res = controllerClassRepository.GetList(e => e.Name == name && e.Remark==remark).Any();
            return res;
        }

        public Sys_MvcControllerClass GetClassModelById(int id)
        {
            return controllerClassRepository.GetList(d => d.Id == id).FirstOrDefault();
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> GetList()
        {
            var res = controllerClassRepository.GetList().AsQueryable();
            return res;
        }

    }
}
