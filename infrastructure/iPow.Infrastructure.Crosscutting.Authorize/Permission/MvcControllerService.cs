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

        public bool Add(iPow.Infrastructure.Data.DataSys.Sys_MvcController entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    controllerRepository.Add(entity);
                    controllerRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity.Count > 0 && entity != null)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null)
                        {
                            controllerRepository.Add(item);
                        }
                    }
                    controllerRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(Data.DataSys.Sys_MvcController entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    entity.State = false;
                    controllerRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<Data.DataSys.Sys_MvcController> entity, Data.DataSys.Sys_AdminUser operUser)
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
                            controllerRepository.Modify(item);
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
                var delete = controllerRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = Delete(delete, operUser);
                }
            }
            return res;
        }

        public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_MvcController entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    controllerRepository.Delete(entity);
                    controllerRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            controllerRepository.Delete(item);
                        }
                    }
                    controllerRepository.Uow.Commit();
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
                var delete = controllerRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = DeleteTrue(delete , operUser);
                }
            }
            return res;
        }

        public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcController entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    controllerRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            controllerRepository.Modify(item);
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

        public Data.DataSys.Sys_MvcController Get(int Id)
        {
            var data = controllerRepository.GetList(e => e.Id == Id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcController> GetList()
        {
            var res = controllerRepository.GetList().AsQueryable();
            return res;
        }

        public iPow.Infrastructure.Data.DataSys.Sys_MvcController GetControllerSingleById(int id)
        {
            var res = controllerRepository.GetList(e => e.Id == id).FirstOrDefault();
            return res;
        }

        public iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto GetControllerSingDto(int id)
        {
            var res = controllerRepository.GetList(e => e.Id == id).Select(e => new iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto()
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

    }
}
