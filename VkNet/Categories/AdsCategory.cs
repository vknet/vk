using VkNet.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VkNet.Categories
{
  /// <summary>
  /// Методы для работы со стеной пользователя.
  /// </summary>
  public partial class AdsCategory : IAdsCategory
  {
    private readonly VkApi _vk;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vk"></param>
    public AdsCategory(VkApi vk)
    {
      _vk = vk;
    }

        /// <summary>
        /// Возвращает список рекламных кабинетов.
        /// </summary>
        /// <returns>
        /// В случае успеха возвращается список рекламных кабинетов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/ads.getAccounts
        /// </remarks>
        /// 
        public AdsGetAccountsObject GetAccounts(bool skipAuthorization = false)
        {
            return _vk.Call("ads.getAccounts", new VkParameters(), skipAuthorization);
        }

    }
}
