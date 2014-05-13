using HtmlAgilityPack;

namespace VkApiGenerator.Console.Model
{
    public class VkMethodParam
    {
        public string Name { get; set; } 
        public string Description { get; set; }

        /// <summary>
        /// Обязательный параметр
        /// </summary>
        public bool IsMandatory { get; set; }

        public VkParamType Type { get; set; }

        public VkParamRestrictions Restrictions { get; set; }

        internal static VkParamRestrictions GetRestrictions(HtmlNode td)
        {
            if (td == null) return VkParamRestrictions.None;

            HtmlNode div = td.SelectSingleNode("div[@class='dev_param_opts']");
            if (div == null) return VkParamRestrictions.None;

            string value = div.InnerText.ToLowerInvariant();

            if (value.Contains("положительное число"))
                return VkParamRestrictions.PositiveDigit;

            return VkParamRestrictions.None;
        }
    }
}