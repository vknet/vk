namespace VkApiGenerator.Extensions
{
    public static class StringExtenstion
    {
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            str = str.Trim();

            return char.ToUpperInvariant(str[0]) + str.Substring(1, str.Length - 1);
        }

        public static string TransformXmlDocCommentes(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            return str.Replace("\n", "\n/// ");
        }
    }
}