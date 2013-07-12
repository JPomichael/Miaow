using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class CityService : ICityService
    {

        /// <summary>
        /// 
        /// </summary>
        private IUnionCityService cityProvider =  new UnionCityService(new CitySettingDefault());

        /// <summary>
        /// Initializes a new instance of the <see cref="CityService"/> class.
        /// </summary>
        /// <param name="prov">The prov.</param>
        public CityService(IUnionCityService prov)
        {
            cityProvider = prov;
        }


        /// <summary>
        /// Gets the name of the union city id by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public int GetUnionCityIdByName(string name)
        {
            var city = cityProvider.GetUnionCityList();
            int res = -1;
            var temp = city.Where(e => e.name == name).FirstOrDefault();
            if (temp != null && temp.id > 0)
            {
                res = temp.id == null ? 0 : (int)temp.id;
            }
            return res;
        }

        /// <summary>
        /// Gets the union city name by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public string GetUnionCityNameById(int id)
        {
            var city = cityProvider.GetUnionCityList();
            string res = string.Empty;
            var temp = city.Where(e => e.id == id).FirstOrDefault();
            if (temp != null && temp.id > 0)
            {
                res = temp.name;
            }
            return res;
        }

        /// <summary>
        /// Gets the single union city model by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public iPow.Application.Union.Dto.UnionCityDto GetSingleUnionCityModelById(int id)
        {
            var city = cityProvider.GetUnionCityList();
            var temp = city.Where(e => e.id == id).FirstOrDefault();
            return temp;
        }

    }
}