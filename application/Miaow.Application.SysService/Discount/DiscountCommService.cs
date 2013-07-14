using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class DiscountCommService : IDiscountCommService
    {
    	    Miaow.Domain.Repository.IDiscountCommRepository   discountCommRepository  ;
    
            public DiscountCommService( Miaow.Domain.Repository.IDiscountCommRepository discountComm)
            {
                if (discountComm == null)
                {
                    throw new ArgumentNullException(" discountCommRepository   is null");
                }
                discountCommRepository = discountComm;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        discountCommRepository.Add(enitty);
                        discountCommRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                discountCommRepository.Add(item);
                            }
                        }
                        discountCommRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
     public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null )
                {
                    try
                    {
    				    entity.State = 0;
                        discountCommRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
    
            public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                item.State = 0;
                                discountCommRepository.Modify(item);
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
                        var delete = discountCommRepository.GetList(e => idList.Contains(e.CommID)).ToList();
                        if (delete != null && delete.Count > 0)
                        {
                            res = Delete(delete, operUser);
                        }
                    }
                    return res;
            }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        discountCommRepository.Delete(entity);
                        discountCommRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                discountCommRepository.Delete(item);
                            }
                        }
                        discountCommRepository.Uow.Commit();
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
                    var delete = discountCommRepository.GetList(e => idList.Contains(e.CommID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.CommID > 0)
                {
                    try
                    {
                        discountCommRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                discountCommRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm Get(int id)
            {
                var data = discountCommRepository.GetList(e => e.CommID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm> GetList()
            {
                var res = discountCommRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = discountCommRepository.GetList().Max(e => e.CommID);
                return res;
            }
    	
    }
}
