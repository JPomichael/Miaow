using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Domain.Dto;

namespace iPow.Application.account.Dto
{
    public class TourPlanDetailDto
    {
        //线路详细ID
        public int PlanDetailID { get; set; }

        //景区、酒店ID
        public int? SightIDOrHotelID { get; set; }

        //目的地费用
        public int CurrentPrice { get; set; }

        //玩点提示
        public string Remark { get; set; }

        //访问量
        public int VisitCount { get; set; }

        //旅行的第X天
        public int DayID { get; set; }

        //添加时间
        public DateTime AddTime { get; set; }

        //类型（景区,酒店,其他）
        public string DetailType { get; set; }

        //所属线路Id
        public int PlanID { get; set; }

    }
}
