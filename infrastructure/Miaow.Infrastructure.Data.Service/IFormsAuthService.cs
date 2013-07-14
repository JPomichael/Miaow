using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFormsAuthService
    {
        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="createPersistentCookie">if set to <c>true</c> [create persistent cookie].</param>
        void Login(Miaow.Domain.Dto.Sys_AdminUserDto user, bool createPersistentCookie);

        /// <summary>
        /// Signs the out.
        /// </summary>
        void LogOut();
    }
}
