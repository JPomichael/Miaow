using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeService : IHomeService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Application.jq.Service.ISinaInfoService sinaInfoService = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Application.jq.Service.ISightInfoService sightInfoService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeService"/> class.
        /// </summary>
        /// <param name="sinaService">The sina service.</param>
        /// <param name="cityService">The city service.</param>
        /// <param name="sightService">The sight service.</param>
        public HomeService(iPow.Application.jq.Service.ISinaInfoService sinaService,
            iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityService,
            iPow.Application.jq.Service.ISightInfoService sightService)
        {
            if (sinaService == null)
            {
                throw new ArgumentNullException("sinainfoservice is null");
            }
            if (cityService == null)
            {
                throw new ArgumentNullException("cityinfoservice is null");
            }
            if (sightService == null)
            {
                throw new ArgumentNullException("sightinfoservice is null");
            }
            sinaInfoService = sinaService;
            cityInfoService = cityService;
            sightInfoService = sightService;
        }

        /// <summary>
        /// Initializes a new instance of the 根据当前IP中的市选景区<see cref="HomeModel"/> class.
        /// </summary>
        /// <param name="pi">The pi.</param>
        /// <param name="pageSize">The take.</param>
        /// <returns></returns>
        public HomeDto GetHomeModelNoCity(int pi, int pageSize)
        {
            HomeDto data = new HomeDto();
            data.LocationSina = sinaInfoService.GetSinaInfo();
            data.LocaltionCityInfo = cityInfoService.GetCityInfoBySina(data.LocationSina);
            //在这里，我们得将city(拼音的)转换成中文的
            data.CurrentCityInfo = data.LocaltionCityInfo;
            int total = 0;
            int sortCount = 0;
            int currentClassId = 0;
            List<TopClassDto> topClass = null;
            //默认是当前的IP地址来选景区
            //传入当前地址
            //在这个里面，更新了TopClass
            List<DefaultSightInfoDto> si = sightInfoService.GetSightListByProvinceOrCity(data.LocationSina, ref currentClassId, string.Empty,
                data.LocationSina.City, -1, pi, pageSize, ref  total, ref sortCount, ref topClass);
            data.SightInfo = sightInfoService.ToPageList(si, 1, pageSize, total - sortCount);
            data.TopClass = topClass;
            data.CurrentClassId = currentClassId;
            return data;
        }

        /// <summary>
        /// Gets the home model by city.
        /// Initializes a new instance of the根据传入的城市选 <see cref="HomeModel"/> class.
        /// </summary>
        /// <param name="city">The city.拼音哦</param>
        /// <param name="pi">The pi.</param>
        /// <param name="pageSize">The take.</param>
        /// <returns></returns>

        public HomeDto GetHomeModelByCity(string city, int pi, int pageSize)
        {
            HomeDto data = new HomeDto();
            data.LocationSina = sinaInfoService.GetSinaInfo();
            data.LocaltionCityInfo = cityInfoService.GetCityInfoBySina(data.LocationSina);
            data.CurrentCityInfo = cityInfoService.GetSingleCityInfo(string.Empty, city);
            int total = 0;
            int sortCount = 0;
            int currentClassId = 0;
            List<TopClassDto> topClass = null;
            //得到传入城市的景区信息
            List<DefaultSightInfoDto> si = sightInfoService.GetSightListByProvinceOrCity(data.LocationSina, ref  currentClassId, string.Empty,
                data.CurrentCityInfo.city, -1, pi, pageSize, ref total, ref sortCount, ref topClass);
            data.SightInfo = sightInfoService.ToPageList(si, pi, pageSize, total - sortCount);
            data.TopClass = topClass;
            data.CurrentClassId = currentClassId;
            return data;
        }

        /// <summary>
        /// Gets the type of the home model by city and.
        /// Initializes a new instance of the <see cref="HomeModel"/> class.
        /// 这里，是分类型查询景区信息的 type.cshtml
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="type">The type.</param>
        /// <param name="b">if set to <c>true</c> [b].</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public HomeDto GetHomeModelByCityAndType(string city, int? type, bool b, int? pageIndex, int? pageSize)
        {
            HomeDto data = new HomeDto();
            //这个地方，在调试详细页的时候，会出现一个city = image的东西，不知道是从那里来的
            data.CurrentClassId = (int)type;
            //得到当前的访问者信息
            data.LocationSina = sinaInfoService.GetSinaInfo();
            data.LocaltionCityInfo = cityInfoService.GetCityInfoBySina(data.LocationSina);
            //在这里，我们得将city(拼音的)转换成中文的
            data.CurrentCityInfo = cityInfoService.GetSingleCityInfo(string.Empty, city);
            int total = 0;
            int sortCount = 0;
            int currentClassId = 0;
            List<TopClassDto> topClass = null;

            //得到传入城市的景区信息
            //这个地方的  province ，的那个得是中文的 
            List<DefaultSightInfoDto> si = sightInfoService.GetSightListByProvinceOrCity(data.LocationSina,
                ref currentClassId, data.CurrentCityInfo.province, data.CurrentCityInfo.city,
                type, pageIndex, pageSize, ref total, ref sortCount, ref  topClass);
            data.SightInfo = sightInfoService.ToPageList(si, (int)pageIndex, (int)pageSize, total - sortCount);
            data.TopClass = topClass;
            data.CurrentClassId = currentClassId;
            return data;
        }

        /// <summary>
        /// Gets the type of the home model by prov and city and.
        /// Initializes a new instance of the 拼音哈<see cref="HomeModel"/> class.
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <param name="type">The type.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public HomeDto GetHomeModelByProvAndCityAndType(string province, string city, int? type, int? pageIndex, int? pageSize)
        {
            HomeDto data = new HomeDto();
            data.CurrentClassId = (int)type;
            //得到当前的访问者信息
            data.LocationSina = sinaInfoService.GetSinaInfo();
            data.LocaltionCityInfo = cityInfoService.GetCityInfoBySina(data.LocationSina);
            //在这里，我们得将city(拼音的)转换成中文的
            data.CurrentCityInfo = cityInfoService.GetSingleCityInfo(province, city);
            int total = 0;
            int sortCount = 0;
            int currentClassId = 0;
            List<TopClassDto> topClass = null;
            List<DefaultSightInfoDto> si = null;
            if (string.IsNullOrEmpty(city))
            {
                //得到传入城市的景区信息
                //这个地方的  province ，的那个得是中文的 
                si = sightInfoService.GetSightListByProvinceOrCity(data.LocationSina, ref  currentClassId,
                    data.CurrentCityInfo.province, string.Empty, type,
                    pageIndex, pageSize, ref total, ref sortCount, ref topClass);
            }
            else
            {
                //得到传入城市的景区信息
                //这个地方的  province ，的那个得是中文的 
                si = sightInfoService.GetSightListByProvinceOrCity(data.LocationSina, ref  currentClassId,
                    data.CurrentCityInfo.province, data.CurrentCityInfo.city,
                    type, pageIndex, pageSize, ref total, ref sortCount, ref topClass);
            }
            // this.TopClass = Querys.GetTopClassBySight(si);
            data.SightInfo = sightInfoService.ToPageList(si, (int)pageIndex, (int)pageSize, total - sortCount);
            data.TopClass = topClass;
            data.CurrentClassId = currentClassId;
            return data;
        }

        /// <summary>
        /// Gets the home model by prov and city and ticket.
        /// </summary>
        /// <param name="prov">The prov.</param>
        /// <param name="type">The type.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public HomeDto GetHomeModelByProvAndCityAndTicket(string prov, int? type, int? start, int? end, int? pageIndex, int? pageSize)
        {
            HomeDto data = new HomeDto();
            data.CurrentClassId = (int)type;
            //得到当前的访问者信息
            data.LocationSina = sinaInfoService.GetSinaInfo();
            data.LocaltionCityInfo = cityInfoService.GetCityInfoBySina(data.LocationSina);
            //在这里，我们得将city(拼音的)转换成中文的
            data.CurrentCityInfo = cityInfoService.GetSingleCityInfo(prov, string.Empty);
            int total = 0;
            int sortCount = 0;
            List<TopClassDto> topClass = null;
            //省的中文名查询哈
            List<DefaultSightInfoDto> si = sightInfoService.GetSightListByTicket(data.CurrentCityInfo.province,
                start, end, (int)pageIndex, (int)pageSize, ref total, ref sortCount, ref topClass);
            // this.TopClass = Querys.GetTopClassBySight(si);
            data.SightInfo = sightInfoService.ToPageList(si, (int)pageIndex, (int)pageSize, total - sortCount);
            data.TopClass = topClass;
            return data;
        }
    }
}
