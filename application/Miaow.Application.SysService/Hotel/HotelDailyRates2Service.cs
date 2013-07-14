using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class HotelDailyRates2Service : IHotelDailyRates2Service
    {
    	    Miaow.Domain.Repository.IHotelDailyRates2Repository   hotelDailyRates2Repository  ;
    
            public HotelDailyRates2Service( Miaow.Domain.Repository.IHotelDailyRates2Repository hotelDailyRates2)
            {
                if (hotelDailyRates2 == null)
                {
                    throw new ArgumentNullException(" hotelDailyRates2Repository   is null");
                }
                hotelDailyRates2Repository = hotelDailyRates2;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2 enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        hotelDailyRates2Repository.Add(enitty);
                        hotelDailyRates2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.Count > 0)
                {
                    try
                    {
                        foreach (var item in entity)
                        {
                            if (item != null)
                            {
                                hotelDailyRates2Repository.Add(item);
                            }
                        }
                        hotelDailyRates2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2 entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2 entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        hotelDailyRates2Repository.Delete(entity);
                        hotelDailyRates2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.Count > 0)
                {
                    try
                    {
                        foreach (var item in entity)
                        {
                            if (item != null)
                            {
                                hotelDailyRates2Repository.Delete(item);
                            }
                        }
                        hotelDailyRates2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (idList != null && idList.Count > 0)
                {
                    var delete = hotelDailyRates2Repository.GetList(e => idList.Contains(e.DailyRatesID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2 entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.DailyRatesID > 0)
                {
                    try
                    {
                        hotelDailyRates2Repository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.Count > 0)
                {
                    try
                    {
                        foreach (var item in entity)
                        {
                            if (item != null)
                            {
                                hotelDailyRates2Repository.Modify(item);
                            }
                        }
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2 Get(int id)
            {
                var data = hotelDailyRates2Repository.GetList(e => e.DailyRatesID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_HotelDailyRates2> GetList()
            {
                var res = hotelDailyRates2Repository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = hotelDailyRates2Repository.GetList().Max(e => e.DailyRatesID);
                return res;
            }
    	
    }
}
