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

        public void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction action)
        {
            actionRepository.Add(action);
            actionRepository.Uow.Commit();
        }

        public void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction action)
        {
            actionRepository.Delete(action);
            actionRepository.Uow.Commit();
        }


        public bool Delete(List<int> userIdList)
        {
            var data = actionRepository.GetList(e => userIdList.Contains(e.Id));
            foreach (var item in data)
            {
                actionRepository.Delete(item);
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


        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction action)
        {
            actionRepository.Modify(action);
            actionRepository.Uow.Commit();
        }

        public bool NameAndControllerNameHasAction(int ControllerId, string name)
        {
            var res = actionRepository.GetList(e => e.ControllerId == ControllerId && e.Name == name).Any();
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

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> GetList()
        {
            var res = actionRepository.GetList().AsQueryable();
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

        public iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction GetActionSingleById(int id)
        {
            var res = actionRepository.GetList(e => e.Id == id).FirstOrDefault();
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

    }
}
