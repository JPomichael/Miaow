using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.SysService
{
    public class HotelRoomInfoService : IHotelRoomInfoService
    {
    	    iPow.Domain.Repository.IHotelRoomInfoRepository   hotelRoomInfoRepository  ;
    
            public HotelRoomInfoService( iPow.Domain.Repository.IHotelRoomInfoRepository hotelRoomInfo)
            {
                if (hotelRoomInfo == null)
                {
                    throw new ArgumentNullException(" hotelRoomInfoRepository   is null");
                }
                hotelRoomInfoRepository = hotelRoomInfo;
            }
    
            public bool Add(iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo enitty, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        hotelRoomInfoRepository.Add(enitty);
                        hotelRoomInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelRoomInfoRepository.Add(item);
                            }
                        }
                        hotelRoomInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        hotelRoomInfoRepository.Delete(entity);
                        hotelRoomInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelRoomInfoRepository.Delete(item);
                            }
                        }
                        hotelRoomInfoRepository.Uow.Commit();
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
                    var delete = hotelRoomInfoRepository.GetList(e => idList.Contains(e.HotelID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.HotelID > 0)
                {
                    try
                    {
                        hotelRoomInfoRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                hotelRoomInfoRepository.Modify(item);
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
    
    		    public iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo Get(int id)
            {
                var data = hotelRoomInfoRepository.GetList(e => e.HotelID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_HotelRoomInfo> GetList()
            {
                var res = hotelRoomInfoRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = hotelRoomInfoRepository.GetList().Max(e => e.HotelID);
                return res;
            }
    	
    }
}
