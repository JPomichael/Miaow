using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICityService
    {
        /// <summary>
        /// Gets the name of the union city id by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        int GetUnionCityIdByName(string name);

        /// <summary>
        /// Gets the union city name by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        string GetUnionCityNameById(int id);

        /// <summary>
        /// Gets the single union city model by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Miaow.Application.Union.Dto.UnionCityDto GetSingleUnionCityModelById(int id);
    }
}
