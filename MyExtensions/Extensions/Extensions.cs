using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MyExtensions.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="valueIfNotConverted"></param>
        /// <returns></returns>
        public static int TryParse(this string input, int valueIfNotConverted)
        {
            return int.TryParse(input, out var value) ? value : valueIfNotConverted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double? NullableSum(this IEnumerable<double?> source)
        {
            double? sum = null;
            foreach (double? v in source)
            {
                if (v != null)
                {
                    if (sum == null)
                    {
                        sum = 0;
                    }

                    sum += v.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int[] ToArray(this IEnumerable<int?> source)
        {
            return source.Select(v => v ?? 0).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int? NullableSum(this IEnumerable<int?> source)
        {
            int? sum = null;
            foreach (int? v in source)
            {
                if (v != null)
                {
                    if (sum == null)
                    {
                        sum = 0;
                    }

                    sum += v.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double? Round(this double? value, int decimalPlaces = 2)
        {
            if (!value.HasValue)
            {
                return null;
            }

            try
            {
                return Math.Round(value.Value, decimalPlaces);
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double Round(this double value, int decimalPlaces = 2)
        {
            try
            {
                return Math.Round(value, decimalPlaces);
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double RoundUp(this double? value, int decimalPlaces)
        {
            return value.HasValue ? RoundUp(value.Value, decimalPlaces) : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static double RoundUp(this double value, int decimalPlaces)
        {
            return Math.Round(value * 100, decimalPlaces);
        }

        /// <summary>
        /// Extension to convert an input value to a specific type (infers the type or accepts type T)
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="input">Incoming value</param>
        /// <param name="defaultValue">The fallback value</param>
        /// <returns>Converted value</returns>
        public static T ConvertToValue<T>(this string input, T defaultValue)
        {
            T retValue;
            if (!string.IsNullOrEmpty(input))
            {
                retValue = (T)Convert.ChangeType(input, typeof(T));
            }
            else
            {
                return defaultValue;
            }

            return retValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string input)
        {
            Guid output;
            if (!string.IsNullOrEmpty(input))
            {
                if (Guid.TryParse(input, out output))
                {
                    return output;
                }
            }
            else
            {
                return Guid.Empty;
            }

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ToSqlArray<T>(this T[] array)
        {
            return array == null ? "" : $"('{string.Join("','", array)}')";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ToDelimitedList<T>(this T[] array)
        {
            return array == null ? "" : $"{string.Join(",", array)}";
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
            return string.IsNullOrEmpty(period) ? string.Empty : $"Q{period}";
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
    }
}