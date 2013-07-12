using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILinksAndTopCountService
    {
        /// <summary>
        /// Gets the hotel info count.
        /// </summary>
        /// <returns></returns>
        int GetHotelInfoCount();

        /// <summary>
        /// Gets the img link list.
        /// </summary>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_LinksInfoDto> GetImgLinkList();

        /// <summary>
        /// Gets the sight count.
        /// </summary>
        /// <returns></returns>
        int GetSightCount();

        /// <summary>
        /// Gets the text link list.
        /// </summary>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_LinksInfoDto> GetTextLinkList();

        /// <summary>
        /// Gets the tour info count.
        /// </summary>
        /// <returns></returns>
        int GetTourInfoCount();

    }
}
