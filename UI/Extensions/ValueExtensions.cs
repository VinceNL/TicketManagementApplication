namespace UI.Extensions
{
    public static class ValueExtensions
    {
        public static int? ToNullableInteger(this string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }
    }
}
