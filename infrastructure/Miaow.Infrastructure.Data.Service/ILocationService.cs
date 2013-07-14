using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miaow.Infrastructure.Crosscutting.Comm.Dto;

namespace Miaow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Gets the location info model.
        /// </summary>
        /// <returns></returns>
        LocationInfoDto GetLocationInfo();

        /// <summary>
        /// Gets the location info model.
        /// </summary>
        /// <returns></returns>
        LocationInfoDto GetLocationInfo(string ip);
    }
}
