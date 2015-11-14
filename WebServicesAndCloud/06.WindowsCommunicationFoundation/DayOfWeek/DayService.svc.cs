namespace DayOfWeek
{
    using System;

    public class DayService : IDayService
    {
        public string GetDayOfWeek(DateTime date)
        {
            var culture = new System.Globalization.CultureInfo("bg-BG");
            return culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);
        }
    }
}
