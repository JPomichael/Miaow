using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class HotelPropertyInfoService : IHotelPropertyInfoService
    {
    	    Miaow.Domain.Repository.IHotelPropertyInfoRepository   hotelPropertyInfoRepository  ;
    
            public HotelPropertyInfoService( Miaow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo)
            {
                if (hotelPropertyInfo == null)
                {
                    throw new ArgumentNullException(" hotelPropertyInfoRepository   is null");
                }
                hotelPropertyInfoRepository = hotelPropertyInfo;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        hotelPropertyInfoRepository.Add(enitty);
                        hotelPropertyInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelPropertyInfoRepository.Add(item);
                            }
                        }
                        hotelPropertyInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        hotelPropertyInfoRepository.Delete(entity);
                        hotelPropertyInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelPropertyInfoRepository.Delete(item);
                            }
                        }
                        hotelPropertyInfoRepository.Uow.Commit();
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
                    var delete = hotelPropertyInfoRepository.GetList(e => idList.Contains(e.ID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.ID > 0)
                {
                    try
                    {
                        hotelPropertyInfoRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelPropertyInfoRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo Get(int id)
            {
                var data = hotelPropertyInfoRepository.GetList(e => e.ID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> GetList()
            {
                var res = hotelPropertyInfoRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = hotelPropertyInfoRepository.GetList().Max(e => e.ID);
                return res;
            }
    	
    }
}
