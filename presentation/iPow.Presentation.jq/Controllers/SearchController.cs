using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using Webdiyer.WebControls.Mvc;

namespace iPow.Presentation.jq.Controllers
{
    [HandleError]
    public class SearchController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        int pageSize = 10;

        iPow.Application.jq.Service.ISearchService searchService;

        iPow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        public SearchController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Application.jq.Service.ISearchService ipowSearch,
            iPow.Domain.Repository.ISightInfoRepository sightInfo)
            : base(work)
        {
            if (ipowSearch == null)
            {
                throw new ArgumentNullException("searchService is null");
            }
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightInfoRepository is null");
            }
            searchService = ipowSearch;
            sightInfoRepository = sightInfo;
        }

        [HttpGet]
        public ViewResult Index()
        {
            string sear = "深圳";
            ViewBag.key = sear;
            var data = searchService.GetSearchModel(sear, 1, pageSize);
            return View(data);
        }

        [HttpPost]
        public ViewResult Index(FormCollection f)
        {
            string sear = "深圳";
            if (f["txtKeyword"] != null)
            {
                sear = HttpUtility.UrlDecode(f["txtKeyword"]);
                ViewBag.key = sear;
                var data = searchService.GetSearchModel(sear, 1, pageSize);
                return View(data);
            }
            return View("Home");
        }

        public ViewResult IndexPage(string search, int? id)
        {
            string sear = search;
            if (search != null)
            {
                sear = HttpUtility.UrlDecode(sear);
                ViewBag.key = sear;
                var data = searchService.GetSearchModel(sear, id ?? 1, pageSize);
                return View(data);
            }
            return View("Home");
        }

        public JsonResult GetSearchTip()
        {
            List<string> res = new List<string>();
            string sear = string.Empty;
            if (Request["term"] != null)
            {
                sear = Request["term"].ToString();
                sear = sear.Trim();
            }
            var title = sightInfoRepository.GetList(d => d.Title.Contains(sear)).Select(d => d.Title).Distinct().Take(10).ToList();
            if (title.Count() > 0)
            {
                res.AddRange(title);
            }

            #region
            //var tag = db.Sys_SightInfo.Where(d => d.Tag.Contains(sear)).Select(d => d.Tag).Distinct().Take(5).ToList();
            //if (tag.Count() > 0)
            //{
            //    res.AddRange(tag);
            //}
            //var prov = db.Sys_SightInfo.Where(d => d.Province.Contains(sear)).Select(d => d.Province).Distinct().Take(5).ToList();
            //if (prov.Count() > 0)
            //{
            //    res.AddRange(prov);
            //}

            //var city = db.Sys_SightInfo.Where(d => d.City.Contains(sear)).Select(d => d.City).Distinct().Take(5).ToList();
            //if (city.Count() > 0)
            //{
            //    res.AddRange(city);
            //}
            //var address = db.Sys_SightInfo.Where(d => d.Address.Contains(sear)).Select(d => d.Address).Distinct().Take(5).ToList();
            //if (address.Count() > 0)
            //{
            //    res.AddRange(address);
            //}
            #endregion

            var tel = sightInfoRepository.GetList(d => d.Telephone.Contains(sear)).Select(d => d.Telephone).Distinct().Take(10).ToList();
            if (tel.Count() > 0)
            {
                res.AddRange(tel);
            }

            var ema = sightInfoRepository.GetList(d => d.Email.Contains(sear)).Select(d => d.Email).Distinct().Take(10).ToList();
            if (ema.Count() > 0)
            {
                res.AddRange(ema);
            }
            return Json(res.Take(20), JsonRequestBehavior.AllowGet);
        }
    }
}
