using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;

namespace Miaow.Presentation.dj.Controllers
{
    [HandleError]
    public class CityController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        //单页显示4个
        const int pageSize = 4;

        Miaow.Application.dj.Service.IListService listService;

        Miaow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService;

        public CityController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
                     Miaow.Application.dj.Service.IListService MiaowListService,
            Miaow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfo)
            : base(work)
        {
            if (MiaowListService == null)
            {
                throw new ArgumentNullException("listService is null");
            }
            if (cityInfo == null)
            {
                throw new ArgumentNullException("cityInfoService is null");
            }
            listService = MiaowListService;
            cityInfoService = cityInfo;
        }

        public ViewResult Index()
        {
            return View();
        }

        //从SelectCityView中得到CityPinYin     2012/3/29
        public ViewResult Tour(string id, int? pi)
        {
            ViewBag.pinyin = id;
            //定义了一个可变化的intPi =1
            var intPi = 1;
            //如果没有的话即表示在当前页
            if (pi == null)
            {
                pi = 1;
            }
            //将pi赋值给intPi
            intPi = (int)pi;
            if (id == "")
            {
                throw new ArgumentNullException("id is null");
            }
            var cityInfo = cityInfoService.GetCityByPinYin(id);
            if (cityInfo.city == "")
            {
                throw new ArgumentNullException("cityInfo is null");
            }
            else
            {
                id = cityInfo.city;
                IQueryable<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto> data = null;
                int total = 0;    //总条数
                data = listService.GetTourListByCity(id, intPi, pageSize, ref total);
                PagedList<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto> model = new PagedList<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto>(data, intPi, pageSize, total);
                return View(model);
            }
        }
    }
}
