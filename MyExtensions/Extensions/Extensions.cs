﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MyExtensions.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static IEnumerable<int> SplitStringToListInts(this string value, char separator)
        {
            try
            {
                return value.Split(separator).Select(int.Parse);
            }
            catch (Exception)
            {
                return new List<int>().AsEnumerable();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string TrimStringIncludingAndAfterPhrase(this string value, string phrase)
        {
            var index = value.IndexOf(phrase, StringComparison.Ordinal);
            return index > 0 ? value.Substring(0, index) : value;
        }

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
    }
}