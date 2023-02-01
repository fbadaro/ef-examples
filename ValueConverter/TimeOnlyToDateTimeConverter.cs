using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class TimeOnlyToDateTimeConverter : ValueConverter<TimeOnly, DateTime>
{
  public TimeOnlyToDateTimeConverter() : base(x => ConvertToDataBase(x), value => ConvertToApplication(value)) { }

  static DateTime ConvertToDataBase(TimeOnly time) => DateTime.Parse(time.ToString());

  static TimeOnly ConvertToApplication(DateTime dateTime) => TimeOnly.FromDateTime(dateTime);
}