using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
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
