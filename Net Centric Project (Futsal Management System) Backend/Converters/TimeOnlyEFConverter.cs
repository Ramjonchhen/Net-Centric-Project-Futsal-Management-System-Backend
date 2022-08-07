using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Converters
{
    public class TimeOnlyEFConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyEFConverter() : base(
            t => t.ToTimeSpan(),
            ts => TimeOnly.FromTimeSpan(ts))
        { }
    }
}
