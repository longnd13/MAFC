using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Prj.Utilities
{
    public enum Quarter
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public enum Day
    {
        [Description("Chủ nhật")]
        Sunday = 1,
        [Description("Thứ 2")]
        Monday = 2,
        [Description("Thứ 3")]
        Tuesday = 3,
        [Description("Thứ 4")]
        Wednesday = 4,
        [Description("Thứ 5")]
        Thursday = 5,
        [Description("Thứ 6")]
        Friday = 6,
        [Description("Thứ 7")]
        Saturday = 7
    }

    public class DateHandler
    {
        #region Quarters

        public static DateTime GetStartOfQuarter(int year, Quarter qtr)
        {
            switch (qtr)
            {
                case Quarter.First:
                    return new DateTime(year, 1, 1, 0, 0, 0, 0);
                case Quarter.Second:
                    return new DateTime(year, 4, 1, 0, 0, 0, 0);
                case Quarter.Third:
                    return new DateTime(year, 7, 1, 0, 0, 0, 0);
                default:
                    return new DateTime(year, 10, 1, 0, 0, 0, 0);
            }
        }

        public static DateTime GetEndOfQuarter(int year, Quarter qtr)
        {
            switch (qtr)
            {
                case Quarter.First:
                    return new DateTime(year, 3, DateTime.DaysInMonth(year, 3), 23, 59, 59, 999);
                case Quarter.Second:
                    return new DateTime(year, 6, DateTime.DaysInMonth(year, 6), 23, 59, 59, 999);
                case Quarter.Third:
                    return new DateTime(year, 9, DateTime.DaysInMonth(year, 9), 23, 59, 59, 999);
                default:
                    return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
            }
        }

        public static Quarter GetQuarter(Month month)
        {
            if (month <= Month.March)
                // 1st Quarter = January 1 to March 31
                return Quarter.First;
            else if ((month >= Month.April) && (month <= Month.June))
                // 2nd Quarter = April 1 to June 30
                return Quarter.Second;
            else if ((month >= Month.July) && (month <= Month.September))
                // 3rd Quarter = July 1 to September 30
                return Quarter.Third;
            else // 4th Quarter = October 1 to December 31
                return Quarter.Fourth;
        }

        public static DateTime GetEndOfLastQuarter()
        {
            return (Month)UtcNow().Month <= Month.March
                ? GetEndOfQuarter(UtcNow().Year - 1, Quarter.Fourth)
                : GetEndOfQuarter(UtcNow().Year, GetQuarter((Month)UtcNow().Month));
        }

        public static DateTime GetStartOfLastQuarter()
        {
            return (Month)UtcNow().Month <= Month.March
                ? GetStartOfQuarter(UtcNow().Year - 1, Quarter.Fourth)
                : GetStartOfQuarter(UtcNow().Year, GetQuarter((Month)UtcNow().Month));
        }

        public static DateTime GetStartOfCurrentQuarter()
        {
            return GetStartOfQuarter(UtcNow().Year, GetQuarter((Month)UtcNow().Month));
        }

        public static DateTime GetEndOfCurrentQuarter()
        {
            return GetEndOfQuarter(UtcNow().Year, GetQuarter((Month)UtcNow().Month));
        }
        #endregion

        #region Weeks
        public static DateTime GetStartOfLastWeek()
        {
            var daysToSubtract = (int)UtcNow().DayOfWeek + 7;
            var dt = UtcNow().Subtract(TimeSpan.FromDays(daysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfLastWeek()
        {
            var dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentWeek()
        {
            var daysToSubtract = (int)UtcNow().DayOfWeek;
            var dt = UtcNow().Subtract(System.TimeSpan.FromDays(daysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfCurrentWeek()
        {
            var dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }
        #endregion

        #region Months

        public static DateTime GetStartOfMonth(Month month, int year)
        {
            return new DateTime(year, (int)month, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfMonth(Month month, int year)
        {
            return new DateTime(year, (int)month, DateTime.DaysInMonth(year, (int)month), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastMonth()
        {
            return UtcNow().Month == 1
                ? GetStartOfMonth(Month.December, UtcNow().Year - 1)
                : GetStartOfMonth((Month)UtcNow().Month - 1, UtcNow().Year);
        }

        public static DateTime GetEndOfLastMonth()
        {
            return UtcNow().Month == 1
                ? GetEndOfMonth((Month)12, UtcNow().Year - 1)
                : GetEndOfMonth((Month)UtcNow().Month - 1, UtcNow().Year);
        }

        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth((Month)UtcNow().Month, UtcNow().Year);
        }

        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth((Month)UtcNow().Month, UtcNow().Year);
        }
        #endregion

        #region Years
        public static DateTime GetStartOfYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfYear(int year)
        {
            return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(UtcNow().Year - 1);
        }

        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(UtcNow().Year - 1);
        }

        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(UtcNow().Year);
        }

        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(UtcNow().Year);
        }
        #endregion

        #region Days

        public static DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }

        public static DateTime Now()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "vi-VN":
                    return UtcNow().AddHours(7);
                default:
                    return UtcNow();
            }
        }
        
        public static DateTime GetDate(DateTime date)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "vi-VN":
                    return date.AddHours(7);
                default:
                    return date;
            }
        }

        public static DateTime SetDate(DateTime date)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "vi-VN":
                    return date.AddHours(-7);
                default:
                    return date;
            }
        }

        public static string ConvertDateToJson(DateTime date)
        {
            var jsondate = JsonConvert.SerializeObject(date, new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            });

            jsondate = jsondate.Replace(@"\/", "/").Replace("\\", "").Replace("\"", "");
            return jsondate;
        }

        public static DateTime ConvertJsonToDate(string json, bool shortFormat = true)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            string dateFormat;
            switch (currentCulture)
            {
                case "vi-VN":
                    dateFormat = shortFormat ? ("dd/MM/yyyy") : ("dd/MM/yyyy HH:mm:ss tt"); break;
                    
                default:
                    dateFormat = shortFormat ? ("dd/MM/yyyy") : ("dd/MM/yyyy HH:mm:ss tt"); break;
            }

            json = String.Format("\"{0}\"", json);
            json = json.Replace("/", @"\/");
            return JsonConvert.DeserializeObject<DateTime>(json, new IsoDateTimeConverter() { DateTimeFormat = dateFormat, Culture = CultureInfo.CurrentCulture });
        }

        public static string DisplayDate(DateTime date, bool shortFormat = true)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "vi-VN":
                    return shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm");
                default:
                    return shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm");
            }
        }

        public static string DisplayDateWithSecond(DateTime date, bool shortFormat = true)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "vi-VN":
                    return shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm:ss");
                default:
                    return shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        public static string FormatDate(DateTime date, string strFormat)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "vi-VN":
                    return date.ToString(strFormat);
                default:
                    return date.ToString("MM/dd/yyyy");
            }
        }

        public static DateTime Date()
        {
            return new DateTime(UtcNow().Year, UtcNow().Month, UtcNow().Day);
        }

        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static string DisplayDateWithDOW(DateTime date, bool shortFormat = true)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            switch (currentCulture)
            {
                case "vi-VN":
                    //return GetDayOfWeekVN(date.DayOfWeek) + ", " + (shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm"));
                    return (shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm"));
                default:
                    //return GetDayOfWeekVN(date.DayOfWeek) + ", " + (shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm"));
                    return (shortFormat ? date.ToString("dd/MM/yyyy") : date.ToString("dd/MM/yyyy HH:mm"));
            }
        }

        public static string GetDayOfWeekVN(DayOfWeek dow)
        {
            string strDayOfWeekName = "";
            switch (dow)
            {
                case DayOfWeek.Sunday:
                    strDayOfWeekName = "Chủ nhật";
                    break;
                case DayOfWeek.Monday:
                    strDayOfWeekName = "Thứ 2";
                    break;
                case DayOfWeek.Tuesday:
                    strDayOfWeekName = "Thứ 3";
                    break;
                case DayOfWeek.Wednesday:
                    strDayOfWeekName = "Thứ 4";
                    break;
                case DayOfWeek.Thursday:
                    strDayOfWeekName = "Thứ 5";
                    break;
                case DayOfWeek.Friday:
                    strDayOfWeekName = "Thứ 6";
                    break;
                case DayOfWeek.Saturday:
                    strDayOfWeekName = "Thứ 7";
                    break;
            }
            return strDayOfWeekName;
        }
        #endregion
    }
}
