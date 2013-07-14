using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class CityInfoMoreService : ICityInfoMoreService
    {
    	    Miaow.Domain.Repository.ICityInfoMoreRepository   cityInfoMoreRepository  ;
    
            public CityInfoMoreService( Miaow.Domain.Repository.ICityInfoMoreRepository cityInfoMore)
            {
                if (cityInfoMore == null)
                {
                    throw new ArgumentNullException(" cityInfoMoreRepository   is null");
                }
                cityInfoMoreRepository = cityInfoMore;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        cityInfoMoreRepository.Add(enitty);
                        cityInfoMoreRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                cityInfoMoreRepository.Add(item);
                            }
                        }
                        cityInfoMoreRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
     public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null )
                {
                    try
                    {
    				    entity.State = false;
                        cityInfoMoreRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
    
            public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                item.State = false;
                                cityInfoMoreRepository.Modify(item);
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
    
            public bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                    var res = false;
                    if (idList != null && idList.Count > 0)
                    {
                        var delete = cityInfoMoreRepository.GetList(e => idList.Contains(e.Id)).ToList();
                        if (delete != null && delete.Count > 0)
                        {
                            res = Delete(delete, operUser);
                        }
                    }
                    return res;
            }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        cityInfoMoreRepository.Delete(entity);
                        cityInfoMoreRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                cityInfoMoreRepository.Delete(item);
                            }
                        }
                        cityInfoMoreRepository.Uow.Commit();
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
                    var delete = cityInfoMoreRepository.GetList(e => idList.Contains(e.Id)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.Id > 0)
                {
                    try
                    {
                        cityInfoMoreRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                cityInfoMoreRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore Get(int id)
            {
                var data = cityInfoMoreRepository.GetList(e => e.Id == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore> GetList()
            {
                var res = cityInfoMoreRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = cityInfoMoreRepository.GetList().Max(e => e.Id);
                return res;
            }
    	
    }
}
