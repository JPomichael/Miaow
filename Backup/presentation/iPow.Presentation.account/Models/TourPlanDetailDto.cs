using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

using FluentValidation.Attributes;
using FluentValidation.Mvc;

namespace iPow.Presentation.account.Models
{
    public class UiTourPlanDetailDto
    {
        /// <summary>
        /// Gets or sets the tour plan.
        /// </summary>
        /// <value>The tour plan.</value>
        public iPow.Domain.Dto.Sys_TourPlanDto Parent { get; set; }

        /// <summary>
        /// Gets or sets the tour plan detail list.
        /// </summary>
        /// <value>The tour plan detail list.</value>
        public List<TourPlanDetailDto> DetailList { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Validator(typeof(Validate.TourPlanDetailDtoValidate))]
    public class TourPlanDetailDto : iPow.Domain.Dto.Sys_TourPlanDetailDto
    {
        /// <summary>
        /// Gets or sets the name of the target.
        /// </summary>
        /// <value>The name of the target.</value>
        [DisplayName("目的地名")]
        public string TargetName { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [DisplayName("目的地网址")]
        public string TargetUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the detail type.
        /// </summary>
        /// <value>The name of the detail type.</value>
        [DisplayName("玩点类型")]
        public string DetailTypeName { get; set; }
    }
}