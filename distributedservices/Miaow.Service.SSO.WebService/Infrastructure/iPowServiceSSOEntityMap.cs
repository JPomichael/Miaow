using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

namespace Miaow.Service.SSO.WebService
{
    public class MiaowServiceSSOEntityMap
    {
        public static void Map()
        {
            AutoMapper.Mapper.CreateMap<Miaow.Infrastructure.Data.DataSys.Sys_AdminUser , Miaow.Service.SSO.Entity.User>();
        }
    }
}