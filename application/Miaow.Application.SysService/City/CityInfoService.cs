using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class CityInfoService : ICityInfoService
    {
    	    Miaow.Domain.Repository.ICityInfoRepository   cityInfoRepository  ;
    
            public CityInfoService( Miaow.Domain.Repository.ICityInfoRepository cityInfo)
            {
                if (cityInfo == null)
                {
                    throw new ArgumentNullException(" cityInfoRepository   is null");
                }
                cityInfoRepository = cityInfo;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_CityInfo enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        cityInfoRepository.Add(enitty);
                        cityInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                cityInfoRepository.Add(item);
                            }
                        }
                        cityInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_CityInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_CityInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        cityInfoRepository.Delete(entity);
                        cityInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                cityInfoRepository.Delete(item);
                            }
                        }
                        cityInfoRepository.Uow.Commit();
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
                    var delete = cityInfoRepository.GetList(e => idList.Contains(e.id)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_CityInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.id > 0)
                {
                    try
                    {
                        cityInfoRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                cityInfoRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_CityInfo Get(int id)
            {
                var data = cityInfoRepository.GetList(e => e.id == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo> GetList()
            {
                var res = cityInfoRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = cityInfoRepository.GetList().Max(e => e.id);
                return res;
            }
    	
    }
}
