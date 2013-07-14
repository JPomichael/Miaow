using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miaow.Presentation
{
    public static partial class MiaowPreAccountEntityCustomMap
    {
        //自定义的扩展方法
        public static Miaow.Presentation.account.Models.TourPlanDetailDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, Miaow.Presentation.account.Models.TourPlanDetailDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Presentation.account.Models.TourPlanDetailDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, Miaow.Presentation.account.Models.TourPlanDetailDto>().MapEnum(entity);
        }

        public static Miaow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerAction entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerAction,
                    Miaow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto>().Map(entity);
        }

        public static Miaow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_UserRoles entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles, Miaow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles, Miaow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto>().MapEnum(entity);
        }

        public static IEnumerable<Miaow.Domain.Dto.Sys_MvcControllerActionDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerAction,
                    Miaow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto>().MapEnum(entity);
        }

    }
}