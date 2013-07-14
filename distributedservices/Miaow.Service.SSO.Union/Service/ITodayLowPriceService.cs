using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITodayLowPriceService
    {
        /// <summary>
        /// Gets the type of the union today low price by city id and.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="type">The type.</param>
        /// <param name="orderbyprice">if set to <c>true</c> [orderbyprice].</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<Miaow.Application.Union.Dto.TodayLowPriceDto> GetUnionTodayLowPriceByCityIdAndType(string cid, string type, bool orderbyprice, int take);
    }
}
