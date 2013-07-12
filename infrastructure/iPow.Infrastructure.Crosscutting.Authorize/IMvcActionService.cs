using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
   public interface IMvcActionService
    {
        void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction  action);

        void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction action);

        void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction action);

        bool NameAndControllerNameHasAction(int ControllerId, string name);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> GetList();

        iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto GetActionSingDto(int id);

        iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction GetActionSingleById(int id);

        /// <summary>
        /// Gets the action list.
        /// permission service used
        /// </summary>
        /// <param name="actionIdList">The action id list.</param>
        /// <returns></returns>
        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> GetList(IQueryable<int> actionIdList);

        IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto> GetActionDtoList();

        bool Delete(List<string> userIdList);

        bool Delete(List<int> userIdList);

    }
}
