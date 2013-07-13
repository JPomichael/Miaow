using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;
using iPow.Application.dj.Dto;
using iPow.Infrastructure.Data.DataSys;

namespace iPow.Presentation.dj.Controllers
{
    [HandleError]
    public class SearchController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        //定义每页显示多少条
        const int pageSize = 4;

        iPow.Application.dj.Service.ISearchService searchService;

        iPow.Domain.Repository.ISearchInfoRepository searchInfoReopsitory;

        public SearchController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Application.dj.Service.ISearchService ipowSearchServer,
            iPow.Domain.Repository.ISearchInfoRepository searchInfo)
            : base(work)
        {
            if (ipowSearchServer == null)
            {
                throw new ArgumentNullException("searchService is null");
            }
            if (searchInfo == null)
            {
                throw new ArgumentNullException("searchInfoReopsitory is null");
            }
            searchService = ipowSearchServer;
            searchInfoReopsitory = searchInfo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(FormCollection f)
        {
            SearchInfoDto data = new SearchInfoDto();
            if (f["txtDays"] != null)
            {
                //字符串表现形式转换为等同它的32位有效字符
                data.Days = int.Parse(f["txtDays"].ToString()); 
            }
            if (f["txtMoney"] != null)
            {
                data.Money = int.Parse(f["txtMoney"].ToString());
            }
            if (f["txtSearch"] != null)
            {
                data.Bide = f["txtSearch"].ToString();
            }
            if (f["RadioGroup1"] != null)
            {
                data.Type = f["RadioGroup1"].ToString();
            }
            int total = 0;
            IQueryable<SearchTourDto> iq = searchService.GetSearchTourModel(data, 1, pageSize, ref total);
            PagedList<SearchTourDto> model = new PagedList<SearchTourDto>(iq, 1, pageSize, total);
            data.Bide = Server.UrlEncode(data.Bide);
            ViewBag.para = data;

            #region add

            var searchInfo = new Sys_SearchInfo();
            searchInfo.Ip = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
            if (searchInfo.Ip.Equals("::1"))
            {
                searchInfo.Ip = "127.0.0.1";
            }
            searchInfo.KeyWord = Server.UrlDecode(data.Bide);
            //searchInfo.SearchID = searchInfoReopsitory.GetList().Max(d=> d.);
            searchInfo.AddTime = System.DateTime.Now;
            searchInfo.City = String.Empty;
            try
            {
                searchInfoReopsitory.Add(searchInfo);
                searchInfoReopsitory.Uow.Commit();
            }
            catch (Exception ex)
            {
                string massage = ex.Message;
            }
            #endregion

            return View(model);
        }

        public ActionResult Result(string b, int d, string t, int p, int pi)
        {
            SearchInfoDto data = new SearchInfoDto();
            data.Bide = Server.UrlDecode(b);
            data.Days = d;
            data.Type = t;
            data.Money = p;
            int total = 0;
            IQueryable<SearchTourDto> iq = searchService.GetSearchTourModel(data, (pi <= 0 ? 1 : pi), pageSize, ref total);
            PagedList<SearchTourDto> model = new PagedList<SearchTourDto>(iq, (pi <= 0 ? 1 : pi), pageSize, total);
            data.Bide = Server.UrlEncode(data.Bide);
            ViewBag.para = data;
            return View(model);
        }

        [HttpGet]
        public ActionResult SearchAdvanced(string b,
            string or, int min, int max, int d, string t, int pi)
        {
            SearchInfoDto data = new SearchInfoDto();
            data.Bide = Server.UrlDecode(b);
            List<string> hotelList = new List<string>();
            if (!string.IsNullOrEmpty(t))  //判断是否为空
            {
                t = Server.UrlDecode(t);
                var typeList = t.Split('|').ToList();
                hotelList.AddRange(typeList);
            }
            int total = 0;
            IQueryable<SearchTourDto> iq = null;
            PagedList<SearchTourDto> model = null;
            if (!string.IsNullOrEmpty(b))
            {
                iq = searchService.GetSearchTourModelAdvanced(data.Bide, or, min, max, d, hotelList, (pi <= 0 ? 1 : pi), pageSize, ref total);
                model = new PagedList<SearchTourDto>(iq, pi, pageSize, total);
            }
            data.Bide = b;
            ViewBag.para = data;
            ViewBag.sort = or;
            ViewBag.day = d;
            ViewBag.min = min;
            ViewBag.max = max;
            ViewBag.hotel = t;
            return View(model);
        }

        [HttpGet]
        public ActionResult SearchAll()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchAll(FormCollection f)
        {
            SearchInfoDto data = new SearchInfoDto();
            string sorter = "def";
            int min = -1;
            int max = -1;
            int day = 0;
            List<string> hotelList = new List<string>();

            #region sorter

            if (f["sorter"] != null)
            {
                sorter = f["sorter"].ToString();
            }
            #endregion

            #region price

            if (f["priceFilter1"] != null)
            {
                min = 0;
                max = 200;
            }
            if (f["priceFilter2"] != null)
            {
                min = 201;
                max = 400;
            }
            if (f["priceFilter3"] != null)
            {
                min = 401;
                max = 600;
            }
            if (f["priceFilter4"] != null)
            {
                min = 601;
                max = 0;
            }
            #endregion

            #region day

            if (f["daysFilter2"] != null)
            {
                day = 2;
            }
            if (f["daysFilter4"] != null)
            {
                day = 4;
            }
            if (f["daysFilter6"] != null)
            {
                day = 6;
            }
            if (f["daysFilter8"] != null)
            {
                day = -1;
            }
            #endregion

            #region hotelList
            if (f["hotelFilter1"] != null)
            {
                hotelList.Add("招待所");
            }
            if (f["hotelFilter2"] != null)
            {
                hotelList.Add("度假村");
            }
            if (f["hotelFilter3"] != null)
            {
                hotelList.Add("农家乐");
            }
            if (f["hotelFilter4"] != null)
            {
                hotelList.Add("三星级");
            }

            if (f["hotelFilter5"] != null)
            {
                hotelList.Add("四星级");
            }
            if (f["hotelFilter6"] != null)
            {
                hotelList.Add("五星级");
            }
            if (f["hotelFilter7"] != null)
            {
                hotelList.Add("经济型酒店");
            }
            if (f["hotelFilter8"] != null)
            {
                hotelList.Add("酒店式公寓");
            }

            #endregion

            #region bide

            if (f["txtBide"] != null)
            {
                data.Bide = f["txtBide"];
            }
            #endregion

            int total = 0;
            IQueryable<SearchTourDto> iq = null;
            PagedList<SearchTourDto> model = null;
            if (!string.IsNullOrEmpty(data.Bide))
            {
                iq = searchService.GetSearchTourModelAdvanced(data.Bide, sorter, min, max, day, hotelList, 1, pageSize, ref total);
                model = new PagedList<SearchTourDto>(iq, 1, pageSize, total);
            }
            data.Bide = Server.UrlEncode(data.Bide);
            string typeList = string.Empty;
            foreach (var item in hotelList)
            {
                typeList += item + "|";
            }
            if (typeList.Length > 1)
            {
                typeList = typeList.Remove(typeList.Length - 1, 1);
            }
            ViewBag.para = data;
            ViewBag.sort = sorter;
            ViewBag.day = day;
            ViewBag.min = min;
            ViewBag.max = max;
            ViewBag.hotel = Server.UrlEncode(typeList);
            return View(model);
        }
    }
}
