﻿using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Abstractions.Async;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
    /// <summary>
    /// Методы этого класса позволяют производить действия с рекламными кабинетам пользователя.
    /// </summary>
    public interface IAdsCategory : IAdsCategoryAsync
    {

        // addOfficeUsers
        // checkLink
        // createAds
        // createCampaigns
        // createClients
        // createLookalikeRequest
        // createTargetGroup
        // createTargetPixel
        // deleteAds
        // deleteCampaigns
        // deleteClients
        // deleteTargetGroup
        // deleteTargetPixel

        /// <summary>
        /// Возвращает список рекламных кабинетов.
        /// </summary>
        /// <returns>
        /// В случае успеха возвращается список рекламных кабинетов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/ads.getAccounts
        /// </remarks>
        AdsGetAccountsObject GetAccounts(bool skipAuthorization = false);

        // getAds
        // getAdsLayout
        // getAdsTargeting
        // getBudget
        // getCampaigns
        // getCategories
        // getClients
        // getDemographics
        // getFloodStats
        // getLookalikeRequests
        // getOfficeUsers
        // getPostsReach
        // getRejectionReason
        // getStatistics
        // getSuggestions
        // getTargetGroups
        // getTargetPixels
        // getTargetingStats
        // getUploadURL
        // getVideoUploadURL
        // importTargetContacts
        // removeOfficeUsers
        // removeTargetContacts
        // saveLookalikeRequestResult
        // shareTargetGroup
        // updateAds
        // updateCampaigns
        // updateClients
        // updateTargetGroup
        // updateTargetPixel

    }
}