using System;
namespace MyExtensions.Helpers
{
    public static class CalculationHelper
    {
        public static double Ratio(int? value, int? sum)
        {
            if (!(value > 0))
            {
                return 0;
            }
            if (!(sum > 0))
            {
                return 0;
            }

            return (double)(value / (double)sum);
        }

        public static double? Difference(double? originalNumber, double? newNumber)
        {
            if (originalNumber.HasValue && newNumber.HasValue)
            {
                return Difference(originalNumber.Value, newNumber.Value);
            }

            return null;
        }

        public static double Difference(double originalNumber, double newNumber)
        {
            var calc = newNumber - originalNumber;
            if (double.IsInfinity(calc) || double.IsNaN(calc))
            {
                return 0;
            }

            return calc;
        }

        public static double? Variance(int? thisPeriod, int? comparisonPeriod)
        {
            if (thisPeriod.HasValue && comparisonPeriod.HasValue)
            {
                return Variance(thisPeriod.Value, comparisonPeriod.Value);
            }

            return null;
        }

        public static double Variance(int thisPeriod, int comparisonPeriod)
        {
            var calc = (double)thisPeriod / comparisonPeriod;
            if (double.IsInfinity(calc) || double.IsNaN(calc))
            {
                return 0;
            }

            return Math.Round(calc - 1, 4);
        }

        public static double? PercentCalculateChange(int? originalNumber, int? newNumber)
        {
            if (originalNumber.HasValue && newNumber.HasValue)
            {
                return PercentCalculateChange(originalNumber.Value, newNumber.Value);
            }

            return null;
        }

        public static double PercentCalculateChange(int originalNumber, int newNumber)
        {
            var change = newNumber - originalNumber;
            var calc = (double)change / originalNumber;
            if (double.IsInfinity(calc) || double.IsNaN(calc))
            {
                return 0;
            }

            return calc;
        }

        public static double? PercentCalculateChange(double? originalNumber, double? newNumber)
        {
            if (originalNumber.HasValue && newNumber.HasValue)
            {
                return PercentCalculateChange(originalNumber.Value, newNumber.Value);
            }

            return null;
        }

        public static double PercentCalculateChange(double originalNumber, double newNumber)
        {
            var change = newNumber - originalNumber;
            var calc = change / originalNumber;
            if (double.IsInfinity(calc) || double.IsNaN(calc))
            {
                return 0;
            }

            return calc;
        }

        public static double? AverageTransactionValue(double? salesValue, int? salesQuantity)
        {
            if (salesValue.HasValue && salesQuantity.HasValue)
            {
                return AverageTransactionValue(salesValue.Value, salesQuantity.Value);
            }

            return null;
        }

        public static double AverageTransactionValue(double salesValue, int salesQuantity)
        {
            var calc = salesValue / salesQuantity;
            if (double.IsInfinity(calc) || double.IsNaN(calc))
            {
                return 0;
            }

            return calc;
        }

        public static double? CaptureRate(int? entranceCount, int? flowCount)
        {
            if (entranceCount.HasValue && flowCount.HasValue)
            {
                return CaptureRate(entranceCount.Value, flowCount.Value);
            }

            return null;
        }

        public static double CaptureRate(int entranceCount, int flowCount)
        {
            var calc = (double)entranceCount / flowCount;
            if (double.IsInfinity(calc) || double.IsNaN(calc))
            {
                return 0;
            }

            return calc;
        }

        public static double? ConversionRate(int? salesQuantity, int? entranceCount)
        {
            if (salesQuantity.HasValue && entranceCount.HasValue)
            {
                return ConversionRate(salesQuantity.Value, entranceCount.Value);
            }

            return null;
        }

        public static double ConversionRate(int salesQuantity, int entranceCount)
        {
            var calc = (double)salesQuantity / entranceCount;
            if (double.IsInfinity(calc) || double.IsNaN(calc))
            {
                return 0;
            }

            return calc;
        }

        public static int DaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).Days;
        }

        public static int DateRange(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).Days + 1;
        }
    }
}