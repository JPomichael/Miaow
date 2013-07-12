using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace iPow.Infrastructure.Crosscutting.Authorize.Dto
{
    public class RolePermissionDto : iPow.Domain.Dto.Sys_RolesDto
    {
        public List<MvcActionDto> PermissionList { get; set; }
    }

    public class MvcActionDto
    {
        [DisplayName("Action权限Id")]
        public int ActionId { get; set; }

        [DisplayName("Action权限名")]
        public string ActionName { get; set; }

        [DisplayName("Action权限描述")]
        public string ActionRemark { get; set; }



        [DisplayName("权限所属控制器Id")]
        public int ControllerId { get; set; }

        [DisplayName("控制器名")]
        public string ControllerName { get; set; }

        [DisplayName("控制器描述")]
        public string ControllerRemark { get; set; }



        [DisplayName("控制器分类Id")]
        public int ControllerClassId { get; set; }

        [DisplayName("控制器分类名")]
        public string ControllerClassName { get; set; }
    }
}
