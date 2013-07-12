using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.SysService
{
    public class HotelPropertyInfo2Service : IHotelPropertyInfo2Service
    {
    	    iPow.Domain.Repository.IHotelPropertyInfo2Repository   hotelPropertyInfo2Repository  ;
    
            public HotelPropertyInfo2Service( iPow.Domain.Repository.IHotelPropertyInfo2Repository hotelPropertyInfo2)
            {
                if (hotelPropertyInfo2 == null)
                {
                    throw new ArgumentNullException(" hotelPropertyInfo2Repository   is null");
                }
                hotelPropertyInfo2Repository = hotelPropertyInfo2;
            }
    
            public bool Add(iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 enitty, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        hotelPropertyInfo2Repository.Add(enitty);
                        hotelPropertyInfo2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelPropertyInfo2Repository.Add(item);
                            }
                        }
                        hotelPropertyInfo2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        hotelPropertyInfo2Repository.Delete(entity);
                        hotelPropertyInfo2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelPropertyInfo2Repository.Delete(item);
                            }
                        }
                        hotelPropertyInfo2Repository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (idList != null && idList.Count > 0)
                {
                    var delete = hotelPropertyInfo2Repository.GetList(e => idList.Contains(e.ID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.ID > 0)
                {
                    try
                    {
                        hotelPropertyInfo2Repository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelPropertyInfo2Repository.Modify(item);
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
    
    		    public iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2 Get(int id)
            {
                var data = hotelPropertyInfo2Repository.GetList(e => e.ID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2> GetList()
            {
                var res = hotelPropertyInfo2Repository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = hotelPropertyInfo2Repository.GetList().Max(e => e.ID);
                return res;
            }
    	
    }
}
