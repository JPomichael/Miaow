using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcControllerService
    {
        bool Add(iPow.Infrastructure.Data.DataSys.Sys_MvcController entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcController entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_MvcController entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcController entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcController> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        iPow.Infrastructure.Data.DataSys.Sys_MvcController Get(int Id);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcController> GetList();

        iPow.Infrastructure.Data.DataSys.Sys_MvcController GetControllerSingleById(int id);

        iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto GetControllerSingDto(int id);

        IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto> GetControllerDtoList();

        bool ClassNameAndControllerNameHasController(int classId, string name);
    }
}
