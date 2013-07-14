using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Miaow.Infrastructure.Crosscutting.Authorize.Dto
{
    public class MvcControllerActionDto : Miaow.Domain.Dto.Sys_MvcControllerActionDto
    {
        [DisplayName("控制器名称")]
        public string ControllerName { get; set; }
    }
}
