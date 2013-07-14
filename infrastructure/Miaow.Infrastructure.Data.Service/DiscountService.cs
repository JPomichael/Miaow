using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Miaow.Infrastructure.Crosscutting.EntityToDto;

namespace Miaow.Infrastructure.Crosscutting.Comm.Service
{
    public class DiscountService : IDiscountService
    {
        Miaow.Domain.Repository.IDisCountInfoRepository discountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountService"/> class.
        /// </summary>
        public DiscountService(Miaow.Domain.Repository.IDisCountInfoRepository discount)
        {
            if (discount == null)
            {
                throw new ArgumentNullException("discountRepository is null");
            }
            discountRepository = discount;
        }

        /// <summary>
        /// 初始化优惠信息前4条添加时间
        /// </summary>
        /// <returns></returns>
        public IQueryable<Miaow.Domain.Dto.Sys_DisCountInfoDto> GetDiscount()
        {
            var res = discountRepository.GetList()
                .OrderByDescending(d => d.AddTime).Take(4).ToDto().AsQueryable();
            return res;
        }

        /// <summary>
        /// Gets the discount.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public IQueryable<Miaow.Domain.Dto.Sys_DisCountInfoDto> GetDiscount(int take)
        {
            var res = discountRepository.GetList().OrderByDescending(d => d.AddTime).Take(take).ToDto();
            return res.AsQueryable();
        }
    }
}
