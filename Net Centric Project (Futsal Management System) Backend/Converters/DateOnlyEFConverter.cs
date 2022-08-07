using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Converters
{
    public class DateOnlyEFConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyEFConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            dt => DateOnly.FromDateTime(dt))
        { }
    }
}
