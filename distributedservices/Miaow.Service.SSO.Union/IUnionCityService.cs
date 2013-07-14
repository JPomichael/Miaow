using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Service.Union
{
    public interface IUnionCityService
    {
        /// <summary>
        /// Gets the union city list.
        /// </summary>
        /// <returns></returns>
        List<Miaow.Application.Union.Dto.UnionCityDto> GetUnionCityList();

        /// <summary>
        /// Gets the union city list by local file.
        /// </summary>
        /// <returns></returns>
        List<Miaow.Application.Union.Dto.UnionCityDto> GetUnionCityListByLocalFile();

        /// <summary>
        /// Gets the union city list base.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        List<Miaow.Application.Union.Dto.UnionCityDto> GetUnionCityListBase(string str);

        /// <summary>
        /// Gets the union city list by union.
        /// </summary>
        /// <returns></returns>
        List<Miaow.Application.Union.Dto.UnionCityDto> GetUnionCityListByUnion();

        /// <summary>
        /// Saves the city setting.
        /// </summary>
        /// <param name="str">The STR.</param>
        void SaveCitySetting(string str);
    }
}
