using System.ComponentModel;

namespace MyExtensions.Enum
{
    public enum Day
    {
        [Description("Monday")]
        Mon,

        [Description("Tuesday")]
        Tue,

        [Description("Wednesday")]
        Wed,

        [Description("Thursday")]
        Thu,

        [Description("Friday")]
        Fri,

        [Description("Saturday")]
        Sat,

        [Description("Sunday")]
        Sun
    }
}