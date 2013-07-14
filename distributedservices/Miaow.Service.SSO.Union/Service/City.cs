using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Union.Bll
{
    public static class Citys
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Provider.City.CityProvider provider = new Provider.City.CityProvider(new Provider.City.CityDefaultSettings());

        /// <summary>
        /// Gets the name of the union city id by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static int GetUnionCityIdByName(string name)
        {
            var city = provider.GetUnionCityList();
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
        public static string GetUnionCityNameById(int id)
        {
            var city = provider.GetUnionCityList();
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
        public static BllModels.CityModel GetSingleUnionCityModelById(int id)
        {
            var city = provider.GetUnionCityList();
            var temp = city.Where(e => e.id == id).FirstOrDefault();
            return temp;
        }
    }
}