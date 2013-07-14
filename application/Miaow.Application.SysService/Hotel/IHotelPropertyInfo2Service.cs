using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public interface IHotelPropertyInfo2Service
    {
    
    	    bool Add(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2  entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    
            bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);
    	        Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 Get(int id);
    
            IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> GetList();
    
            int GetMaxId();
    
    }
}
