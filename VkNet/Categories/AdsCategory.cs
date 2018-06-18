using VkNet.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public ReadOnlyCollection<AdsAccount> GetAccounts()
    {
		return _vk.Call<ReadOnlyCollection<AdsAccount>>("ads.getAccounts", new VkParameters());
	}

    /// <summary>
    /// Возвращает список рекламных объявлений.
    /// </summary>
    /// <returns>
    /// В случае успеха возвращается список рекламных объявлений.
    /// </returns>
    /// <remarks>
    /// Страница документации ВКонтакте https://vk.com/dev/ads.getAds
    /// </remarks>
    public ReadOnlyCollection<AdsAd> GetAds(AdsGetAdsParams @params)
    {
        return _vk.Call<ReadOnlyCollection<AdsAd>>("ads.getAds", @params);
    }

    /// <summary>
    /// Возвращает список рекламных кабинетов.
    /// </summary>
    /// <returns>
    /// В случае успеха возвращается список рекламных кабинетов.
    /// </returns>
    /// <remarks>
    /// Страница документации ВКонтакте https://vk.com/dev/ads.getCampaigns
    /// </remarks>
    public ReadOnlyCollection<AdsCampaign> GetCampaigns(AdsGetCampaignsParams @params)
    {
        return _vk.Call<ReadOnlyCollection<AdsCampaign>>("ads.getCampaigns", @params);
    }

		// ads.getClients https://vk.com/dev/ads.getClients
		// ads.getBudget https://vk.com/dev/ads.getBudget
		// ads.getStatistics https://vk.com/dev/ads.getStatistics
		// ads.getFloodStats https://vk.com/dev/ads.getFloodStats
	}
}
