using System;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// 时间操作工具集
    /// Copyright (C) 2008-2010 深圳互动力科技有限公司
    /// All rights reserved
    /// </summary>
    public class DateHelper
    {
        public DateHelper()
        {
        }

        #region 返回本年有多少天 年份
        /// <summary>返回本年有多少天</summary>
        /// <param name="iYear">年份</param>
        /// <returns>本年的天数</returns>
        public static int GetDaysOfYear(int iYear)
        {
            int cnt = 0;
            if (IsRuYear(iYear))
            {
                //闰年多 1 天 即：2 月为 29 天
                cnt = 366;

            }
            else
            {
                //--非闰年少1天 即：2 月为 28 天
                cnt = 365;
            }
            return cnt;
        }
        #endregion

        #region 本年有多少天 日期
        /// <summary>本年有多少天</summary>
        /// <param name="dt">日期</param>
        /// <returns>本天在当年的天数</returns>
        public static int GetDaysOfYear(DateTime idt)
        {
            int n;

            //取得传入参数的年份部分，用来判断是否是闰年

            n = idt.Year;
            if (IsRuYear(n))
            {
                //闰年多 1 天 即：2 月为 29 天
                return 366;
            }
            else
            {
                //--非闰年少1天 即：2 月为 28 天
                return 365;
            }

        }
        #endregion

        #region 本月有多少天  年  月  -天数
        /// <summary>本月有多少天</summary>
        /// <param name="iYear">年</param>
        /// <param name="Month">月</param>
        /// <returns>天数</returns>
        public static int GetDaysOfMonth(int iYear, int Month)
        {
            int days = 0;
            switch (Month)
            {
                case 1:
                    days = 31;
                    break;
                case 2:
                    if (IsRuYear(iYear))
                    {
                        //闰年多 1 天 即：2 月为 29 天
                        days = 29;
                    }
                    else
                    {
                        //--非闰年少1天 即：2 月为 28 天
                        days = 28;
                    }

                    break;
                case 3:
                    days = 31;
                    break;
                case 4:
                    days = 30;
                    break;
                case 5:
                    days = 31;
                    break;
                case 6:
                    days = 30;
                    break;
                case 7:
                    days = 31;
                    break;
                case 8:
                    days = 31;
                    break;
                case 9:
                    days = 30;
                    break;
                case 10:
                    days = 31;
                    break;
                case 11:
                    days = 30;
                    break;
                case 12:
                    days = 31;
                    break;
            }

            return days;


        }
        #endregion

        #region 本月有多少天  日期  -天数
        /// <summary>本月有多少天</summary>
        /// <param name="dt">日期</param>
        /// <returns>天数</returns>
        public static int GetDaysOfMonth(DateTime dt)
        {
            //--------------------------------//
            //--从dt中取得当前的年，月信息  --//
            //--------------------------------//
            int year, month, days = 0;
            year = dt.Year;
            month = dt.Month;

            //--利用年月信息，得到当前月的天数信息。
            switch (month)
            {
                case 1:
                    days = 31;
                    break;
                case 2:
                    if (IsRuYear(year))
                    {
                        //闰年多 1 天 即：2 月为 29 天
                        days = 29;
                    }
                    else
                    {
                        //--非闰年少1天 即：2 月为 28 天
                        days = 28;
                    }

                    break;
                case 3:
                    days = 31;
                    break;
                case 4:
                    days = 30;
                    break;
                case 5:
                    days = 31;
                    break;
                case 6:
                    days = 30;
                    break;
                case 7:
                    days = 31;
                    break;
                case 8:
                    days = 31;
                    break;
                case 9:
                    days = 30;
                    break;
                case 10:
                    days = 31;
                    break;
                case 11:
                    days = 30;
                    break;
                case 12:
                    days = 31;
                    break;
            }

            return days;

        }
        #endregion

        #region 返回当前日期的星期名称
        /// <summary>返回当前日期的星期名称</summary>
        /// <param name="dt">日期</param>
        /// <returns>星期名称</returns>
        public static string GetWeekNameOfDay(DateTime idt)
        {
            string dt, week = "";

            dt = idt.DayOfWeek.ToString();
            switch (dt)
            {
                case "Mondy":
                    week = "星期一";
                    break;
                case "Tuesday":
                    week = "星期二";
                    break;
                case "Wednesday":
                    week = "星期三";
                    break;
                case "Thursday":
                    week = "星期四";
                    break;
                case "Friday":
                    week = "星期五";
                    break;
                case "Saturday":
                    week = "星期六";
                    break;
                case "Sunday":
                    week = "星期日";
                    break;

            }
            return week;
        }
        #endregion

        #region 返回当前日期的星期编号
        /// <summary>返回当前日期的星期编号</summary>
        /// <param name="dt">日期</param>
        /// <returns>星期数字编号</returns>
        public static string GetWeekNumberOfDay(DateTime idt)
        {
            string dt, week = "";

            dt = idt.DayOfWeek.ToString();
            switch (dt)
            {
                case "Mondy":
                    week = "1";
                    break;
                case "Tuesday":
                    week = "2";
                    break;
                case "Wednesday":
                    week = "3";
                    break;
                case "Thursday":
                    week = "4";
                    break;
                case "Friday":
                    week = "5";
                    break;
                case "Saturday":
                    week = "6";
                    break;
                case "Sunday":
                    week = "7";
                    break;

            }

            return week;


        }
        #endregion

        #region 返回两个日期之间相差的天数
        /// <summary>返回两个日期之间相差的天数</summary>
        /// <param name="dt">两个日期参数</param>
        /// <returns>天数</returns>
        public static int DiffDays(DateTime dtfrm, DateTime dtto)
        {
            int diffcnt = 0;
            //diffcnt = dtto- dtfrm ;

            return diffcnt;
        }
        #endregion

        #region 判断当前日期所属的年份是否是闰年，私有函数
        /// <summary>判断当前日期所属的年份是否是闰年，私有函数</summary>
        /// <param name="dt">日期</param>
        /// <returns>是闰年：True ，不是闰年：False</returns>
        private static bool IsRuYear(DateTime idt)
        {
            //形式参数为日期类型 
            //例如：2003-12-12
            int n;
            n = idt.Year;

            if ((n % 400 == 0) || (n % 4 == 0 && n % 100 != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断当前年份是否是闰年，私有函数
        /// <summary>判断当前年份是否是闰年，私有函数</summary>
        /// <param name="dt">年份</param>
        /// <returns>是闰年：True ，不是闰年：False</returns>
        private static bool IsRuYear(int iYear)
        {
            //形式参数为年份
            //例如：2003
            int n;
            n = iYear;

            if ((n % 400 == 0) || (n % 4 == 0 && n % 100 != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 将输入的字符串转化为日期。如果字符串的格式非法，则返回当前日期。
        /// <summary>
        /// 将输入的字符串转化为日期。如果字符串的格式非法，则返回当前日期。
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>日期对象</returns>
        public static DateTime ConvertStringToDate(string strInput)
        {
            DateTime oDateTime;

            try
            {
                oDateTime = DateTime.Parse(strInput);
            }
            catch (Exception)
            {
                oDateTime = DateTime.Today;
            }

            return oDateTime;
        }
        #endregion

        #region 将日期对象转化为格式字符串
        /// <summary>
        /// 将日期对象转化为格式字符串
        /// </summary>
        /// <param name="oDateTime">日期对象</param>
        /// <param name="strFormat">
        /// 格式：
        /// "SHORTDATE"===短日期
        /// "LONGDATE"==长日期
        /// 其它====自定义格式
        /// </param>
        /// <returns>日期字符串</returns>
        public static string ConvertDateToString(DateTime oDateTime, string strFormat)
        {
            string strDate = "";

            try
            {
                switch (strFormat.ToUpper())
                {
                    case "SHORTDATE":
                        strDate = oDateTime.ToShortDateString();
                        break;
                    case "LONGDATE":
                        strDate = oDateTime.ToLongDateString();
                        break;
                    default:
                        strDate = oDateTime.ToString(strFormat);
                        break;
                }
            }
            catch (Exception)
            {
                strDate = oDateTime.ToShortDateString();
            }

            return strDate;
        }
        #endregion

        #region 判断是否为合法日期，必须大于1800年1月1日
        /// <summary>
        /// 判断是否为合法日期，必须大于1800年1月1日
        /// </summary>
        /// <param name="strDate">输入日期字符串</param>
        /// <returns>True/False</returns>
        public static bool IsDateTime(string strDate)
        {
            try
            {
                DateTime oDate = DateTime.Parse(strDate);
                if (oDate.CompareTo(DateTime.Parse("1800-1-1")) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 获取指定某日的开始时间
        //获取指定某日的开始时间
        public static DateTime GetDayBegin(DateTime dt)
        {
            DateTime result = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            return result;
        }
        #endregion

        #region 获取指定某日的结束时间
        //获取指定某日的结束时间
        public static DateTime GetDayEnd(DateTime dt)
        {
            DateTime result = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            return result;
        }
        #endregion

        #region 获取指定某日当月开始时间
        //获取指定某日当月开始时间
        public static DateTime GetMonthBegin(DateTime dt)
        {
            DateTime result = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
            return result;
        }
        #endregion

        #region 获取某月的开始
        public static DateTime GetMonthBegin(int year, int month)
        {
            DateTime result = new DateTime(year, month, 1, 0, 0, 0);
            return result;
        }
        #endregion

        #region 获取某月的结束
        public static DateTime GetMonthEnd(int year, int month)
        {
            int end = System.DateTime.DaysInMonth(year, month);
            DateTime result = new DateTime(year, month, end, 0, 0, 0);
            return result;
        }
        #endregion

        #region 获取指定某日当月结束时间
        //获取指定某日当月结束时间
        public static DateTime GetMonthEnd(DateTime dt)
        {
            int end = System.DateTime.DaysInMonth(dt.Year, dt.Month);
            DateTime result = new DateTime(dt.Year, dt.Month, end, 0, 0, 0);
            return result;
        }
        #endregion

        #region 将时间转为以下格式：07年12月1日
        /// <summary>
        /// 将时间转为以下格式：07年12月1日
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetChineseDate(DateTime dt)
        {
            return dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";
        }
        #endregion

        #region 将时间转为以下格式：071201
        /// <summary>
        /// 将时间转为以下格式：071201
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetChineseDate1(DateTime dt)
        {
            string strFormatTime = dt.ToString("yyyy-MM-dd");
            return strFormatTime.Split('-')[0] + strFormatTime.Split('-')[1] + strFormatTime.Split('-')[2];
        }
        #endregion

        #region 把时间转换为"2008-1"这样的格式
        /// <summary>
        ///把时间转换为"2008-1"这样的格式
        /// </summary>
        public static string DateToYear(string sDate)
        {
            try
            {
                DateTime datetemp = Convert.ToDateTime(sDate);
                string strMoth = datetemp.Month.ToString();
                string strYear = datetemp.Year.ToString();
                sDate = strYear + "-" + strMoth;

            }
            //时间异常处理,如果时间出错则全部默认为当前系统时间
            catch
            {

                DateTime datetemp = DateTime.Now;
                string strMoth = datetemp.Month.ToString();
                string strYear = datetemp.Year.ToString();
                sDate = strYear + "-" + strMoth;
            }

            return sDate;
        }
        #endregion

        #region 获取两个时间差
        public static string GetDiff(DateTime dtAddTime)
        {
            string strDiff = "";
            System.TimeSpan Diff = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(dtAddTime.ToString());
            if (int.Parse(Diff.Days.ToString()) >= 1)
            {
                strDiff = strDiff + Diff.Days.ToString() + "天前";
            }
            else
            {
                if (int.Parse(Diff.Hours.ToString()) >= 1)
                    strDiff = strDiff + Diff.Hours.ToString() + "小时前";
                else
                {
                    if (int.Parse(Diff.Minutes.ToString()) >= 1)
                    {
                        strDiff = strDiff + Diff.Minutes.ToString() + "分钟前";
                    }
                    else
                    {
                        if (int.Parse(Diff.Seconds.ToString()) >= 5)
                        {
                            strDiff = strDiff + Diff.Seconds.ToString() + "秒前";
                        }
                        else
                        {
                            strDiff = "刚才";
                        }
                    }
                }
            }
            return strDiff;
        }
        #endregion

        #region   mysql 时间转 sql 时间

        /// <summary>
        /// 将php数字转换成时间
        /// 当dtk 为utc时，得到utc时间比当前时间少8个小时
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="dtk">The DTK.</param>
        /// <returns></returns>
        public static DateTime GetMysqlDateTime(long val, DateTimeKind dtk)
        {
            //GMT时间从1970年1月1日开始，先把它作为赋为初值
            long year = 1970, month = 1, day = 1;
            long hour = 0, min = 0, sec = 0;

            //临时变量
            long tempYear = 0, tempDay = 0;
            long tempHour = 0, tempMin = 0, tempSec = 0;

            //计算文件创建的年份
            tempYear = val / (365 * 24 * 60 * 60);
            year = year + tempYear;

            //计算文件除创建整年份以外还有多少天
            tempDay = (val % (365 * 24 * 60 * 60)) / (24 * 60 * 60);

            //把闰年的年份数计算出来
            int rInt = 0;
            for (int i = 1970; i < year; i++)
            {
                if ((i % 4) == 0)
                    rInt = rInt + 1;
            }

            //计算文件创建的时间(几时)
            tempHour = ((val % (365 * 24 * 60 * 60)) % (24 * 60 * 60)) / (60 * 60);
            hour = hour + tempHour;

            //计算文件创建的时间(几分)
            tempMin = (((val % (365 * 24 * 60 * 60)) % (24 * 60 * 60)) % (60 * 60)) / 60;
            min = min + tempMin;

            //计算文件创建的时间(几秒)
            tempSec = (((val % (365 * 24 * 60 * 60)) % (24 * 60 * 60)) % (60 * 60)) % 60;
            sec = sec + tempSec;

            DateTime tempTime = new DateTime((int)year, (int)month, (int)day, (int)hour, (int)min, (int)sec);
            DateTime res = tempTime.AddDays(tempDay - rInt);
            if (dtk == DateTimeKind.Utc)
            {
                res = res.AddHours(-8);
            }
            return res;
        }

        #endregion

        #region asp.net time to int mysql time

        /// <summary>
        /// Gets the now to mysql time.
        /// dt values DateTime.UtcNow DateTime.Now
        /// 我用到的mysql 是用的utc格式的，所以传utc
        /// GetMysqlDateTime 这个可以还原时间
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static long GetNowToMysqlTime(DateTime dt)
        {
            TimeSpan ts = dt - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// Detects the week.
        /// </summary>
        /// <returns></returns>
        public static long GetNowToMysqlTimeLong()
        {
            DateTime StartDate = new DateTime(1970, 01, 01);
            long a = (DateTime.Now.Ticks - StartDate.Ticks) / 10000000;
            return Convert.ToInt64(a); ;
        }

        /// <summary>
        /// Detects the week.
        /// </summary>
        /// <returns></returns>
        public static int GetNowToMysqlTime()
        {
            DateTime StartDate = new DateTime(1970, 01, 01);
            long a = (DateTime.Now.Ticks - StartDate.Ticks) / 10000000;
            return Convert.ToInt32(a); ;
        }
        #endregion
    }
}
