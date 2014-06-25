using System;
using System.Text;
using HtmlAgilityPack;
using VkApiGenerator.Extensions;

namespace VkApiGenerator.Model
{
    public class VkMethodParam
    {
        /// <summary>
        /// Название переменной на сервере Вконтакте
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание параметра
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Имя используемое в C# коде
        /// </summary>
        /// <remarks>
        /// К примеру, если <see cref="Name"/> равен user_id, то <see cref="CanonicalName"/> будет 
        /// </remarks>
        public string CanonicalName
        {
            get
            {
                if (string.IsNullOrEmpty(Name)) return string.Empty;

                string[] parts = Name.Split(new[] {"_", " "}, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 1) return parts[0];

                var sb = new StringBuilder(parts[0].ToLowerInvariant());
                for (int i = 1; i < parts.Length; i++)
                {
//                    string capitalized =
//                    char.ToUpperInvariant(parts[i][0]) + parts[i].Substring(1, parts[i].Length - 1);
                    sb.Append(parts[i].Capitalize());
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Обязательный параметр
        /// </summary>
        public bool IsMandatory { get; set; }

        public ReturnType Type { get; set; }

        public VkParamRestrictions Restrictions { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            Type = VkMethodInfo.GetReturnType(Description);

            switch (Type)
            {
                case ReturnType.Bool:
                    sb.Append("bool");
                    break;

                case ReturnType.Collection:
                    sb.Append("IEnumerable<>");
                    break;

                case ReturnType.Void:
                    sb.Append("void");
                    break;

                case ReturnType.Long:
                    if (Name == "count" || Name == "offset")
                        sb.Append("int");
                    else
                        sb.Append("long");
                    break;

                case ReturnType.String:
                    sb.Append("string");
                    break;

                case ReturnType.Double:
                    sb.Append("double");
                    break;

                default:
                    sb.Append("long"); // if unknown make it long
                    break;
            }

            if (!IsMandatory && Type != ReturnType.String)
                sb.Append("?");

            sb.Append(" ");

            sb.Append(CanonicalName);

            if (!IsMandatory)
                sb.Append(" = null");

            return sb.ToString();
        }

        internal static bool GetIsMandatory(HtmlNode td)
        {
            if (td == null) return false;

            HtmlNode div = td.SelectSingleNode("div[@class='dev_param_opts']");
            if (div == null) return false;

            string text = div.InnerText.ToLowerInvariant();
            if (string.IsNullOrEmpty(text)) return false;

            return text.Contains("обязательный");
        }

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