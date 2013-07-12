using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Data.DataSys;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UtilityService
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ipowsysEntities"].ToString();

        /// <summary>
        /// 
        /// </summary>
        public static readonly iPow.Infrastructure.Data.DataSys.ipowsysEntities db = new ipowsysEntities(conn);

        #region jd used and union used and dj used

        /// <summary>
        /// Gets the sight default pic.
        /// jd and  dj  and union used
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static List<string> GetSightDefaultPic(int id)
        {
            List<string> res = new List<string>();
            var r = new Random();
            var temp = db.Sys_PicInfo.Where(e => e.ParkID == id).Where(e => e.IsDelete == 0).Count();
            if (temp > 0)
            {
                var toSkip = r.Next(0, temp);
                Sys_PicInfo tempPic = db.Sys_PicInfo.Where(e => e.ParkID == id)
                    .OrderBy(e => e.ViewCount)
                    .Skip(toSkip)
                    .Take(1)
                    .FirstOrDefault();
                if (tempPic != null)
                {
                    res.Add(tempPic.PicPath);
                    res.Add(tempPic.FileName);
                    res.Add(tempPic.PicName);
                }
            }
            return res;
        }

        /// <summary>
        /// Gets the sight pic count.
        /// jd used
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static int GetSightPicCount(int id)
        {
            int count = (from e in db.Sys_PicInfo
                         where e.ParkID == id && e.IsDelete == 0
                         group e by e.ParkID into g
                         select g.Count()).FirstOrDefault();
            return (int)count;
        }

        /// <summary>
        /// Gets the sight cir hotel count.
        /// jd used
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static int GetSightCirHotelCount(int id)
        {
            string res = db.Sys_SightInfo.Where(e => e.ParkID == id)
                .Select(e => e.CirHotelID).FirstOrDefault();
            string[] array = res.Split(',');
            int count = 0;
            foreach (var item in array)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    count += 1;
                }
            }
            return count;
        }

        #endregion
    }
}
