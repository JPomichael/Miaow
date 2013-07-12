using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcActionService
    {
        bool Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction Get(int Id);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> GetList();

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> GetList(IQueryable<int> idList);

        iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto GetActionSingDto(int id);

        iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction GetActionSingleById(int id);

        IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto> GetActionDtoList();

        bool NameAndControllerNameHasAction(int ControllerId, string name);
    }
}
