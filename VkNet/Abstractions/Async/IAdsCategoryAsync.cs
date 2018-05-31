using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
    /// <summary>
    /// Асинхронные методы для работы со стеной пользователя.
    /// </summary>
    public interface IAdsCategoryAsync
    {
        /// <summary>
        /// Возвращает список рекламных кабинетов.
        /// </summary>
        /// <returns>
        /// В случае успеха возвращается список рекламных кабинетов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/ads.getAccounts
        /// </remarks>
        Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync();

        /// <summary>
        /// Возвращает список рекламных объявлений.
        /// </summary>
        /// <returns>
        /// В случае успеха возвращается список рекламных объявлений.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/ads.getAds
        /// </remarks>
        Task<ReadOnlyCollection<AdsAd>> GetAdsAsync(AdsGetAdsParams @params);

        /// <summary>
        /// Возвращает список рекламных кабинетов.
        /// </summary>
        /// <returns>
        /// В случае успеха возвращается список рекламных кабинетов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/ads.getCampaigns
        /// </remarks>
        Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams @params);
    }
}