using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Domain.Dto;
using Webdiyer.WebControls.Mvc;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.dj.Service
{
    public class TourPlanService : ITourPlanService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ITourClassRepository tourClassRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ISightInfoRepository sightInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ISightClassRepository sightClassRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IHotelCommRepository hotelCommRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IHotelPicRepository hotelPicRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ISightCommRepository sightCommRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IPicInfoRepository picInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Application.jq.Service.ISightInfoService sightInfoService = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Service.Union.Service.ICityService unionCityService = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Service.Union.Service.IHotelLeftMidService hotelLeftMidService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TourPlanService"/> class.
        /// </summary>
        /// <param name="tourPlan">The tour plan.</param>
        /// <param name="tourPlanDetail">The tour plan detail.</param>
        /// <param name="tourClass">The tour class.</param>
        /// <param name="sightInfo">The sight info.</param>
        /// <param name="sightClass">The sight class.</param>
        /// <param name="hotelComm">The hotel comm.</param>
        /// <param name="hotelPropertyInfo">The hotel property info.</param>
        /// <param name="hotelPic">The hotel pic.</param>
        /// <param name="sightComm">The sight comm.</param>
        /// <param name="picInfo">The pic info.</param>
        /// <param name="siService">The si service.</param>
        /// <param name="ucityService">The ucity service.</param>
        /// <param name="hlmService">The HLM service.</param>
        public TourPlanService(iPow.Domain.Repository.ITourPlanRepository tourPlan,
            iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail,
            iPow.Domain.Repository.ITourClassRepository tourClass,
            iPow.Domain.Repository.ISightInfoRepository sightInfo,
            iPow.Domain.Repository.ISightClassRepository sightClass,
            iPow.Domain.Repository.IHotelCommRepository hotelComm,
            iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo,
            iPow.Domain.Repository.IHotelPicRepository hotelPic,
            iPow.Domain.Repository.ISightCommRepository sightComm,
            iPow.Domain.Repository.IPicInfoRepository picInfo,
            iPow.Application.jq.Service.ISightInfoService siService,
            iPow.Service.Union.Service.ICityService ucityService,
            iPow.Service.Union.Service.IHotelLeftMidService hlmService
                 )
        {
            if (tourPlan == null)
            {
                throw new ArgumentNullException("tourPlanRepository is null");
            }
            if (tourPlanDetail == null)
            {
                throw new ArgumentNullException("tourPlanDetailRepository is null");
            }
            if (tourClass == null)
            {
                throw new ArgumentNullException("tourclassrepository is null");
            }
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (sightClass == null)
            {
                throw new ArgumentNullException("sightclassrepository is null");
            }

            if (hotelComm == null)
            {
                throw new ArgumentNullException("hotelcommrepository is null");
            }
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelpropertyinforepository is null");
            }
            if (hotelPic == null)
            {
                throw new ArgumentNullException("hotelpicrepository is null");
            }

            if (sightComm == null)
            {
                throw new ArgumentNullException("sightcommrepository is null");
            }
            if (picInfo == null)
            {
                throw new ArgumentNullException("picinforepository is null");
            }
            if (siService == null)
            {
                throw new ArgumentNullException("sightinfoservice is null");
            }
            if (ucityService == null)
            {
                throw new ArgumentNullException("unionCityService is null");
            }
            if (ucityService == null)
            {
                throw new ArgumentNullException("hotelleftmidservice is null");
            }
            tourPlanRepository = tourPlan;
            tourPlanDetailRepository = tourPlanDetail;
            tourClassRepository = tourClass;
            sightInfoRepository = sightInfo;
            sightClassRepository = sightClass;
            hotelCommRepository = hotelComm;
            hotelPropertyInfoRepository = hotelPropertyInfo;
            hotelPicRepository = hotelPic;
            sightCommRepository = sightComm;
            picInfoRepository = picInfo;
            sightInfoService = siService;
            unionCityService = ucityService;
            hotelLeftMidService = hlmService;
        }
        //用于根据城市查询路线并分页
        public IQueryable<Dto.TopTourPlanDto> GetTourPlanListByCity(string city, int pi, int take, ref int total)
        {
            IQueryable<Dto.TopTourPlanDto> temp = null;
            if (!string.IsNullOrEmpty(city))
            {
                temp = tourPlanRepository.GetList(d => d.Destination != null)
                    .Where(d => d.Destination.Contains(city))
                    .Where(d => d.IsDelete == 0 || d.IsDelete == null)
                    .Select(e => new Dto.TopTourPlanDto
                    {
                        Id = e.PlanID,
                        PlanTitle = e.PlanTitle,
                        Days = e.Days,
                        TopReason = e.Destination,
                        PlanTotalMoney =
                        tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                        UserName = e.UserName,
                        ViCount = e.VisitCount,
                        ClassId = e.PlanClass
                    }).AsQueryable(); ;
            }
            else
            {
                temp = (from e in tourPlanRepository.GetList()
                        where (e.IsDelete == 0 || e.IsDelete == null)
                        orderby e.VisitCount descending
                        select new Dto.TopTourPlanDto
                        {
                            Id = e.PlanID,
                            PlanTitle = e.PlanTitle,
                            Days = e.Days,
                            TopReason = e.Destination,
                            PlanTotalMoney = tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                            UserName = e.UserName,
                            ViCount = e.VisitCount,
                            ClassId = e.PlanClass
                        }
                   ).AsQueryable();
            }
            return temp;
        }
        /// <summary>
        /// Gets the tour plan list.
        /// 首页上有一个推荐的城市
        /// 当点击一个城市时，取前几天数据，vicount
        /// 如果没有城市的话，就按vicount取
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public IQueryable<Dto.TopTourPlanDto> GetTourPlanListByCity(string city, int take)
        {
            IQueryable<Dto.TopTourPlanDto> temp = null;
            if (!string.IsNullOrEmpty(city))
            {
                temp = tourPlanRepository.GetList(d => d.Destination != null)
                    .Where(d => d.Destination.Contains(city))
                    .Where(d => d.IsDelete == 0 || d.IsDelete == null)
                    .Select(e => new Dto.TopTourPlanDto
                    {
                        Id = e.PlanID,
                        PlanTitle = e.PlanTitle,
                        Days = e.Days,
                        TopReason = e.Destination,
                        PlanTotalMoney =
                        tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                        UserName = e.UserName,
                        ViCount = e.VisitCount,
                        ClassId = e.PlanClass
                    }).OrderByDescending(d => d.ViCount).Take(take).AsQueryable();
            }
            else
            {
                temp = (from e in tourPlanRepository.GetList()
                        where (e.IsDelete == 0 || e.IsDelete == null)
                        orderby e.VisitCount descending
                        select new Dto.TopTourPlanDto
                        {
                            Id = e.PlanID,
                            PlanTitle = e.PlanTitle,
                            Days = e.Days,
                            TopReason = e.Destination,
                            PlanTotalMoney = tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                            UserName = e.UserName,
                            ViCount = e.VisitCount,
                            ClassId = e.PlanClass
                        }
                    ).Take(take).AsQueryable();
            }
            return temp;
        }

        /// <summary>
        /// Gets the hot tour plan list.
        /// 这个方法没有用过
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_TourPlanDto> GetHotTourPlanList(int top)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_TourPlan> temp = null;
            temp = (from e in tourPlanRepository.GetList()
                    where (e.IsDelete == 0 || e.IsDelete == null)
                    orderby e.VisitCount
                    select e
                ).Take(top).AsQueryable();
            return temp.ToDto().AsQueryable();
        }

        /// <summary>
        /// Gets the top tour plan city list.
        /// 得到推荐的路线的城市
        /// 本来还有一个ID的，没有赋值哈
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns></returns>
        public IQueryable<Dto.TopTourCityDto> GetTopTourPlanCity(int top)
        {
            IQueryable<Dto.TopTourCityDto> temp = null;
            temp = (from e in tourPlanRepository.GetList()
                    where (e.IsDelete == 0 || e.IsDelete == null) &&
                    e.IsTop == 1
                    group e by e.Destination into g
                    orderby g.Count()
                    select new Dto.TopTourCityDto
                    {
                        CityName = tourPlanRepository.GetList(e => e.Destination == g.Key).FirstOrDefault().Destination,
                    }).Take(top).AsQueryable().Distinct();
            return temp;
        }

        /// <summary>
        /// Gets the tour class.
        /// 得到路线的分类哈
        /// </summary>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_TourClassDto> GetTourClass()
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_TourClass> temp = null;
            temp = tourClassRepository.GetList(d => d.IsDelete == 0).Where(d => d.ParentID == 0).AsQueryable();
            return temp.ToDto().AsQueryable();
        }

        /// <summary>
        /// 根据City  Create User DIY Tour
        /// </summary>
        /// <param name="tour"></param>
        public iPow.Infrastructure.Data.DataSys.Sys_TourPlan AddTourPlan(iPow.Infrastructure.Data.DataSys.Sys_TourPlan tour)
        {
            var data = new iPow.Infrastructure.Data.DataSys.Sys_TourPlan();
            data.AddTime = tour.AddTime;
            data.Days = tour.Days;
            data.Destination = tour.Destination;
            data.IsDelete = 0;
            data.IsTop = 0;
            data.PlanClass = null;
            data.PlanTitle = tour.PlanTitle;
            data.Remark = tour.PlanTitle;
            data.TempDataCreateHtml = null;
            data.TopReason = "";
            data.TopTime = null;
            data.UserId = tour.UserId;
            data.UserName = tour.UserName;
            data.VisitCount = 0;
            try
            {
                tourPlanRepository.Add(data);
                tourPlanRepository.Uow.Commit();
            }
            catch (Exception)
            {
                throw new ArgumentException("添加失败！");
            }
            iPow.Infrastructure.Data.DataSys.Sys_TourPlan res = tourPlanRepository.GetList(e => e.PlanTitle == tour.PlanTitle).First();
            return res;
        }

        /// <summary>
        /// 用于修改DIY线路的
        /// </summary>
        /// <param name="tour"></param>
        /// <returns></returns>
        public iPow.Infrastructure.Data.DataSys.Sys_TourPlan UpdateTourPlan(iPow.Infrastructure.Data.DataSys.Sys_TourPlan tour)
        {
            tourPlanRepository.Modify(tour);
            tourPlanRepository.Uow.Commit();
            iPow.Infrastructure.Data.DataSys.Sys_TourPlan res = tourPlanRepository.GetList(e => e.PlanID == tour.PlanID).First();
            return res;
        }

        /// <summary>
        /// GetUserDIYByID
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        public iPow.Infrastructure.Data.DataSys.Sys_TourPlan GetTourPlanByID(int planID)
        {
            var data = new iPow.Infrastructure.Data.DataSys.Sys_TourPlan();
            data = tourPlanRepository.GetList(e => e.PlanID == planID).First();
            return data;
        }

        /// <summary>
        /// Check UserDIYIsExist   By JPomichael
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="PlanTitle"></param>
        /// <returns></returns>
        public bool CheckTourPlanIsExist(int userId, string PlanTitle)
        {
            var res = tourPlanRepository.GetList(e => e.PlanTitle == PlanTitle).Where(e => e.UserId == userId).Any();
            return res;
        }

        #region 路线详细页用到

        /// <summary>
        /// Gets the tour detail top by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Dto.TourDetailTopDto GetTourDetailTopById(int id)
        {
            Dto.TourDetailTopDto data = null;
            data = tourPlanRepository.GetList(e => e.PlanID == id)
                .Select(e => new Dto.TourDetailTopDto
                {
                    Id = e.PlanID,
                    PlanTitle = e.PlanTitle,
                    PlanTotalMoney = tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                    Days = e.Days
                }).FirstOrDefault();
            return data;
        }

        public Sys_TourPlanDto GetTourPlanByName(string Name)
        {
            Sys_TourPlanDto data = null;
            data = tourPlanRepository.GetList(e => e.PlanTitle == Name)
               .Select(e => new Sys_TourPlanDto
               {
                   PlanID = e.PlanID,
                   Days = e.Days
               }).FirstOrDefault();
            return data;
        }


        /// <summary>
        /// Gets the sight or hotel id list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="type">The type.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public List<int?> GetSightOrHotelIdList(int id, string type, int day)
        {
            var sightList = tourPlanDetailRepository.GetList(e => e.PlanID == id)
                .Where(e => e.DetailType == type)
                .Where(e => e.DayID == day)
                .Select(e => e.SightIDOrHotelID)
                .ToList();
            return sightList;
        }

        /// <summary>
        /// Gets the tour detail sight by id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public IQueryable<Dto.TourDetailSightDto> GetTourDetailSightByIdAndDay(int id, int day)
        {
            IQueryable<Dto.TourDetailSightDto> data = null;
            var sightList = GetSightOrHotelIdList(id, "sight", day);
            data = sightInfoRepository.GetList(e => sightList.Contains(e.ParkID))
                .Select(e => new Dto.TourDetailSightDto
            {
                SightId = e.ParkID,
                Name = e.Title,
                Py = e.PY,
                Address = e.Address,
                OpToTime = e.OpToTime,
                ShowHours = e.ShopHours,
                Ticket = e.Ticket,
                PlanId = id,
                Type = sightClassRepository.GetList(d => d.ClassID == e.ClassID).Select(d => d.ClassName).FirstOrDefault(),
                Lat = e.Latitude,
                Long = e.Longitude
            }).AsQueryable();
            return data;
        }

        /// <summary>
        /// Gets the tour detail hotel by id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public IQueryable<Dto.TourDetailHotelDto> GetTourDetailHotelByIdAndDay(int id, int day)
        {
            IQueryable<Dto.TourDetailHotelDto> data = null;
            var hotelList = GetSightOrHotelIdList(id, "hotel", day);
            data = hotelPropertyInfoRepository.GetList(e => hotelList.Contains(e.ID))
                .Select(e => new Dto.TourDetailHotelDto
                {
                    Address = e.Address,
                    HotelId = e.HotelID,
                    IdentityId = e.ID,
                    MinPrice = (e.MinPrice == null ? 0.0 : e.MinPrice),
                    Name = e.HotelName,
                    PlanId = id,
                    Type = e.HotelClass
                }).AsQueryable();
            return data;
        }

        /// <summary>
        /// Gets the map sight info by tour id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public IQueryable<Dto.MapSightInfoDto> GetMapSightInfoByTourIdAndDay(int id, int day)
        {
            IQueryable<Dto.MapSightInfoDto> data = null;
            var trueSightList = GetSightOrHotelIdList(id, "sight", day);
            var nearSightList = sightInfoRepository.GetList(e => trueSightList.Contains(e.ParkID))
                .Select(e => e.CirParkID);
            List<int?> sightIdList = new List<int?>();
            if (nearSightList != null && nearSightList.Count() > 0)
            {
                string[] array = null;
                foreach (var item in nearSightList)
                {
                    array = item.Split(',');
                    if (array.Length > 0)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(array[i]))
                            {
                                try
                                {
                                    sightIdList.Add(int.Parse(array[i]));
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            sightIdList.AddRange(trueSightList);
            data = sightInfoRepository.GetList(e => sightIdList.Contains(e.ParkID))
              .Select(e => new Dto.MapSightInfoDto
              {
                  SightId = e.ParkID,
                  Name = e.Title,
                  Py = e.PY,
                  Address = e.Address,
                  Ticket = e.Ticket,
                  Type = sightClassRepository.GetList(d => d.ClassID == e.ClassID).Select(d => d.ClassName).FirstOrDefault(),
                  Lat = e.Latitude,
                  Long = e.Longitude,
                  CommCount = sightCommRepository.GetList(d => d.ParentID == e.ParkID).Count(),
                  ImgCount = picInfoRepository.GetList(d => d.ParkID == e.ParkID).Count()
              }).AsQueryable();

            return data;
        }

        /// <summary>
        /// Gets the map union hotel info by tour id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        public iPow.Application.Union.Dto.SearchHotelDto GetMapUnionHotelInfoByTourIdAndDay(int id, int day)
        {
            iPow.Application.Union.Dto.SearchHotelDto data = new Union.Dto.SearchHotelDto();
            data.hotel_list = new List<Union.Dto.SearchHotelDetailDto>();
            data.page = 0;
            data.total = 0;
            var trueSightList = GetSightOrHotelIdList(id, "sight", day);
            if (trueSightList.Count > 0)
            {
                var cityName = "";
                var cid = 0;
                for (int i = 0; i < trueSightList.Count; i++)
                {
                    if (trueSightList[i] > 0)
                    {
                        var temp = sightInfoService.GetSightSingleById(trueSightList[i]);
                        cityName = temp.City.Replace("市", "");
                        cid = unionCityService.GetUnionCityIdByName(cityName);
                        if (cid > 0 && temp.Latitude > 0 && temp.Longitude > 0)
                        {
                            var intime = System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_");
                            string latlon = "";
                            string strMin = "0";
                            string strMax = "0";
                            latlon = "(" + temp.Latitude.ToString() + "," + temp.Longitude.ToString() + ")";
                            var cirHotelInfoList = hotelLeftMidService.GetMidHotHotelByLatLong(intime, cityName, System.Web.HttpUtility.UrlEncode(latlon), "1", strMin, strMax);
                            if (cirHotelInfoList != null && cirHotelInfoList.hotel_list.Count > 0)
                            {
                                data.total += cirHotelInfoList.total;
                                data.hotel_list.AddRange(cirHotelInfoList.hotel_list);
                            }
                        }
                    }
                }
                data.page = (data.hotel_list.Count / 10) == 0 ? (data.hotel_list.Count / 10) : (data.hotel_list.Count / 10) + 1;
            }
            return data;
        }

        //版本改变，这方法不用，原来用自己的数据的时候用的，现在，用union数据
        /// <summary>
        /// Gets the map hotel info by tour id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>

        public IQueryable<Dto.MapHotelInfoDto> GetMapHotelInfoByTourIdAndDay(int id, int day)
        {
            IQueryable<Dto.MapHotelInfoDto> data = null;
            var trueSightList = GetSightOrHotelIdList(id, "hotel", day);
            var nearHotelList = hotelPropertyInfoRepository.GetList(e => trueSightList.Contains(e.ID))
                .Select(e => e.CirHotelID);
            List<int?> hotelIdList = new List<int?>();
            if (nearHotelList != null && nearHotelList.Count() > 0)
            {
                string[] array = null;
                foreach (var item in nearHotelList)
                {
                    array = item.Split(',');
                    if (array.Length > 0)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(array[i]))
                            {
                                try
                                {
                                    hotelIdList.Add(int.Parse(array[i]));
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            hotelIdList.AddRange(trueSightList);

            data = hotelPropertyInfoRepository.GetList(e => hotelIdList.Contains(e.ID))
             .Select(e => new Dto.MapHotelInfoDto
             {
                 Name = e.HotelName,
                 Address = e.Address,
                 Type = e.HotelClass,
                 Lat = e.latitude,
                 Long = e.longitude,
                 CommCount = hotelCommRepository.GetList(d => d.HotelID == e.ID).Count(),
                 HotelId = e.HotelID,
                 IdentityId = e.ID,
                 MinPrice = e.MinPrice == null ? 0 : e.MinPrice,
                 PicCount = hotelPicRepository.GetList(d => d.HotelID == e.HotelID).Count()
             }).AsQueryable();

            return data;
        }

        #endregion

        #region dj use maybe hotel used

        /// <summary>
        /// Gets the hotel default pic by hotel id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public string GetHotelDefaultPicByHotelId(int id)
        {
            string data = string.Empty;
            var r = new Random();
            var temp = hotelPicRepository.GetList(e => e.HotelID == id).Count();
            if (temp > 0)
            {
                var toSkip = r.Next(0, temp);
                var pic = hotelPicRepository.GetList(e => e.HotelID == id)
                    .OrderByDescending(e => e.PicID)
                    .Skip(toSkip)
                    .Take(1)
                    .Select(e => new
                    {
                        picPath = e.PicPath,
                        picName = e.PicName
                    }).FirstOrDefault();
                if (pic != null)
                {
                    if (!string.IsNullOrEmpty(pic.picName) && !string.IsNullOrEmpty(pic.picPath))
                    {
                        data = pic.picPath + pic.picName;
                    }
                }
            }
            return data;
        }
        #endregion

        /// <summary>
        /// 根据UserID 查询其所有已添加的TourPlan
        /// </summary>
        /// <param name="Id"></param>
        public PagedList<Sys_TourPlanDto> GetTourPlanListByUserId(int userId, int pi, int take)
        {

            var res = tourPlanRepository.GetList().Where(e => e.IsDelete == 0 || e.IsDelete == null || e.UserId == userId)
                .OrderByDescending(e => e.AddTime).AsEnumerable();
            int total = res.Count();
            res = res.Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take).Take(take).AsEnumerable();
            var temp = new Webdiyer.WebControls.Mvc.PagedList<iPow.Domain.Dto.Sys_TourPlanDto>(res.ToDto(), pi, take, total);
            return temp;
        }

        /// <summary>
        /// 询其所有Plan
        /// </summary>
        /// <param name="Id"></param>
        public PagedList<Sys_TourPlanDto> GetTourPlanList(int pi, int take)
        {
            var res = (from e in tourPlanRepository.GetList()
                       where (e.IsDelete == 0 || e.IsDelete == null)
                       orderby e.AddTime descending
                       select e
                       ).AsEnumerable();
            int total = res.Count();
            res = res.Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take).Take(take).AsEnumerable();
            var temp = new Webdiyer.WebControls.Mvc.PagedList<iPow.Domain.Dto.Sys_TourPlanDto>(res.ToDto(), pi, take, total);
            return temp;
        }

        /// <summary>
        /// 用来推荐热门线路
        /// </summary>
        /// <returns name="Top 10"></returns>
        public IEnumerable<Sys_TourPlanDto> GetHotPlan()
        {
            var res = tourPlanRepository.GetList().Where(e => e.IsDelete == 0 || e.IsDelete == null)
                .OrderByDescending(e => e.VisitCount).AsEnumerable();
            res = res.Take(10).AsEnumerable();
            return res.ToDto();
        }
    }
}