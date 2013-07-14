using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Miaow.Infrastructure.Crosscutting.Comm.Dto;

namespace Miaow.Application.jq.Service
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
