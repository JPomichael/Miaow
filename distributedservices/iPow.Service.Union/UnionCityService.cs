using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;
using System.Configuration;
using iPow.Application.Union.Dto;

namespace iPow.Service.Union
{
    /// <summary>
    /// 
    /// </summary>
    public class UnionCityService : IUnionCityService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnionCityService"/> class.
        /// </summary>
        /// <param name="setting">The setting.</param>
        public UnionCityService(CitySettingBase setting)
        {
            Settings = setting;
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public CitySettingBase Settings { get; set; }

        /// <summary>
        /// Gets the union city list.
        /// </summary>
        /// <returns></returns>
        public List<iPow.Application.Union.Dto.UnionCityDto> GetUnionCityList()
        {
            List<iPow.Application.Union.Dto.UnionCityDto> cityList = null;
            var configFullPath = HttpContext.Current.Server.MapPath(Settings.FullPath);
            if (System.IO.File.Exists(configFullPath))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(configFullPath);
                if (fi.Length > 0)
                {
                    cityList = GetUnionCityListByLocalFile();
                }
                else
                {
                    cityList = GetUnionCityListByUnion();
                }
            }
            else
            {
                cityList = GetUnionCityListByUnion();
            }
            return cityList;
        }

        /// <summary>
        /// Gets the union city list by union.
        /// </summary>
        /// <returns></returns>
        public List<iPow.Application.Union.Dto.UnionCityDto> GetUnionCityListByUnion()
        {
            List<iPow.Application.Union.Dto.UnionCityDto> data = null;
            Config.IUnionConfig configProvider = Config.ConfigManager.GetConfigProvider();
            UnionDataUrlBase urlProvider = new DataUrl.Default.QueryAllCityDefaultService(configProvider);
            iPow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            var dataUrl = urlProvider.GetUrl();
            try
            {
                var str = req.WebRequest(iPow.Infrastructure.Crosscutting.Function.HttpMethod.GET, dataUrl.ToString(), "");
                SaveCitySetting(str);
                data = GetUnionCityListBase(str);
            }
            catch (Exception ex)
            { }
            return data;
        }

        /// <summary>
        /// Saves the city setting.
        /// </summary>
        /// <param name="str">The STR.</param>
        public void SaveCitySetting(string str)
        {
            var configFullPath = HttpContext.Current.Server.MapPath(Settings.FullPath);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(configFullPath, false, System.Text.Encoding.UTF8))
            {
                try
                {
                    sw.Write(str);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Gets the union city list base.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public List<iPow.Application.Union.Dto.UnionCityDto> GetUnionCityListBase(string str)
        {
            List<iPow.Application.Union.Dto.UnionCityDto> unionCityList = null;
            iPow.Application.Union.Dto.UnionCityDto city = null;
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    unionCityList = new List<iPow.Application.Union.Dto.UnionCityDto>();
                    Newtonsoft.Json.Linq.JArray ja = Newtonsoft.Json.JsonConvert.DeserializeObject(str) as Newtonsoft.Json.Linq.JArray;
                    foreach (var item in ja)
                    {
                        city = new iPow.Application.Union.Dto.UnionCityDto();
                        city.citypy = item["citypy"] == null ? string.Empty : item["citypy"].ToString();
                        city.id = item["id"] == null ? -1 : int.Parse(item["id"].ToString());
                        city.name = item["name"] == null ? string.Empty : item["name"].ToString();
                        city.p_name = item["p_name"] == null ? string.Empty : item["p_name"].ToString();
                        city.pid = item["pid"] == null ? -1 : int.Parse(item["pid"].ToString());
                        city.total = item["total"] == null ? -1 : int.Parse(item["total"].ToString());
                        unionCityList.Add(city);
                        System.Diagnostics.Debug.WriteLine(item["name"]);
                    }
                }
                catch (Exception ex)
                { }
            }
            return unionCityList;
        }

        /// <summary>
        /// Gets the union city list by local file.
        /// </summary>
        /// <returns></returns>
        public List<iPow.Application.Union.Dto.UnionCityDto> GetUnionCityListByLocalFile()
        {
            string settingStr = Settings.GetSettingsValue();
            return GetUnionCityListBase(settingStr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class CitySettingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CitySettingBase"/> class.
        /// </summary>
        public CitySettingBase()
        {
            FullPath = System.Configuration.ConfigurationManager.AppSettings["unioncityproivderfullpath"].ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CitySettingBase"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public CitySettingBase(string path)
        {
            FullPath = path;
        }

        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        /// <value>The full path.</value>
        public string FullPath { get; set; }

        /// <summary>
        /// Gets the settings value.
        /// </summary>
        /// <returns></returns>
        public virtual string GetSettingsValue()
        {
            string val = string.Empty;
            var configFullPath = HttpContext.Current.Server.MapPath(FullPath);
            if (System.IO.File.Exists(configFullPath))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(configFullPath))
                {
                    val = sr.ReadToEnd();
                }
            }
            return val;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CitySettingDefault : CitySettingBase
    {
        /// <summary>
        /// Gets the settings value.
        /// </summary>
        /// <returns></returns>
        public override string GetSettingsValue()
        {
            return base.GetSettingsValue();
        }
    }
}