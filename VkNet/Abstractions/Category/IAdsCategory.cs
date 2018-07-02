using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с рекламными кабинетам
	/// пользователя.
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
		ReadOnlyCollection<AdsAccount> GetAccounts();

		// getAds
		// getAdsLayout
		// getAdsTargeting
		// getBudget

		/// <summary>
		/// Возвращает список рекламных кабинетов.
		/// </summary>
		/// <returns>
		/// В случае успеха возвращается список рекламных кабинетов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/ads.getCampaigns
		/// </remarks>
		ReadOnlyCollection<AdsCampaign> GetCampaigns(AdsGetCampaignsParams @params);

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