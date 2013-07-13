using System;
using System.Linq;
using System.Web.Mvc;
using iPow.Application.Union.Dto;

namespace iPow.Presentation.Union.Controllers
{
    [HandleError]
    public class SearchController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public const int pageSize = 10;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelSearchService hotelSearchService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelTypeService hotelTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        /// <param name="ipowHotelSearch">The ipow hotel search.</param>
        /// <param name="ipowHotelType">Type of the ipow hotel.</param>
        public SearchController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Service.Union.Service.IHotelSearchService ipowHotelSearch,
            iPow.Service.Union.Service.IHotelTypeService ipowHotelType)
            : base(work)
        {
            if (ipowHotelSearch == null)
            {
                throw new ArgumentNullException("hotelSearchService is null");
            }
            if (ipowHotelType == null)
            {
                throw new ArgumentNullException("hotelTypeService is null");
            }
            hotelSearchService = ipowHotelSearch;
            hotelTypeService = ipowHotelType;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// Indexes the specified f.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Index(FormCollection f)
        {
            string bide = string.Empty;
            string comeTime = string.Empty;
            string leaveTime = string.Empty;
            string key = string.Empty;
            //入住地
            if (f["txtBide"] != null)
            {
                bide = f["txtBide"].ToString();
            }

            //入住时间
            if (f["txtComeTime"] != null)
            {
                comeTime = f["txtComeTime"].ToString();
            }

            //离店时间
            if (f["txtLeaveTime"] != null)
            {
                leaveTime = f["txtLeaveTime"].ToString();
            }

            //关键词
            if (f["txtKeyword"] != null)
            {
                key = f["txtKeyword"].ToString();
            }

            SearchInfoDto sm = new SearchInfoDto();
            sm.Bide = bide;
            sm.Key = key + "";
            try
            {
                sm.ComeTime = DateTime.Parse(comeTime);
                sm.LeaveTime = DateTime.Parse(leaveTime);
            }
            catch
            {
            }

            int total = 0;
            if (!string.IsNullOrEmpty(bide))
            {
                var keyCopy = iPow.Infrastructure.Crosscutting.Function.StringHelper.StrToUrlGbk(key);
                var data = hotelSearchService.GetHotelSearchModel(comeTime.Replace("-", "_"), bide, keyCopy);
                total = data.total;
                sm.HotelBaseInfo = new Webdiyer.WebControls.Mvc.PagedList<SearchHotelDetailDto>(data.hotel_list, 1, pageSize, total);
            }
            return View(sm);
        }

        /// <summary>
        /// Searches the sort price.
        /// 按价格搜索和排序，还有分页
        /// </summary>
        /// <param name="bide">The bide.</param>
        /// <param name="key">The key.</param>
        /// <param name="cometime">The cometime.</param>
        /// <param name="leavetime">The leavetime.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="starts">The starts.</param>
        /// <param name="mintomax">The mintomax.</param>
        /// <param name="pi">The pi.</param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult SearchAll(string bide, string key, string cometime,
            string leavetime, int? min, int? max, string starts, string mintomax, int pi)
        {
            SearchInfoDto sm = new SearchInfoDto();
            sm.Bide = bide;
            sm.Key = key;
            DateTime come = System.DateTime.Now;
            DateTime leave = System.DateTime.Now.AddDays(2);
            try
            {
                come = DateTime.Parse(cometime);
                leave = DateTime.Parse(leavetime);
            }
            catch
            {
            }
            sm.ComeTime = come;
            sm.LeaveTime = leave;
            int total = 0;
            pi = pi <= 0 ? 1 : pi;
            if (string.IsNullOrEmpty(starts))
            {
                starts = "all";
            }
            if (string.IsNullOrEmpty(mintomax))
            {
                mintomax = "def";
            }
            ViewBag.min = min;
            ViewBag.max = max;
            ViewBag.mintomax = mintomax;
            ViewBag.starts = starts;
            if (!string.IsNullOrEmpty(bide))
            {
                var keyCopy = iPow.Infrastructure.Crosscutting.Function.StringHelper.StrToUrlGbk(key);
                var strMin = "0";
                if (min == null)
                {
                    strMin = "0";
                }
                else
                {
                    strMin = min.ToString();
                }
                var strMax = "0";
                if (max == null)
                {
                    strMax = "0";
                }
                else
                {
                    strMax = max.ToString();
                }
                var strType = "";
                strType = GetHotelType(starts);
                var order = "0";
                order = GetOrderType(mintomax);
                if (pi < 0)
                {
                    pi = 1;
                }
                var data = hotelSearchService.GetHotelSearchModel(come.ToString("yyyy-MM-dd").Replace("-", "_"),
                    bide, keyCopy, pi.ToString(), strMin, strMax, strType, order);
                total = data.total;
                sm.HotelBaseInfo = new Webdiyer.WebControls.Mvc.PagedList<SearchHotelDetailDto>(data.hotel_list, pi, pageSize, total);
            }
            return View(sm);
        }

        /// <summary>
        /// Gets the type of the order.
        /// [0=网站默认 1=按浏览次数 2=按最低价格 3=按好评数 4=按照距离]
        /// def views mintomax comm juli
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        [System.Web.Mvc.NonAction]
        protected string GetOrderType(string str)
        {
            var strCopy = "0";
            if (!string.IsNullOrEmpty(str))
            {
                if (str.ToLower().CompareTo("def") == 0)
                {
                    strCopy = "0";
                }
                else if (str.ToLower().CompareTo("views") == 0)
                {
                    strCopy = "1";
                }
                else if (str.ToLower().CompareTo("mintomax") == 0)
                {
                    strCopy = "2";
                }
                else if (str.ToLower().CompareTo("comm") == 0)
                {
                    strCopy = "3";
                }
                else if (str.ToLower().CompareTo("juli") == 0)
                {
                    strCopy = "4";
                }
                else
                {
                    strCopy = "0";
                }
            }
            return strCopy;
        }

        /// <summary>
        /// Gets the type of the hotel.
        /// "经济型酒店", "连锁酒店", "三星级酒店", "四星级酒店", "五星级酒店", "酒店式公寓"
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        [NonAction]
        protected string GetHotelType(string str)
        {
            var strCopy = "0";
            var id = hotelTypeService.GetHotelTypeId(str);
            if (id > 0)
            {
                strCopy = id.ToString();
            }
            return strCopy;
        }
    }
}
