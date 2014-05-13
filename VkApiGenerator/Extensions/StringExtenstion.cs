namespace VkApiGenerator.Extensions
{
    public static class StringExtenstion
    {
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            return char.ToUpperInvariant(str[0]) + str.Substring(1, str.Length - 1);
        }
    }
}