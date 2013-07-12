using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentValidation;
using FluentValidation.Mvc;

namespace iPow.Presentation.account.Validate
{
    public class TourPlanDetailDtoValidate :
        AbstractValidator<iPow.Presentation.account.Models.TourPlanDetailDto>
    {
        public TourPlanDetailDtoValidate()
        {
            RuleFor(e => e.DetailTypeName).NotNull().WithMessage("玩点类型不能为空");
            RuleFor(e => e.TargetName).NotEmpty().WithMessage("目的地名不能为空");
            RuleFor(e => e.CurrentPrice).NotNull().WithMessage("此天费用不能为空");
            RuleFor(e => e.DayID).NotNull().WithMessage("旅行的第X天不能为空");
        }
    }
}