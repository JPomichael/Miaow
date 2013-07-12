using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISinaInfoService
    {
        /// <summary>
        /// Gets the sina info.
        /// </summary>
        /// <returns></returns>
        LocationInfoDto GetSinaInfo();
    }
}
