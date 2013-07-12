using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelRoomService
    {
        /// <summary>
        /// Gets the hotel room by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        iPow.Application.Union.Dto.HotelRoomDto GetHotelRoomById(string id);

        /// <summary>
        /// Gets the hotel room fang tai.
        /// </summary>
        /// <param name="inTime">The in time.</param>
        /// <param name="leaveTime">The leave time.</param>
        /// <param name="days">The days.</param>
        /// <param name="fts">The FTS.</param>
        /// <returns></returns>
        int GetHotelRoomFangTai(DateTime inTime, DateTime leaveTime, string days, string fts);

        /// <summary>
        /// Gets the hotel room price.
        /// </summary>
        /// <param name="inTime">The in time.</param>
        /// <param name="days">The days.</param>
        /// <param name="prices">The prices.</param>
        /// <returns></returns>
        double GetHotelRoomPrice(DateTime inTime, string days, string prices);

        /// <summary>
        /// Gets the room time has room.
        /// </summary>
        /// <param name="fts">The FTS.</param>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        DateTime GetRoomTimeHasRoom(string fts, string days);
    }
}
