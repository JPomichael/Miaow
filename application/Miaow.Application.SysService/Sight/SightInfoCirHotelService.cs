using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class SightInfoCirHotelService : ISightInfoCirHotelService
    {
    	    Miaow.Domain.Repository.ISightInfoCirHotelRepository   sightInfoCirHotelRepository  ;
    
            public SightInfoCirHotelService( Miaow.Domain.Repository.ISightInfoCirHotelRepository sightInfoCirHotel)
            {
                if (sightInfoCirHotel == null)
                {
                    throw new ArgumentNullException(" sightInfoCirHotelRepository   is null");
                }
                sightInfoCirHotelRepository = sightInfoCirHotel;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        sightInfoCirHotelRepository.Add(enitty);
                        sightInfoCirHotelRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirHotelRepository.Add(item);
                            }
                        }
                        sightInfoCirHotelRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
     public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null )
                {
                    try
                    {
    				    entity.State = false;
                        sightInfoCirHotelRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
    
            public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirHotelRepository.Modify(item);
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
                        var delete = sightInfoCirHotelRepository.GetList(e => idList.Contains(e.Id)).ToList();
                        if (delete != null && delete.Count > 0)
                        {
                            res = Delete(delete, operUser);
                        }
                    }
                    return res;
            }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        sightInfoCirHotelRepository.Delete(entity);
                        sightInfoCirHotelRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirHotelRepository.Delete(item);
                            }
                        }
                        sightInfoCirHotelRepository.Uow.Commit();
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
                    var delete = sightInfoCirHotelRepository.GetList(e => idList.Contains(e.Id)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.Id > 0)
                {
                    try
                    {
                        sightInfoCirHotelRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightInfoCirHotelRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel Get(int id)
            {
                var data = sightInfoCirHotelRepository.GetList(e => e.Id == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel> GetList()
            {
                var res = sightInfoCirHotelRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = sightInfoCirHotelRepository.GetList().Max(e => e.Id);
                return res;
            }
    	
    }
}
