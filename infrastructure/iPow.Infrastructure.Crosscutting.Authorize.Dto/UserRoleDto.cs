using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace iPow.Infrastructure.Crosscutting.Authorize.Dto
{
    public class UserRoleDto : iPow.Domain.Dto.Sys_UserRolesDto
    {
        [DisplayName("用户名")]
        public string UserName { get; set; }
        
        [DisplayName("角色名")]
        public string RoleName { get; set; }
    }
}