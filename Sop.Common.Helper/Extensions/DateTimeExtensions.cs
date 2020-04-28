using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeExtensions
    {
        public static MonthWeeks NumWeeks(this DateTime dt)
        {
            var monthWeeks = new MonthWeeks();
            monthWeeks.WeekList = new List<MonthWeekStartEnd>();

            //年
            var year = dt.Year;
            //月 
            var month = dt.Month;
            //当前月第一天
            var weekStart = new DateTime(year, month, 1);
            //该月的最后一天
            var monEnd = weekStart.AddMonths(1).AddDays(-1);
            var i = 1;
            //当前月第一天是星期几
            var dayOfWeek = Convert.ToInt32(weekStart.DayOfWeek.ToString("d"));
            //该月第一周结束日期
            var weekEnd = dayOfWeek == 6 ? weekStart : weekStart.AddDays(6 - dayOfWeek);

            monthWeeks.WeekList.Add(new MonthWeekStartEnd()
            {
                WeekStart = weekStart,
                WeekEnd = weekEnd.AddDays(1).AddSeconds(-1)
            });

            //当日期小于或等于该月的最后一天
            while (weekEnd.AddDays(1) <= monEnd)
            {
                i++;
                //该周的开始时间
                weekStart = weekEnd.AddDays(1);
                //该周结束时间
                weekEnd = weekEnd.AddDays(7) > monEnd ? monEnd : weekEnd.AddDays(7);


                monthWeeks.WeekList.Add(new MonthWeekStartEnd()
                {
                    WeekStart = weekStart,
                    WeekEnd = weekEnd.AddDays(1).AddSeconds(-1)
                });
            }

            monthWeeks.WeekCount = i;

            return monthWeeks;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetWeek(this DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            var firstDay = new DateTime(year, month, 1);
            var lastDay = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            //一.找到第一周的最后一天（先获取1月1日是星期几，从而得知第一周周末是几）
            int firstWeekend = firstDay.DayOfYear + (7 - Convert.ToInt32(firstDay.DayOfWeek));

            //二.获取今天是一年当中的第几天
            int currentDay = lastDay.DayOfYear;
            //三.（最后一天 减去 第一周周末那一天）/7 等于 距第一周有多少周 再加上第一周的1 就是这个月的周数
            //刚好考虑了惟一的特殊情况就是，今天刚好在第一周内，那么距第一周就是0 再加上第一周的1 最后还是1
            return Convert.ToInt32(Math.Ceiling((currentDay - firstWeekend) / 7.0)) + 1;
        }
        /// <summary>
        /// 得到一年中的某周的起始日和截止日
        /// </summary>
        /// <param name="nYear">年</param>
        /// <param name="nNumWeek">周数</param>
        /// <param name="dtWeekStart">周始</param>
        /// <param name="dtWeekeEnd">周终</param>
        public static void GetWeek(int nYear, int nNumWeek, out DateTime dtWeekStart, out DateTime dtWeekeEnd)
        {
            var dt = new DateTime(nYear, 1, 1);
            dt = dt + new TimeSpan((nNumWeek - 1) * 7, 0, 0, 0);
            dtWeekStart = dt.AddDays(-(int)dt.DayOfWeek + (int)DayOfWeek.Sunday);
            if (dtWeekStart < new DateTime(nYear, 1, 1))
                dtWeekStart = new DateTime(nYear, 1, 1);

            dtWeekeEnd = dt.AddDays((int)DayOfWeek.Saturday - (int)dt.DayOfWeek + 1);
            if (dtWeekeEnd > new DateTime(nYear, 1, 1).AddYears(1))
                dtWeekeEnd = new DateTime(nYear, 1, 1).AddYears(1);
        }

        /// <summary>
        /// 求某年有多少周 
        /// </summary>
        /// <param name="strYear"></param>
        /// <returns>返回 int</returns>
        public static int GetYearWeekCount(int strYear)
        {
            var fDt = DateTime.Parse(strYear + "-01-01");
            var k = Convert.ToInt32(fDt.DayOfWeek); //得到该年的第一天是周几 
            if (k == 1)
            {
                var countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                var countWeek = countDay / 7 + 1;
                return countWeek;
            }
            else
            {
                var countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                var countWeek = countDay / 7 + 2;
                return countWeek;
            }
        }

        /// <summary>
        /// 求当前日期是一年的中第几周
        /// </summary>
        /// <param name="curDay"></param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime curDay)
        {
            var firstdayofweek = Convert.ToInt32(Convert.ToDateTime(curDay.Year + "-01-01 ").DayOfWeek);

            var days = curDay.DayOfYear;
            var daysOutOneWeek = days - (7 - firstdayofweek);

            if (daysOutOneWeek <= 0)
            {
                return 1;
            }
            var weeks = daysOutOneWeek / 7;
            if (daysOutOneWeek % 7 != 0)
                weeks++;

            return weeks + 1;
        }
        /// <summary>
        /// 本月的第一天 例如 2019-04-01 00:00:00
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime MonthFirst(this DateTime date)
        {
            return DateTime.Parse(date.Year + "-" + date.Month + "-01");
        }

        /// <summary>
        /// 本月的最后一天 例如 2013-04-30 23:59:59
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime MonthLast(this DateTime date)
        {
            return MonthFirst(date).AddMonths(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// 当天的第一秒
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime DayFirst(this DateTime date)
        {
            return date.Date;
        }

        /// <summary>
        /// 当天的最后一秒
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime DayLast(this DateTime date)
        {
            return date.DayFirst().AddDays(1).AddMilliseconds(-1);
        }
         
    }
    /// <summary>
    /// 
    /// </summary>
    public class MonthWeeks
    {
        public int WeekCount { get; set; }

        public List<MonthWeekStartEnd> WeekList { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class MonthWeekStartEnd
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
    }
}
