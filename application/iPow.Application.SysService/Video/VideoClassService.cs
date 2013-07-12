using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.SysService
{
    public class VideoClassService : IVideoClassService
    {
    	    iPow.Domain.Repository.IVideoClassRepository   videoClassRepository  ;
    
            public VideoClassService( iPow.Domain.Repository.IVideoClassRepository videoClass)
            {
                if (videoClass == null)
                {
                    throw new ArgumentNullException(" videoClassRepository   is null");
                }
                videoClassRepository = videoClass;
            }
    
            public bool Add(iPow.Infrastructure.Data.DataSys.Sys_VideoClass enitty, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        videoClassRepository.Add(enitty);
                        videoClassRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_VideoClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                videoClassRepository.Add(item);
                            }
                        }
                        videoClassRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_VideoClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(iPow.Infrastructure.Data.DataSys.Sys_VideoClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_VideoClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        videoClassRepository.Delete(entity);
                        videoClassRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_VideoClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                videoClassRepository.Delete(item);
                            }
                        }
                        videoClassRepository.Uow.Commit();
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
                    var delete = videoClassRepository.GetList(e => idList.Contains(e.ClassID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_VideoClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.ClassID > 0)
                {
                    try
                    {
                        videoClassRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_VideoClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                videoClassRepository.Modify(item);
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
    
    		    public iPow.Infrastructure.Data.DataSys.Sys_VideoClass Get(int id)
            {
                var data = videoClassRepository.GetList(e => e.ClassID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_VideoClass> GetList()
            {
                var res = videoClassRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = videoClassRepository.GetList().Max(e => e.ClassID);
                return res;
            }
    	
    }
}
