using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.account.Service
{
    public static class MiaowAppAccountServiceEntityMap
    {
        public static Miaow.Application.account.Dto.TourPlanDetailDto ToDto(this Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, Miaow.Application.account.Dto.TourPlanDetailDto>().Map(entity);
        }

        public static IEnumerable<Miaow.Application.account.Dto.TourPlanDetailDto> ToDto(this IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity)
        {
            return EmitMapper.ObjectMapperManager.DefaultInstance
                    .GetMapper<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail, Miaow.Application.account.Dto.TourPlanDetailDto>().MapEnum(entity);
        }
    }
}
