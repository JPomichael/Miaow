using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iPow.Presentation.Union.Controllers
{
    [HandleError]
    public class EbookController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelEbookService hotelEbookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EbookController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        /// <param name="ipowHotelEbook">The ipow hotel ebook.</param>
        public EbookController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Service.Union.Service.IHotelEbookService ipowHotelEbook)
            : base(work)
        {
            if (ipowHotelEbook == null)
            {
                throw new ArgumentNullException("hotelEbookService is null");
            }
            hotelEbookService = ipowHotelEbook;
        }

        /// <summary>
        /// Indexes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="rid">The rid.</param>
        /// <param name="rpi">The rpi.</param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Index(long id, long rid, long rpi)
        {
            ViewBag.id = id;
            ViewBag.rid = rid;
            ViewBag.rpi = rpi;
            var intime = DateTime.Now;
            var outtime = intime.AddDays(1);
            ViewBag.intime = intime.ToString("yyyy-MM-dd");
            ViewBag.outtime = outtime.ToString("yyyy-MM-dd");
            if (Request["time"] != null)
            {
                try
                {
                    var time = System.DateTime.Now;
                    DateTime.TryParse(Request["time"].ToString(), out time);
                    if (intime.ToString("yyyy-MM-dd").CompareTo(time.ToString("yyyy-MM-dd")) != 0)
                    {
                        ViewBag.intime = time.ToString("yyyy-MM-dd");
                        ViewBag.outtime = time.AddDays(1).ToString("yyyy-MM-dd");
                    }
                }
                catch (Exception ex)
                { }
            }
            return View();
        }

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Query()
        {
            return View();
        }

        /// <summary>
        /// Queries the specified f.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Query(FormCollection f)
        {
            ViewBag.query = true;
            List<iPow.Application.Union.Dto.HotelEbookDto> data = null;
            if (f != null)
            {
                if (f["phone"] != null)
                {
                    var phone = f["phone"].ToString();
                    ViewBag.phone = phone;
                    data = hotelEbookService.GetHotelOderListByPhone(phone);
                }
            }
            return View(data);
        }
    }
}
