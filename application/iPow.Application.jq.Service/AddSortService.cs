using System;
using System.Collections.Generic;
using System.Linq;

using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class AddSortService : IAddSortService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightCommRepository sightCommRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightClassRepository sightClassRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IPicInfoRepository picInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ICityInfoRepository cityInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoSortRepository sightInfoSortRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="AddSortService"/> class.
        /// </summary>
        /// <param name="sightInfo">The sight info.</param>
        public AddSortService(iPow.Domain.Repository.ISightInfoRepository sightInfo,
            iPow.Domain.Repository.ISightCommRepository sightComm,
            iPow.Domain.Repository.ISightClassRepository sightClass,
            iPow.Domain.Repository.IPicInfoRepository picInfo,
            iPow.Domain.Repository.ICityInfoRepository cityInfo,
            iPow.Domain.Repository.ISightInfoSortRepository sightInfoSort)
        {
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (sightComm == null)
            {
                throw new ArgumentNullException("sightCommRepository is null");
            }
            if (sightClass == null)
            {
                throw new ArgumentNullException("sightClassRepository is null");
            }
            if (picInfo == null)
            {
                throw new ArgumentNullException("picInfoRepository is null");
            }
            if (cityInfo == null)
            {
                throw new ArgumentNullException("cityInfoRepository is null");
            }
            if (sightInfoSort == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            sightInfoRepository = sightInfo;
            sightCommRepository = sightComm;
            sightClassRepository = sightClass;
            picInfoRepository = picInfo;
            cityInfoRepository = cityInfo;
            sightInfoSortRepository = sightInfoSort;
        }

        /// <summary>
        /// Adds the sort sight info by city.
        /// 根据城市添加，要排序的城市不为0的景区
        /// 这个的优级和省的优做级一样
        /// sourceInfo 根据城市选出来的景区
        /// aim 要添加排名的景区
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="city">The city.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        public int AddSortSightInfoByCity(List<DefaultSightInfoDto> sourceInfo, string city, int pi, int take)
        {
            var citySortSightInfoList = sightInfoSortRepository.GetList(e => e.Target.Contains(city) && e.Type == 1).OrderBy(e => e.SortNum);
            foreach (var item in citySortSightInfoList)
            {
                var temp = sightInfoRepository.GetList(e => e.ParkID == item.SightId);
                var newTemp = SelectSightInfo(temp).FirstOrDefault();
                if (sourceInfo.Contains(newTemp))
                {
                    sourceInfo.Remove(newTemp);
                }
                AddSortBase(sourceInfo, newTemp, (int)item.SortNum, pi, take);
            }
            return citySortSightInfoList.Count();
        }

        /// <summary>
        /// Adds the sort sight info by province.
        /// 根据省添加，要排序的省不为0的景区
        /// 这个的优级和省的优做级一样
        /// sourceInfo 根据省选出来的景区
        /// aim 要添加排名的景区
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="prov">The prov.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        public int AddSortSightInfoByProvince(List<DefaultSightInfoDto> sourceInfo, string prov, int pi, int take)
        {
            var provSortSightInfoList = sightInfoSortRepository.GetList(e => e.Target.Contains(prov) && e.Type == 2).OrderBy(e => e.SortNum);
            foreach (var item in provSortSightInfoList)
            {
                var temp = sightInfoRepository.GetList(e => e.ParkID == item.SightId);
                var newTemp = SelectSightInfo(temp).FirstOrDefault();
                if (sourceInfo.Contains(newTemp))
                {
                    sourceInfo.Remove(newTemp);
                }
                AddSortBase(sourceInfo, newTemp, (int)item.SortNum, pi, take);
            }
            return provSortSightInfoList.Count();
        }

        /// <summary>
        /// Adds the sort sight info.
        /// 用于添加强制排名景区的 这个是全局性的，最大优先
        /// </summary>
        /// <param name="sourceInfo">The sight.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <returns></returns>
        public int AddSortSightInfoByGlobal(List<DefaultSightInfoDto> sourceInfo, int pi, int take)
        {
            var globalSortSightInfoList = sightInfoSortRepository.GetList(e => e.Type == 3).OrderBy(e => e.SortNum);
            foreach (var item in globalSortSightInfoList)
            {
                var temp = sightInfoRepository.GetList(e => e.ParkID == item.SightId);
                var newTemp = SelectSightInfo(temp).FirstOrDefault();
                if (sourceInfo.Contains(newTemp))
                {
                    sourceInfo.Remove(newTemp);
                }
                AddSortBase(sourceInfo, newTemp, (int)item.SortNum, pi, take);
            }
            return globalSortSightInfoList.Count();
        }

        /// <summary>
        /// Adds the sort.
        /// 添加的通用方法
        /// sourceInfo 要添加到的景区列表
        /// tar 要添加的景区
        /// num 位置
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="tar">The tar.</param>
        /// <param name="num">The num.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public void AddSortBase(List<DefaultSightInfoDto> sourceInfo,
            DefaultSightInfoDto tar, int num, int pageIndex, int pageSize)
        {
            if (sourceInfo.Contains(tar))
            {
                sourceInfo.Remove(tar);
            }
            //5 item.sortCityNum
            //1-10  (pageIndex - 1) * pageSize)   -   pageIndex * pageSize
            bool isInPage = (
               num > 0 && num >
                ((pageIndex - 1) * pageSize) &&
                (num <= pageIndex * pageSize)
                ) ? true : false;
            if (isInPage)
            {
                int per = num - ((pageIndex - 1) * pageSize) - 1;
                if (per >= sourceInfo.Count)
                {
                    sourceInfo.Insert(sourceInfo.Count - 1, tar);
                }
                else
                {
                    sourceInfo.Insert(per, tar);
                }

            }
        }

        /// <summary>
        /// Selects the sight info.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        public IEnumerable<DefaultSightInfoDto> SelectSightInfo(IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> info)
        {
            var data = info.Select(e => new DefaultSightInfoDto
            {
                Remark = e.Remark,
                WantCount = e.WantCount,
                City = e.City,
                ParkID = e.ParkID,
                Province = e.Province,
                Py = e.PY,
                Ticket = e.Ticket,
                Title = e.Title,
                Type = sightClassRepository.GetList(d => d.ClassID == e.ClassID).Select(d => d.ClassName).FirstOrDefault(),
                VoIndex = e.VoIndex,
                ViCount = e.ViCount,
                GoCount = e.GoCount,
                IsShort = e.IsShort,
                Address = e.Address,
                PicCount = picInfoRepository.GetList().Where(d => d.ParkID == e.ParkID).Count(),
                CommCount = sightCommRepository.GetList().Where(d => d.SightID == e.ParkID).Count(),
                CityPy = cityInfoRepository.GetList(d => d.city == e.City && d.province == e.Province).Select(d => d.pinyin).FirstOrDefault(),
                ProvPy = cityInfoRepository.GetList(d => d.city == e.City && d.province == e.Province).Select(d => d.ProvincePy).FirstOrDefault(),
                Lat = e.Latitude,
                Long = e.Longitude,
                Url = e.Url
            });
            return data;
        }

    }
}