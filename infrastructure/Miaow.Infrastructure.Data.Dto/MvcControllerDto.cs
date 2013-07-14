using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Miaow.Infrastructure.Crosscutting.Authorize.Dto
{
    public class MvcControllerDto : Miaow.Domain.Dto.Sys_MvcControllerDto
    {
        [DisplayName("分类名")]
        public string ClassName { get; set; }

    }
}
