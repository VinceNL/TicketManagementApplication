namespace UI.Extensions
{
    public static class DateTimeExtensions
    {
        public static string BeautifyDate(this DateTime date)
        {
            return date.ToString("dd MMMM yyyy hh:mm tt");
        }

        public static string BeautifyDate(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.BeautifyDate();
            }
            return string.Empty;
        }
    }
}
