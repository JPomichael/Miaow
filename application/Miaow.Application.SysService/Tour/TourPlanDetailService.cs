using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class TourPlanDetailService : ITourPlanDetailService
    {
    	    Miaow.Domain.Repository.ITourPlanDetailRepository   tourPlanDetailRepository  ;
    
            public TourPlanDetailService( Miaow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail)
            {
                if (tourPlanDetail == null)
                {
                    throw new ArgumentNullException(" tourPlanDetailRepository   is null");
                }
                tourPlanDetailRepository = tourPlanDetail;
            }
    
            public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (enitty != null)
                {
                    try
                    {
                        tourPlanDetailRepository.Add(enitty);
                        tourPlanDetailRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                tourPlanDetailRepository.Add(item);
                            }
                        }
                        tourPlanDetailRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
          public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
          
    	  public bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
          {
    	    throw new NotImplementedException();
    	  }
    
    	   public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
    	  {
    	    throw new NotImplementedException();
    	  }
        
            public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null)
                {
                    try
                    {
                        tourPlanDetailRepository.Delete(entity);
                        tourPlanDetailRepository.Uow.Commit();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                tourPlanDetailRepository.Delete(item);
                            }
                        }
                        tourPlanDetailRepository.Uow.Commit();
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
                    var delete = tourPlanDetailRepository.GetList(e => idList.Contains(e.PlanDetailID)).ToList();
                    if(delete != null &&delete.Count >  0)
                    {
                        res = DeleteTrue(delete, operUser);
                    }
                }
                return res;
            }
    
            public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
            {
                var res = false;
                if (entity != null && entity.PlanDetailID > 0)
                {
                    try
                    {
                        tourPlanDetailRepository.Modify(entity);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return res;
            }
    
            public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                                tourPlanDetailRepository.Modify(item);
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
    
    		    public Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail Get(int id)
            {
                var data = tourPlanDetailRepository.GetList(e => e.PlanDetailID == id).FirstOrDefault();
                return data;
            }
    
            public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> GetList()
            {
                var res = tourPlanDetailRepository.GetList().AsQueryable();
                return res;
            }
    
            public int GetMaxId()
            {
                 var res = tourPlanDetailRepository.GetList().Max(e => e.PlanDetailID);
                return res;
            }
    	
    }
}
