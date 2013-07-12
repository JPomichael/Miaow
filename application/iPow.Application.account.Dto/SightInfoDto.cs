using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;
using System.ComponentModel;

namespace iPow.Application.account.Dto
{
    public class TourPlanDto
    {
        public Domain.Dto.Sys_TourPlanDto TourPlan { get; set; }

        public PagedList<iPow.Domain.Dto.Sys_SightInfoDto> SightInfo { get; set; }

        public iPow.Domain.Dto.Sys_CityInfoDto CurrentCityInfo { get; set; }

        //
        public IEnumerable<iPow.Domain.Dto.Sys_SightInfoDto> sightInfoDto { get; set; }

        public PagedList<Domain.Dto.Sys_TourPlanDto> TourPlanList { get; set; }

        public IEnumerable<TourPlanDetailDto> tourPlanDetailDto { get; set; }

    }

    public class SightInfoDto
    {
        public int ParkID { get; set; }

        public string Title { get; set; }

        public string ClassID { get; set; }

        public string Remark { get; set; }

        public string VoIndex { get; set; }

        public string AdIndex { get; set; }

        public string PicPath { get; set; }

        public string CommCount { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string CirHotelID { get; set; }

        public string CirParkID { get; set; }

        public string Ticket { get; set; }
    }
}
