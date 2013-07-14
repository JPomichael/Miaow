using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.SysService
{
    public class DiscountClassService : IDiscountClassService
    {
        Miaow.Domain.Repository.IDiscountClassRepository discountClassRepository;

        public DiscountClassService(Miaow.Domain.Repository.IDiscountClassRepository discountClass)
        {
            if (discountClass == null)
            {
                throw new ArgumentNullException(" discountClassRepository   is null");
            }
            discountClassRepository = discountClass;
        }

        public bool Add(Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass enitty, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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

        public bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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

        public bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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

        public bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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

        public bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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

        public bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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

        public bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
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

        public Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass Get(int id)
        {
            var data = discountClassRepository.GetList(e => e.ClassID == id).FirstOrDefault();
            return data;
        }

        public IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass> GetList()
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
