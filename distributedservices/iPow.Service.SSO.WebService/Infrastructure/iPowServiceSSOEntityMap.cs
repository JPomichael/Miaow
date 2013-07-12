using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

namespace iPow.Service.SSO.WebService
{
    public class iPowServiceSSOEntityMap
    {
        public static void Map()
        {
            AutoMapper.Mapper.CreateMap<iPow.Infrastructure.Data.DataSys.Sys_AdminUser , iPow.Service.SSO.Entity.User>();
        }
    }
}