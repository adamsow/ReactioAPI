namespace ReactioAPI.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotEmpty(this string message)
            => !string.IsNullOrWhiteSpace(message);

        public static bool IsEmpty(this string message)
            => string.IsNullOrWhiteSpace(message);
    }
}
