
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Comm.Service
{
    public class UserGuidService
    {
        /// <summary>
        /// Builders the user id.
        /// </summary>
        public static string BuilderUserGuid()
        {
            return Miaow.Infrastructure.Crosscutting.Comm.Service.SsoService.BuilderTokenId();
        }
    }
}
