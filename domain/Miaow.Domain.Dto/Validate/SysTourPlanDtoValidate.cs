using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentValidation;
using FluentValidation.Mvc;

namespace iPow.Domain.Dto.Validate
{
    public class SysTourPlanDtoValidate : AbstractValidator<iPow.Domain.Dto.Sys_TourPlanDto>
    {
        public SysTourPlanDtoValidate()
        {
            RuleFor(e => e.PlanTitle).NotEmpty().WithMessage("线路名称不能为空");
            RuleFor(e => e.PlanClass).NotEmpty().WithMessage("线路分类不能为空");
            RuleFor(e => e.Days).NotEmpty().WithMessage("出行天数不能为空");
            RuleFor(e => e.Destination).NotEmpty().WithMessage("目的地不能为空");

            //RuleFor(e => e.Destination).NotEmpty().WithMessage("描述不能为空");
            //RuleFor(e => e.Remark).NotEmpty().WithMessage("线路备注不能为空");
            //RuleFor(e => e.UserName).NotEmpty().WithMessage("用户名不能为空");
        }
    }
}