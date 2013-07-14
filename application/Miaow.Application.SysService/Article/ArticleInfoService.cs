using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class ArticleInfoService : IArticleInfoService
    {
    	    Miaow.Domain.Repository.IArticleInfoRepository   articleInfoRepository  ;
    
            public ArticleInfoService( Miaow.Domain.Repository.IArticleInfoRepository articleInfo)
            {
                if (articleInfo == null)
                {
                    throw new ArgumentNullException(" articleInfoRepository   is null");
                }
                articleInfoRepository = articleInfo;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        articleInfoRepository.Add(enitty);
                        articleInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                articleInfoRepository.Add(item);
                            }
                        }
                        articleInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        articleInfoRepository.Delete(entity);
                        articleInfoRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                articleInfoRepository.Delete(item);
                            }
                        }
                        articleInfoRepository.Uow.Commit();
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
                    var delete = articleInfoRepository.GetList(e => idList.Contains(e.ArticleID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.ArticleID > 0)
                {
                    try
                    {
                        articleInfoRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                articleInfoRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo Get(int id)
            {
                var data = articleInfoRepository.GetList(e => e.ArticleID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo> GetList()
            {
                var res = articleInfoRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = articleInfoRepository.GetList().Max(e => e.ArticleID);
                return res;
            }
    	
    }
}
