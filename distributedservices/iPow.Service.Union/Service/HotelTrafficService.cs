using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using iPow.Infrastructure.Data.DataSys;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Service.Union.Service
{
    public class HotelTrafficService : IHotelTrafficService
    {
        ICityService cityService = null;

        IHotelInfoService hotelInfoService = null;

        iPow.Domain.Repository.ICityAreaCodeRepository cityAreaCodeRepository = null;

        IHotelAroundHotelService hotelAroundHotelService = null;

        iPow.Domain.Repository.ISightInfoRepository sightInfoRepository = null;

        public int Take { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelTrafficService"/> class.
        /// </summary>
        /// <param name="hiService">The hi service.</param>
        /// <param name="ciService">The ci service.</param>
        public HotelTrafficService(IHotelInfoService hiService,
            ICityService ciService,
            iPow.Domain.Repository.ICityAreaCodeRepository cityAreaCode,
            IHotelAroundHotelService hahService,
            iPow.Domain.Repository.ISightInfoRepository sightInfo)
        {
            if (hiService == null)
            {
                throw new ArgumentNullException("ihotelinfoservice is null");
            }
            if (ciService == null)
            {
                throw new ArgumentNullException("cityservice is null");
            }
            if (cityAreaCode == null)
            {
                throw new ArgumentNullException("cityareacoderepository is null");
            }
            if (hahService == null)
            {
                throw new ArgumentNullException("hotelaroundhotelservice is null");
            }
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            hotelInfoService = hiService;
            cityService = ciService;
            cityAreaCodeRepository = cityAreaCode;
            hotelAroundHotelService = hahService;
            sightInfoRepository = sightInfo;
            Take = 10;
        }

        /// <summary>
        /// Gets the hotel traffic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public iPow.Application.Union.Dto.HotelTrafficDto GetHotelTrafficById(string id)
        {
            iPow.Application.Union.Dto.HotelTrafficDto data = new iPow.Application.Union.Dto.HotelTrafficDto();
            iPow.Application.Union.Dto.HotelInfoDto hi = hotelInfoService.GetHotelInfoById(id);
            if (hi.id > 0)
            {
                data.SigleHotelInfo = hi;
                data.HotelId = int.Parse(id);
                var cityName = cityService.GetUnionCityNameById(hi.cid);
                var cityArea = cityAreaCodeRepository.GetList(d => d.city.Contains(cityName)).FirstOrDefault();
                if (cityArea != null)
                {
                    data.HotelAreaCode = cityArea.areacode;

                }
                var arroundHotel = new List<iPow.Application.Union.Dto.HotelInfoDto>();
                arroundHotel.Add(hi);
                arroundHotel.AddRange(hotelAroundHotelService.GetHotelAroundHotelById(id));
                arroundHotel = arroundHotel.OrderBy(d => d.id).Take(Take).ToList();
                data.HotelInfo = arroundHotel;
                string pos = hi.hotelpos.Replace("(", "");
                pos = pos.Replace(")", "");
                var posList = pos.Split(',').ToList();
                if (posList.Count == 2)
                {
                    var lat = double.Parse(posList[0]);//纬度
                    var lon = double.Parse(posList[1]);//经度
                    data.SightInfo = GetHotelAroundSightByLat(cityName, lat, lon, Take).ToList();
                }
            }
            return data;
        }

        /// <summary>
        /// Gets the hotel around sight by lat.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<iPow.Domain.Dto.Sys_SightInfoDto> GetHotelAroundSightByLat(string cityName, double lat, double lon, int take)
        {
            cityName = cityName.Replace("市", "");
            List<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> res = new List<Sys_SightInfo>();
            //在数据库中 按 要添加景区的城市 选景区
            var sightList = sightInfoRepository.GetList(e => e.Latitude != 0)
                .Where(e => e.Longitude != 0)
                .Where(e => e.City.Contains(cityName));
            if (sightList != null && sightList.Count() > 0)
            {
                foreach (var item in sightList)
                {
                    //算周边景区，
                    if (CirPoint(lat, lon, (double)item.Latitude, (double)item.Longitude, 0.1))
                    {
                        res.Add(item);
                    }
                }
            }
            res = res.OrderBy(e => e.ViCount).Take(take).ToList();
            return res.ToDto().ToList();
        }


        /// <summary>
        /// Cirs the point.
        /// </summary>
        /// <param name="x">The current x.</param>
        /// <param name="y">The current y.</param>
        /// <param name="xt">The xt.</param>
        /// <param name="yr">The yr.</param>
        /// <param name="cir">The cir.</param>
        /// <returns></returns>
        public bool CirPoint(double x, double y, double xt, double yr, double cir)
        {
            bool tar = false;
            double xAbs = System.Math.Abs(x - xt);
            double yAbs = System.Math.Abs(y - yr);
            if (xAbs <= cir && yAbs <= cir)
            {
                tar = true;
            }
            return tar;
        }
    }
}