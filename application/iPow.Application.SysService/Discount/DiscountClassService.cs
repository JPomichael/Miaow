using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.SysService
{
    public class DiscountClassService : IDiscountClassService
    {
        iPow.Domain.Repository.IDiscountClassRepository discountClassRepository;

        public DiscountClassService(iPow.Domain.Repository.IDiscountClassRepository discountClass)
        {
            if (discountClass == null)
            {
                throw new ArgumentNullException(" discountClassRepository   is null");
            }
            discountClassRepository = discountClass;
        }

        public bool Add(iPow.Infrastructure.Data.DataSys.Sys_DiscountClass enitty, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (enitty != null)
            {
                try
                {
                    discountClassRepository.Add(enitty);
                    discountClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            discountClassRepository.Add(item);
                        }
                    }
                    discountClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(iPow.Infrastructure.Data.DataSys.Sys_DiscountClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_DiscountClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    discountClassRepository.Delete(entity);
                    discountClassRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            discountClassRepository.Delete(item);
                        }
                    }
                    discountClassRepository.Uow.Commit();
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
                var delete = discountClassRepository.GetList(e => idList.Contains(e.ClassID)).ToList();
                if (delete != null && delete.Count > 0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        public bool Modify(iPow.Infrastructure.Data.DataSys.Sys_DiscountClass entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.ClassID > 0)
            {
                try
                {
                    discountClassRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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
                            discountClassRepository.Modify(item);
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

        public iPow.Infrastructure.Data.DataSys.Sys_DiscountClass Get(int id)
        {
            var data = discountClassRepository.GetList(e => e.ClassID == id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass> GetList()
        {
            var res = discountClassRepository.GetList().AsQueryable();
            return res;
        }

        public int GetMaxId()
        {
            var res = discountClassRepository.GetList().Max(e => e.ClassID);
            return res;
        }

    }
}
