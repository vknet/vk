using System;
using HtmlAgilityPack;

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
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Обязательный параметр
        /// </summary>
        public bool IsMandatory { get; set; }

        public VkParamType Type { get; set; }

        public VkParamRestrictions Restrictions { get; set; }

        public override string ToString()
        {
           throw new NotImplementedException();
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