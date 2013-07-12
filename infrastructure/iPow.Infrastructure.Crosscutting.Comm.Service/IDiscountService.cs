using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// Gets the discount.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_DisCountInfoDto> GetDiscount(int take);

        /// <summary>
        /// Gets the discount.
        /// </summary>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_DisCountInfoDto> GetDiscount();
    }
}
