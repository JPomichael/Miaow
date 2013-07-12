using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Presentation
{
    public static partial  class   iPowPreEntityToDto
    {
        //自定义的扩展方法
        public static iPow.Presentation.account.Models.TourPlanDetailDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, iPow.Presentation.account.Models.TourPlanDetailDto>().Map(entity);
        }

        public static IEnumerable<iPow.Presentation.account.Models.TourPlanDetailDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, iPow.Presentation.account.Models.TourPlanDetailDto>().MapEnum(entity);
        }

        public static iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction,
                    iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto>().Map(entity);
        }

        public static iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_UserRoles entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_UserRoles, iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto>().Map(entity);
        }

        public static IEnumerable<iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_UserRoles, iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto>().MapEnum(entity);
        }

        public static IEnumerable<iPow.Domain.Dto.Sys_MvcControllerActionDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction,
                    iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto>().MapEnum(entity);
        }
    }
}