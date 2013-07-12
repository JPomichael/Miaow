using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class MvcControllerService : IMvcControllerService
    {
        iPow.Domain.Repository.IMvcControllerRepository controllerRepository;
        iPow.Domain.Repository.IMvcControllerClassRepository controllerClassRepository;

        public MvcControllerService(iPow.Domain.Repository.IMvcControllerRepository controller,
            iPow.Domain.Repository.IMvcControllerClassRepository controllerClass)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controllerRepository is null");
            }
            if (controllerClass == null)
            {
                throw new ArgumentNullException("controllerClassRepository is null");
            }
            controllerRepository = controller;
            controllerClassRepository = controllerClass;
        }

        public void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcController controller)
        {
            controllerRepository.Add(controller);
            controllerRepository.Uow.Commit();
        }

        public void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcController controller)
        {
            controllerRepository.Delete(controller);
            controllerRepository.Uow.Commit();
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
            var data = controllerRepository.GetList(e => userIdList.Contains(e.Id));
            foreach (var item in data)
            {
                controllerRepository.Delete(item);
            }
            var res = false;
            try
            {
                controllerRepository.Uow.Commit();
                res = true;
            }
            catch (Exception ex)
            {
            }
            return res;
        }



        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcController controller)
        {
            controllerRepository.Modify(controller);
            controllerRepository.Uow.Commit();
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcController> GetList()
        {
            var res = controllerRepository.GetList().AsQueryable();
            return res;
        }

        public IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto> GetControllerDtoList()
        {
            var res = controllerRepository.GetList().Select(e => new iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto()
            {
                Id = e.Id,
                AssemblyFullName = e.AssemblyFullName,
                Name = e.Name,
                Remark = e.Remark,
                AddTime = e.AddTime,
                IpAddress = e.IpAddress,
                State = e.State,
                SortNum = e.SortNum,
                ClassName = controllerClassRepository.GetList(d => d.Id == e.ClassId).FirstOrDefault() != null ?
                controllerClassRepository.GetList(d => d.Id == e.ClassId).FirstOrDefault().Name : "暂无分类",
            }).AsQueryable();
            return res;
        }

        public bool ClassNameAndControllerNameHasController(int classId, string name)
        {
            var res = controllerRepository.GetList(e => e.ClassId == classId && e.Name == name).Any();
            return res;
        }

        public iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto GetControllerSingDto(int id)
        {
            var res = controllerRepository.GetList(e => e.Id == id).Select(e =>new iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto()
            {
                Id = e.Id,
                AssemblyFullName = e.AssemblyFullName,
                Name = e.Name,
                Remark = e.Remark,
                AddTime = e.AddTime,
                IpAddress = e.IpAddress,
                State = e.State,
                SortNum = e.SortNum,
                ClassName = controllerClassRepository.GetList(d => d.Id == e.ClassId).FirstOrDefault() != null ?
                controllerClassRepository.GetList(d => d.Id == e.ClassId).FirstOrDefault().Name : "暂无分类",
            }).FirstOrDefault();
            return res;
        }

        public iPow.Infrastructure.Data.DataSys.Sys_MvcController GetControllerSingleById(int id)
        {
            var res = controllerRepository.GetList(e => e.Id == id).FirstOrDefault();
            return res;
        }

    }
}
