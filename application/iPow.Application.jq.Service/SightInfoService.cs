using System;
using System.Collections.Generic;
using System.Linq;

using System.Data.Objects;
using Webdiyer.WebControls.Mvc;
using iPow.Application.jq.Dto;
using iPow.Application.jq.Service;
using iPow.Infrastructure.Crosscutting.Comm.Dto;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.jq.Service
{
    public class SightInfoService : ISightInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightVouchItemRepository sightVouchItemRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightTicketRepository sightTicketRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightClassRepository sightClassRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IPicInfoRepository picInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightCommRepository sightCommRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ICityInfoRepository cityInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Application.jq.Service.IAddSortService addSortService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Application.jq.Service.ITopClassService topClassService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoSortRepository sightInfoSortRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoCirHotelRepository sightInfoCirHotelRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoCirSightRepository sightInfoCirSightRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SightInfoService"/> class.
        /// </summary>
        public SightInfoService(iPow.Domain.Repository.ISightVouchItemRepository sightVouch,
             iPow.Domain.Repository.ISightTicketRepository sightTicket,
             iPow.Domain.Repository.ISightClassRepository sightClass,
             iPow.Domain.Repository.ISightInfoRepository sightInfo,
             iPow.Domain.Repository.IPicInfoRepository picInfo,
             iPow.Domain.Repository.ISightCommRepository sightComm,
             iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo,
             iPow.Domain.Repository.ICityInfoRepository cityInfo,
             iPow.Application.jq.Service.IAddSortService addSort,
             iPow.Application.jq.Service.ITopClassService topClass,
             iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService ciService,
            iPow.Domain.Repository.ISightInfoSortRepository sightInfoSort,
            iPow.Domain.Repository.ISightInfoCirHotelRepository sightInfoCirHotel,
            iPow.Domain.Repository.ISightInfoCirSightRepository sightInfoCirSight)
        {
            if (sightVouch == null)
            {
                throw new ArgumentNullException("sightvouchitem is null");
            }
            if (sightTicket == null)
            {
                throw new ArgumentNullException("sightticketrepository is null");
            }
            if (sightClass == null)
            {
                throw new ArgumentNullException("sightclassrepository is null");
            }
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (picInfo == null)
            {
                throw new ArgumentNullException("picinforepository is null");
            }
            if (sightComm == null)
            {
                throw new ArgumentNullException("sightCommRepository is null");
            }
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelpropertyinforepository is null");
            }
            if (cityInfo == null)
            {
                throw new ArgumentNullException("cityinforepository is null");
            }
            if (addSort == null)
            {
                throw new ArgumentNullException("addsortservice is null");
            }
            if (topClass == null)
            {
                throw new ArgumentNullException("topclassservice is null");
            }
            if (ciService == null)
            {
                throw new ArgumentNullException("cityinfoservice is null");
            }
            if (sightInfoSort == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            if (sightInfoCirHotel == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            if (sightInfoCirSight == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            sightVouchItemRepository = sightVouch;
            sightTicketRepository = sightTicket;
            sightClassRepository = sightClass;
            sightInfoRepository = sightInfo;
            picInfoRepository = picInfo;
            sightCommRepository = sightComm;
            hotelPropertyInfoRepository = hotelPropertyInfo;
            cityInfoRepository = cityInfo;
            addSortService = addSort;
            topClassService = topClass;
            cityInfoService = ciService;
            sightInfoSortRepository = sightInfoSort;
            sightInfoCirHotelRepository = sightInfoCirHotel;
            sightInfoCirSightRepository = sightInfoCirSight;
        }

        /// <summary>
        /// Gets the sight vouch item.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_SightVouchItemDto> GetSightVouchItem(int sid)
        {
            var res = sightVouchItemRepository.GetList(d => d.SightID == sid && d.IsDelete == 0).AsQueryable();
            return res.ToDto().AsQueryable();
        }

        /// <summary>
        /// Gets the sight ticket info.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_SightTicketDto> GetSightTicketInfo(int sid)
        {
            var res = sightTicketRepository.GetList(d => d.ParkID == sid && d.IsDelete == 0).AsQueryable();
            return res.ToDto().AsQueryable();
        }

        /// <summary>
        /// Inits the sight info. 根据城市得到景区
        /// 并分页
        /// 中文的省和名哦
        /// 数据库里面存的中文的名字，不是拼音
        /// </summary>
        /// <param name="li">The li.</param>
        /// <param name="currentClassId">The current class id.</param>
        /// <param name="province">The province.</param>
        /// <param name="city">The city or province.</param>
        /// <param name="type">The type.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <param name="total">The total.</param>
        /// <param name="sortCount">The sort count.</param>
        /// <param name="topList">The top list.</param>
        /// <returns></returns>
        public List<DefaultSightInfoDto> GetSightListByProvinceOrCity(
            LocationInfoDto li, ref  int currentClassId, string province, string city,
            int? type, int? pi, int? take, ref int total, ref int sortCount,
            ref List<iPow.Application.jq.Dto.TopClassDto> topList)
        {
            var typeList = sightClassRepository.GetList().Distinct().Select(d => d.ClassID);
            int index = (pi == null || pi < 0) ? 1 : (int)pi;
            int size = (take == null || pi < 0) ? 10 : (int)take;

            List<DefaultSightInfoDto> sightList = new List<DefaultSightInfoDto>();
            IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> temp = null;
            //根据传入城市
            if (string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(city))
            {
                #region
                if (typeList != null && typeList.Contains((int)type))
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.City == city && d.ClassID == type && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d);
                    currentClassId = (int)type;
                }
                else
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.City == city && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d);
                    currentClassId = 0;
                }
                topList = topClassService.GetTopClassBySight(temp);
                sightList = ToPageList(addSortService.SelectSightInfo(temp), index, size);
                sortCount = addSortService.AddSortSightInfoByCity(sightList, city, index, size);
                #endregion
                total = temp.Count();
            }
            //根据当前IP中的市选择
            else if (string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                #region

                if (typeList != null && typeList.Contains((int)type))
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.City == li.City && d.ClassID == type && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d);
                    currentClassId = (int)type;
                }
                else
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.City == li.City && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d);
                    currentClassId = 0;
                }
                topList = topClassService.GetTopClassBySight(temp);
                sightList = ToPageList(addSortService.SelectSightInfo(temp), index, size);
                sortCount = addSortService.AddSortSightInfoByCity(sightList, city, index, size);
                #endregion
                total = temp.Count();
            }
            //根据传入省
            else if (!string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                #region

                if (typeList != null && typeList.Contains((int)type))
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.Province == province && d.ClassID == type && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d).ToList();
                    currentClassId = (int)type;
                }
                else
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.Province == province && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d).ToList();
                    currentClassId = 0;
                }
                topList = topClassService.GetTopClassBySight(temp);
                sightList = ToPageList(addSortService.SelectSightInfo(temp), index, size);
                sortCount = addSortService.AddSortSightInfoByProvince(sightList, province, (int)pi, (int)take);
                #endregion
                total = temp.Count();
            }
            //根据传入省和市选
            else
            {
                #region

                if (typeList != null && typeList.Contains((int)type))
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.City == city && d.Province == province && d.ClassID == type && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d);
                    currentClassId = (int)type;
                }
                else
                {
                    temp = (from d in sightInfoRepository.GetList()
                            where d.City == city && d.Province == province && d.IsDelete == 0
                            orderby d.ViCount descending
                            select d);
                    currentClassId = 0;
                }
                topList = topClassService.GetTopClassBySight(temp);
                sightList = ToPageList(addSortService.SelectSightInfo(temp), index, size);
                sortCount = addSortService.AddSortSightInfoByCity(sightList, city, (int)pi, (int)take);
                #endregion
                total = temp.Count();
            }
            //添加全局排序的景区
            int global = addSortService.AddSortSightInfoByGlobal(sightList, (int)pi, (int)take);
            sortCount += global;
            total += global;
            return sightList;
        }

        /// <summary>
        /// Toes the page.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<DefaultSightInfoDto> ToPageList(IEnumerable<DefaultSightInfoDto> info, int pageIndex, int take)
        {
            return info.Skip(((pageIndex - 1) > 0 ? (pageIndex - 1) : 0) * take).Take(take).ToList();
        }

        /// <summary>
        /// Inits the sight info by ticket.
        /// 传入一个开始价格和一个结束价格，选取省
        /// </summary>
        /// <param name="prov">The prov.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <param name="total">The total.</param>
        /// <param name="sortCount">The sort count.</param>
        /// <param name="topList">The top list.</param>
        /// <returns></returns>
        public List<DefaultSightInfoDto> GetSightListByTicket(string prov, int? start, int? end,
            int pi, int take, ref int total, ref int sortCount,
            ref  List<iPow.Application.jq.Dto.TopClassDto> topList)
        {
            int index = (pi < 0) ? 1 : (int)pi;
            int size = (pi < 0) ? 10 : (int)take;

            List<DefaultSightInfoDto> sightList;
            IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> temp = null;
            if ((start == 0 || start == null) && (end == 0 || end == null))
            {
                temp = (from e in sightInfoRepository.GetList()
                        where e.Ticket <= 0 && e.Province == prov
                        orderby e.Ticket
                        select e);
            }
            else
            {
                temp = (from e in sightInfoRepository.GetList()
                        where e.Ticket >= start && e.Ticket <= end && e.Province == prov
                        orderby e.Ticket
                        select e);
            }
            topList = topClassService.GetTopClassBySight(temp);
            sightList = ToPageList(addSortService.SelectSightInfo(temp), index, size);
            sortCount = addSortService.AddSortSightInfoByProvince(sightList, prov, pi, take);
            //添加全局排序的景区
            int global = addSortService.AddSortSightInfoByGlobal(sightList, pi, take);
            sortCount += global;
            total = temp.Count() + sortCount;
            return sightList;
        }

        /// <summary>
        /// Inits the cir hotel info.
        /// 初始化当前景区附近的酒店信息列表
        /// 前10条
        /// </summary>
        /// <param name="sight">The sight.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<iPow.Domain.Dto.Sys_HotelPropertyInfoDto> GetCirHotelListBySight(iPow.Domain.Dto.Sys_SightInfoDto sight, int take)
        {
            var sightCirHotelIdList = sightInfoCirHotelRepository.GetList(e => e.SightId == sight.ParkID).Select(e => e.HotelId);
            var hi = (from e in hotelPropertyInfoRepository.GetList()
                      where sightCirHotelIdList.Contains(e.ID) &&
                      !string.IsNullOrEmpty(e.latitude) &&
                      !string.IsNullOrEmpty(e.longitude)
                      orderby e.VisitCount descending
                      select e).Take(take).ToList();

            #region modified by yjihrp 2012.3.28.16.05

            //景区表添加
            //var cir = sight.CirHotelID;
            //List<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo> hi = null;
            //if (!string.IsNullOrEmpty(cir))
            //{
            //    cir = (cir.Length > 1 && (cir.LastIndexOf(',') == 0)) ? cir.Substring(0, cir.Length - 1) : cir;
            //    string[] cirStrArray = cir.Split(',');
            //    List<int?> cirList = new List<int?>();
            //    for (int i = 0; i < cirStrArray.Length; i++)
            //    {
            //        int temp = 0;
            //        int.TryParse(cirStrArray[i], out temp);
            //        if (temp != 0)
            //        { cirList.Add(temp); }
            //    }
            //    hi = (from e in hotelPropertyInfoRepository.GetList()
            //          where cirList.Contains(e.ID) &&
            //          !string.IsNullOrEmpty(e.latitude) &&
            //          !string.IsNullOrEmpty(e.longitude)
            //          orderby e.VisitCount descending
            //          select e).Take(take).ToList();
            //}
            #endregion

            return hi.ToDto().ToList();
        }

        /// <summary>
        /// Inits the cir sight info.
        /// 初始化当前景区附近的景区信息
        /// 前10 条
        /// </summary>
        /// <param name="sight">The sight.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<iPow.Domain.Dto.Sys_SightInfoDto> GetCirSightListBySight(iPow.Domain.Dto.Sys_SightInfoDto sight, int take)
        {
            var sightCirSightIdList = sightInfoCirSightRepository.GetList(e => e.SightId == sight.ParkID).Select(e => e.CirId);
            var si = (from e in sightInfoRepository.GetList()
                      where sightCirSightIdList.Contains(e.ParkID) && e.Latitude != 0 && e.Longitude != 0
                      orderby e.ViCount descending
                      select e).Take(take).ToList();
            if (si == null)
            {
                si = new List<iPow.Infrastructure.Data.DataSys.Sys_SightInfo>();
            }
            #region 2012.3.28.15.12 modify by yjihrpg
            //数据库改变，新添加景区周边表
            //var cir = sight.CirParkID;
            //List<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> si = null;
            //if (!string.IsNullOrEmpty(cir))
            //{
            //    cir = (cir.Length > 1 && (cir.LastIndexOf(',') == 0)) ? cir.Substring(0, cir.Length - 1) : cir;
            //    string[] cirStrArray = cir.Split(',');
            //    List<int> cirList = new List<int>();
            //    for (int i = 0; i < cirStrArray.Length; i++)
            //    {
            //        int temp = 0;
            //        int.TryParse(cirStrArray[i], out temp);
            //        if (temp != 0)
            //        { cirList.Add(temp); }
            //    }
            //    si = (from e in sightInfoRepository.GetList()
            //          where cirList.Contains(e.ParkID) && e.Latitude != 0 && e.Longitude != 0
            //          orderby e.ViCount descending
            //          select e).Take(take).ToList();
            //}
            //if (si == null)
            //{
            //    si = new List<iPow.Infrastructure.Data.DataSys.Sys_SightInfo>();
            //}

            #endregion
            var dto = si.ToDto().ToList();
            dto.Insert(0, sight);
            return dto;
        }

        /// <summary>
        /// Inits the sight info.
        /// 初始化景区
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_SightInfoDto GetSightSingleById(int? sightId)
        {
            var si = (from e in sightInfoRepository.GetList() where e.ParkID == sightId select e)
                .FirstOrDefault();
            try
            {
                if (si != null)
                {
                    si.ViCount += 1;
                    sightInfoRepository.Uow.Commit();
                }
            }
            catch
            { }
            return si.ToDto();
        }

        /// <summary>
        /// Gets the sight class by id.
        /// 景区类型哈
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_SightClassDto GetSightClassById(int id)
        {
            var sc = (from e in sightClassRepository.GetList()
                      where e.ClassID == id
                      select e).FirstOrDefault();
            return sc.ToDto();
        }

        /// <summary>
        /// Inits the sight default pic info.
        /// 得到每个景区一张缩略图
        /// </summary>
        /// <param name="si">The si.</param>
        /// <returns></returns>
        public List<iPow.Domain.Dto.Sys_PicInfoDto> GetSightDefaultPic(PagedList<DefaultSightInfoDto> si)
        {
            List<iPow.Infrastructure.Data.DataSys.Sys_PicInfo> spc = new List<Infrastructure.Data.DataSys.Sys_PicInfo>();
            if (si != null)
            {
                foreach (var i in si)
                {
                    var rand = new Random();
                    var temp = (from e in picInfoRepository.GetList() where e.ParkID == i.ParkID select e).Count();
                    if (temp > 0)
                    {
                        var toKip = rand.Next(0, temp);
                        var tempPic = (from e in picInfoRepository.GetList()
                                       where e.ParkID == i.ParkID
                                       orderby e.ViewCount
                                       select e).Skip(toKip).Take(1).FirstOrDefault();
                        if (tempPic != null)
                        {
                            spc.Add(tempPic);
                        }
                    }
                }
            }
            return spc.ToDto().ToList();
        }

        /// <summary>
        /// Gets the sight pic count.
        /// 得到当前页每个景区的图片数
        /// </summary>
        /// <param name="si">The si.</param>
        /// <returns></returns>
        public Dictionary<int, int> GetSightPicCount(PagedList<DefaultSightInfoDto> si)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            List<int> sightIds = (from c in si select c.ParkID).ToList();
            var picCount = (from e in picInfoRepository.GetList()
                            where sightIds.Contains((int)e.ParkID) && e.IsDelete == 0
                            group e by e.ParkID into g
                            select new
                            {
                                id = g.Key,
                                count = g.Count()
                            }
                            ).ToDictionary(c => (int)c.id, c => c.count);
            temp = picCount;
            return temp;
        }


        /// <summary>
        /// Inits the sight comm list.
        /// 初始化当前景区的评论列表
        /// </summary>
        /// <param name="sightId">The sys_ sight info.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="defaultPageSize">Default size of the page.</param>
        /// <returns></returns>
        public PagedList<iPow.Domain.Dto.Sys_SightCommDto> GetSightCommPageListBySid(int sightId, int? pageIndex, int? defaultPageSize)
        {
            var res = sightCommRepository
                .GetList(d => d.SightID == sightId)
                .OrderByDescending(d => d.AddTime).AsEnumerable();
            var count = res.Count();
            pageIndex = pageIndex == null ? 1 : pageIndex;
            defaultPageSize = defaultPageSize == null ? 5 : defaultPageSize;
            defaultPageSize = defaultPageSize < 0 ? 5 : defaultPageSize;
            pageIndex = (pageIndex - 1) < 0 ? 0 : (pageIndex - 1);
            res = res.Skip((int)(pageIndex * defaultPageSize)).Take((int)defaultPageSize);
            var dto = res.ToDto();
            PagedList<iPow.Domain.Dto.Sys_SightCommDto> commList = new PagedList<iPow.Domain.Dto.Sys_SightCommDto>(dto, (int)pageIndex, (int)defaultPageSize, count);
            return commList;
        }

        /// <summary>
        /// Inits the sight comm list.
        /// 初始化当前景区的评论列表
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_SightCommDto> GetSightCommList(int id, int pageIndex, int take, ref int total)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_SightComm> list = null;
            var data = sightCommRepository.GetList(e => e.SightID == id)
                .OrderByDescending(e => e.AddTime);
            total = data.Count();
            list = data.Skip(((pageIndex - 1) > 0 ? (pageIndex - 1) : 0) * take)
                .Take(take).AsQueryable();
            return list.ToDto().AsQueryable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SightDetailModel"/> class.
        /// 初始化一个景区 传一个景区Id过来
        /// </summary>
        /// <param name="sid">The id.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns></returns>
        public SightDetailDto GetSightDetailModel(int? sid, int? pageIndex)
        {
            SightDetailDto data = new SightDetailDto();
            data.SightInfo = GetSightSingleById(sid);
            if (data.SightInfo != null)
            {
                data.SightInfo.ViCount += 1;
                data.CurrentSightCityInfo = cityInfoService.GetCityInfoSingleByName(data.SightInfo.Province, data.SightInfo.City);
                data.SightClass = GetSightClassById(data.SightInfo.ClassID);
                data.CirSightInfoList = GetCirSightListBySight(data.SightInfo, 9);

                //edited by yjihrp 2011.11.24.15.53
                //data.CirHotelInfoList = Bll.SightInfo.GetCirHotelListBySight(data.SightInfo, 10);
                //end edited by yjihrp 2011.11.24.15.53
            }
            return data;
        }

        /// <summary>
        /// Toes the page list.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public PagedList<DefaultSightInfoDto> ToPageList(IEnumerable<DefaultSightInfoDto> info, int pi, int take, int total)
        {
            //生成分页
            PagedList<DefaultSightInfoDto> sightInfo = new PagedList<DefaultSightInfoDto>(info, pi, take, total);
            return sightInfo;
        }

        /// <summary>
        /// Gets the sys sight single by id.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <returns></returns>
        public Infrastructure.Data.DataSys.Sys_SightInfo GetSysSightSingleById(int? sightId)
        {
            var si = (from e in sightInfoRepository.GetList() where e.ParkID == sightId select e)
              .FirstOrDefault();
            return si;
        }

        // add by JPomichael
        /// <summary>
        /// 根据City 查询该城市下的景点  + Pageing
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_SightInfoDto> GetSightSingleByCity(string city)
        {
            var res = sightInfoRepository.GetList(d => d.City == city).AsQueryable();
            return res.ToDto().AsQueryable();
        }
    }
}