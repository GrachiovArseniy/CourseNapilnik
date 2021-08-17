namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static bool IsInvalid(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
