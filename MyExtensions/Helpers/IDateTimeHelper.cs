using System;

namespace MyExtensions.Helpers
{
    public interface IDateTimeHelper
    {
        DateTime GetDateToday();

        DateTime GetDateTimeNow();

        DateTime CalculateLocalDate(int utcOffset);
    }
}