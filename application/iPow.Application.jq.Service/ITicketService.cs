using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// Gets the detail sight base info by id.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        DetailSightBaseDto GetDetailSightBaseInfoById(int sid);
    }
}
