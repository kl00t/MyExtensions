﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MyExtensions.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime value)
        {
            return (DateTime.DaysInMonth(value.Year, 2) == 29);
        }

        /// <summary>
        /// Returns true if the date is a weekend day.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }

        /// <summary>
        /// Returns true if the date is a week day.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsWeekDay(this DateTime value)
        {
            return !value.IsWeekend();
        }

        /// <summary>
        /// Takes a string date and returns formatted string date 01 Apr 2019
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
        /// Takes date and returns a formatted string 01-04-2019
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string DateToString(this DateTime dateTime)
        {
            return string.Concat(dateTime.Year, "-", dateTime.Month, "-", dateTime.Day);
        }

        /// <summary>
        /// Returns a string representing the day number.
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static string ToDay(this string period)
        {
            return period switch
            {
                "1" => "Sun",
                "2" => "Mon",
                "3" => "Tue",
                "4" => "Wed",
                "5" => "Thu",
                "6" => "Fri",
                "7" => "Sat",
                _ => period,
            };
        }

        /// <summary>
        /// Returns a string representing the month number.
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static string ToMonth(this string period)
        {
            return period switch
            {
                "1" => "Jan",
                "2" => "Feb",
                "3" => "Mar",
                "4" => "Apr",
                "5" => "May",
                "6" => "Jun",
                "7" => "Jul",
                "8" => "Aug",
                "9" => "Sep",
                "10" => "Oct",
                "11" => "Nov",
                "12" => "Dec",
                _ => period,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static string ToQuarter(this string period)
        {
            return string.IsNullOrEmpty(period) ? string.Empty : $"Q{period}";
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

        /// <summary>
        /// Returns the date of the last day of the month.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }
    }
}