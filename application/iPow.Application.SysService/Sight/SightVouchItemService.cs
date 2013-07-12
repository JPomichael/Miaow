using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.SysService
{
    public class SightVouchItemService : ISightVouchItemService
    {
    	    iPow.Domain.Repository.ISightVouchItemRepository   sightVouchItemRepository  ;
    
            public SightVouchItemService( iPow.Domain.Repository.ISightVouchItemRepository sightVouchItem)
            {
                if (sightVouchItem == null)
                {
                    throw new ArgumentNullException(" sightVouchItemRepository   is null");
                }
                sightVouchItemRepository = sightVouchItem;
            }
    
            public bool Add(iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem enitty, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        sightVouchItemRepository.Add(enitty);
                        sightVouchItemRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightVouchItemRepository.Add(item);
                            }
                        }
                        sightVouchItemRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        sightVouchItemRepository.Delete(entity);
                        sightVouchItemRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightVouchItemRepository.Delete(item);
                            }
                        }
                        sightVouchItemRepository.Uow.Commit();
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
                    var delete = sightVouchItemRepository.GetList(e => idList.Contains(e.ItemID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.ItemID > 0)
                {
                    try
                    {
                        sightVouchItemRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                sightVouchItemRepository.Modify(item);
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
    
    		    public iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem Get(int id)
            {
                var data = sightVouchItemRepository.GetList(e => e.ItemID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem> GetList()
            {
                var res = sightVouchItemRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = sightVouchItemRepository.GetList().Max(e => e.ItemID);
                return res;
            }
    	
    }
}
