using System;
using System.Linq;
using System.Web.Mvc;

namespace iPow.jd.Controllers
{
    public class SearchController : Controller
    {
        public const int pageSize = 10;

        //
        // GET: /Search/

        /// <summary>
        /// Indexes this instance.
        /// 直接输入地址是的action
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Indexes the specified f.
        /// 搜索的action
        /// </summary>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection f)
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
            Models.SearchModel sm = new Models.SearchModel();
            sm.Bide = bide;
            sm.Key = key;
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
                IQueryable<Models.SearchHotelModel> hd = Bll.Search.GetSearchModelBySearch(bide, System.DateTime.Now, System.DateTime.Now, key, 1, pageSize, ref  total);
                sm.HotelBaseInfo = new Webdiyer.WebControls.Mvc.PagedList<Models.SearchHotelModel>(hd, 1, pageSize, total);
            }
            return View(sm);
        }

        /// <summary>
        /// Searches the sort price.
        /// 按价格搜索和排序，还有分页
        /// </summary>
        /// <param name="bide">The bide.</param>
        /// <param name="key">The key.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="mintomax">The mintomax.</param>
        /// <param name="pi">The pi.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchAll(string bide, string key, string cometime,
            string leavetime, int? min, int? max, string starts, string mintomax, int pi)
        {
            Models.SearchModel sm = new Models.SearchModel();
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
                mintomax = "mintomax";
            }
            ViewBag.min = min;
            ViewBag.max = max;
            ViewBag.mintomax = mintomax;
            ViewBag.starts = starts;
            if (!string.IsNullOrEmpty(bide))
            {
                IQueryable<Models.SearchHotelModel> hd =
                   Bll.Search.GetSearchModelByAllConditions(bide, key, min, max,
                    starts, mintomax, pi, pageSize, ref  total);

                sm.HotelBaseInfo = new Webdiyer.WebControls.Mvc.PagedList<Models.SearchHotelModel>(hd, pi, pageSize, total);
            }
            return View(sm);
        }
    }
}
