using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
    /// <summary>
    /// Список параметров для метода utils.getShortLink
    /// </summary>
    public struct UtilsGetShortLinkParams
    {
        /// <summary>
        /// URL, для которого необходимо получить сокращенный вариант.
        /// </summary>
        public string Url
        { get; set; }

        /// <summary>
        /// True — статистика ссылки приватная. False — статистика ссылки общедоступная.
        /// </summary>
        public bool? Private
        { get; set; }

        /// <summary>
        /// Привести к типу VkParameters.
        /// </summary>
        /// <param name="p">Параметры.</param>
        /// <returns></returns>
        public static VkParameters ToVkParameters(UtilsGetShortLinkParams p)
        {
            return new VkParameters
            {
                { "url", p.Url },
                { "private", p.Private }
            };
        }
    }
}
