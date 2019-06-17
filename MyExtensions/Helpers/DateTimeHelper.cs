using System;

namespace MyExtensions.Helpers
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime GetDateToday()
        {
            return DateTime.Today.Date;
        }

        public DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}