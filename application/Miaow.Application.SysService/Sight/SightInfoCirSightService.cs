using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class SightInfoCirSightService : ISightInfoCirSightService
    {
    	    Miaow.Domain.Repository.ISightInfoCirSightRepository   sightInfoCirSightRepository  ;
    
            public SightInfoCirSightService( Miaow.Domain.Repository.ISightInfoCirSightRepository sightInfoCirSight)
            {
                if (sightInfoCirSight == null)
                {
                    throw new ArgumentNullException(" sightInfoCirSightRepository   is null");
                }
                sightInfoCirSightRepository = sightInfoCirSight;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        sightInfoCirSightRepository.Add(enitty);
                        sightInfoCirSightRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirSightRepository.Add(item);
                            }
                        }
                        sightInfoCirSightRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
     public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null )
                {
                    try
                    {
    				    entity.State = false;
                        sightInfoCirSightRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
    
            public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirSightRepository.Modify(item);
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
                        var delete = sightInfoCirSightRepository.GetList(e => idList.Contains(e.Id)).ToList();
                        if (delete != null && delete.Count > 0)
                        {
                            res = Delete(delete, operUser);
                        }
                    }
                    return res;
            }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        sightInfoCirSightRepository.Delete(entity);
                        sightInfoCirSightRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirSightRepository.Delete(item);
                            }
                        }
                        sightInfoCirSightRepository.Uow.Commit();
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
                    var delete = sightInfoCirSightRepository.GetList(e => idList.Contains(e.Id)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.Id > 0)
                {
                    try
                    {
                        sightInfoCirSightRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirSightRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight Get(int id)
            {
                var data = sightInfoCirSightRepository.GetList(e => e.Id == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight> GetList()
            {
                var res = sightInfoCirSightRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = sightInfoCirSightRepository.GetList().Max(e => e.Id);
                return res;
            }
    	
    }
}
