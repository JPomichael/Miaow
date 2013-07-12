using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class MvcActionService : IMvcActionService
    {
        iPow.Domain.Repository.IMvcControllerActionRepository actionRepository;

        iPow.Domain.Repository.IMvcControllerRepository controllerRepository;

        public MvcActionService(iPow.Domain.Repository.IMvcControllerActionRepository action,
            iPow.Domain.Repository.IMvcControllerRepository controller)
        {
            if (action == null)
            {
                throw new ArgumentNullException("actionRepository is null");
            }
            if (controller == null)
            {
                throw new ArgumentNullException("controllerRepository is null");
            }
            actionRepository = action;
            controllerRepository = controller;
        }

        public bool Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    actionRepository.Add(entity);
                    actionRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            actionRepository.Add(item);
                        }
                    }
                    actionRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(Data.DataSys.Sys_MvcControllerAction entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    entity.State = false;
                    actionRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return res;
        }

        public bool Delete(IList<Data.DataSys.Sys_MvcControllerAction> entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null && item.Id > 0)
                        {
                            item.State = false;
                            actionRepository.Modify(item);
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
                var delete = actionRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = Delete(delete, operUser);
                }
            }
            return res;
        }

        public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    actionRepository.Delete(entity);
                    actionRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                foreach (var item in entity)
                {
                    if (item != null)
                    {
                        actionRepository.Delete(item);
                    }
                }
                try
                {
                    actionRepository.Uow.Commit();
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
                var delete = actionRepository.GetList(e => idList.Contains(e.Id)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    actionRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            actionRepository.Modify(item);
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

        public Data.DataSys.Sys_MvcControllerAction Get(int Id)
        {
            var data = actionRepository.GetList(e => e.Id == Id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> GetList()
        {
            var res = actionRepository.GetList().AsQueryable();
            return res;
        }

        /// <summary>
        /// Gets the action list.
        /// permission service used
        /// </summary>
        /// <param name="actionIdList">The action id list.</param>
        /// <returns></returns>
        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> GetList(IQueryable<int> actionIdList)
        {
            var res = actionRepository.GetList(d => actionIdList.Contains(d.Id)).AsQueryable();
            return res;
        }

        public iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto GetActionSingDto(int id)
        {
            var res = actionRepository.GetList(e => e.Id == id).Select(e => new iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto()
            {
                Id = e.Id,
                ClassId = e.ControllerId,
                Name = e.Name,
                Remark = e.Remark,
                AddTime = e.AddTime,
                IpAddress = e.IpAddress,
                State = e.State,
                SortNum = e.SortNum,
                ControllerName = controllerRepository.GetList(d => d.Id == e.ControllerId).FirstOrDefault() != null ?
                controllerRepository.GetList(d => d.Id == e.ControllerId).FirstOrDefault().Name : "暂无分类",
            }).FirstOrDefault();
            return res;
        }

        public iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction GetActionSingleById(int id)
        {
            var res = actionRepository.GetList(e => e.Id == id).FirstOrDefault();
            return res;
        }

        public IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto> GetActionDtoList()
        {
            var res = actionRepository.GetList().Select(e => new iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto()
            {
                Id = e.Id,
                Name = e.Name,
                Remark = e.Remark,
                AddTime = e.AddTime,
                IpAddress = e.IpAddress,
                State = e.State,
                SortNum = e.SortNum,
                ControllerName = controllerRepository.GetList(d => d.Id == e.ControllerId).FirstOrDefault() != null ?
                controllerRepository.GetList(d => d.Id == e.ControllerId).FirstOrDefault().Name : "暂无分类",
            }).AsQueryable();
            return res;
        }

        public bool NameAndControllerNameHasAction(int ControllerId, string name)
        {
            var res = actionRepository.GetList(e => e.ControllerId == ControllerId && e.Name == name).Any();
            return res;
        }
    }
}
