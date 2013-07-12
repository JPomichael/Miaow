using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcControllerService
    {
        void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcController controller);

        void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcController controller);

        void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcController controller);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcController> GetList();

        IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto> GetControllerDtoList();

        bool ClassNameAndControllerNameHasController(int classId, string name);

        iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto GetControllerSingDto(int id);

        iPow.Infrastructure.Data.DataSys.Sys_MvcController GetControllerSingleById(int id);

        bool Delete(List<string> userIdList);

        bool Delete(List<int> userIdList);

    }
}
