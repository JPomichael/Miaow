using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.account.Service
{
    public static class iPowAppAccountServiceEntityMap
    {
        public static iPow.Application.account.Dto.TourPlanDetailDto ToDto(this iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, iPow.Application.account.Dto.TourPlanDetailDto>().Map(entity);
        }

        public static IEnumerable<iPow.Application.account.Dto.TourPlanDetailDto> ToDto(this IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, iPow.Application.account.Dto.TourPlanDetailDto>().MapEnum(entity);
        }
    }
}
