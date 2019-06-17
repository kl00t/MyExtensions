using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace MyExtensions.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsWeekDay(this DateTime value)
        {
            return !value.IsWeekend();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static string ToDateString(this string period)
        {
            if (string.IsNullOrEmpty(period))
            {
                return string.Empty;
            }

            try
            {
                var dt = DateTime.ParseExact(period, "yyyyMMdd", CultureInfo.InvariantCulture);
                return dt.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string DateToString(this DateTime dateTime)
        {
            return string.Concat(dateTime.Year, "-", dateTime.Month, "-", dateTime.Day);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static string ToDay(this string period)
        {
            switch (period)
            {
                case "1":
                    return "Sun";
                case "2":
                    return "Mon";
                case "3":
                    return "Tue";
                case "4":
                    return "Wed";
                case "5":
                    return "Thu";
                case "6":
                    return "Fri";
                case "7":
                    return "Sat";
                default:
                    return period;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static string ToMonth(this string period)
        {
            switch (period)
            {
                case "1":
                    return "Jan";
                case "2":
                    return "Feb";
                case "3":
                    return "Mar";
                case "4":
                    return "Apr";
                case "5":
                    return "May";
                case "6":
                    return "Jun";
                case "7":
                    return "Jul";
                case "8":
                    return "Aug";
                case "9":
                    return "Sep";
                case "10":
                    return "Oct";
                case "11":
                    return "Nov";
                case "12":
                    return "Dec";
                default:
                    return period;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static string ToQuarter(this string period)
        {
            return String.IsNullOrEmpty(period) ? String.Empty : $"Q{period}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateToCheck"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static bool IsInRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return IsAfter(dateToCheck, startDate) && IsBefore(dateToCheck, endDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateToCheck"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime dateToCheck, DateTime startDate)
        {
            return dateToCheck >= startDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateToCheck"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime dateToCheck, DateTime endDate)
        {
            return dateToCheck <= endDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static DateTime StartOfFullWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            return dt.StartOfWeek(startOfWeek).AddDays(-7);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays((-1 * diff) + 6).Date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime? GetLatestNullableDate(this IEnumerable<DateTime?> source)
        {
            return source
                .OrderBy(x => x)
                .ThenBy(x => !x.HasValue)
                .Last();
        }
    }
}