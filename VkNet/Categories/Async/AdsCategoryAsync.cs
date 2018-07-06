using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Ads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AdsCategory
	{
		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> AddOfficeUsersAsync(long accountId, string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => AddOfficeUsers(accountId, data));
		}

		/// <inheritdoc/>
		public async Task<Uri> CheckLinkAsync(long accountId, string linkType, string linkUrl, long? campaignId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => CheckLink(accountId, linkType, linkUrl, campaignId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> CreateAdsAsync(long accountId, string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => CreateAds(accountId, data));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> CreateCampaignsAsync(long accountId, string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => CreateCampaigns(accountId, data));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> CreateClientsAsync(long accountId, string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => CreateClients(accountId, data));
		}

		/// <inheritdoc/>
		public async Task<object> CreateLookalikeRequestAsync(long accountId, string sourceType, long? clientId = null,
															object retargetingGroupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => CreateLookalikeRequest(accountId, sourceType, clientId, retargetingGroupId));
		}

		/// <inheritdoc/>
		public async Task<object> CreateTargetGroupAsync(CreateTargetGroupParams createTargetGroupParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => CreateTargetGroup(createTargetGroupParams));
		}

		/// <inheritdoc/>
		public async Task<object> CreateTargetPixelAsync(long accountId, string name, string domain, long categoryId, long? clientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => CreateTargetPixel(accountId, name, domain, categoryId, clientId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> DeleteAdsAsync(long accountId, string ids)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => DeleteAds(accountId, ids));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> DeleteCampaignsAsync(long accountId, string ids)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => DeleteCampaigns(accountId, ids));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> DeleteClientsAsync(long accountId, string ids)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => DeleteClients(accountId, ids));
		}

		/// <inheritdoc/>
		public async Task<bool> DeleteTargetGroupAsync(long accountId, long targetGroupId, long? clientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => DeleteTargetGroup(accountId, targetGroupId, clientId));
		}

		/// <inheritdoc/>
		public async Task<bool> DeleteTargetPixelAsync(long accountId, long targetPixelId, long? clientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => DeleteTargetPixel(accountId, targetPixelId, clientId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetAccounts());
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetAdsAsync(GetAdsParams getAdsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetAds(getAdsParams));
		}

		/// <inheritdoc/>
		public async Task<Uri> GetAdsLayoutAsync(GetAdsLayoutParams getAdsLayoutParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetAdsLayout(getAdsLayoutParams));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetAdsTargetingAsync(GetAdsTargetingParams getAdsTargetingParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetAdsTargeting(getAdsTargetingParams));
		}

		/// <inheritdoc/>
		public async Task<object> GetBudgetAsync(long accountId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetBudget(accountId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(long accountId, IEnumerable<long> campaignIds,
																			long? clientId = null,
																			bool? includeDeleted = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetCampaigns(accountId, campaignIds, clientId, includeDeleted));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetCategoriesAsync(string lang)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetCategories(lang));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetClientsAsync(long accountId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetClients(accountId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetDemographicsAsync(GetDemographicsParams getDemographicsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetDemographics(getDemographicsParams));
		}

		/// <inheritdoc/>
		public async Task<object> GetFloodStatsAsync(long accountId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetFloodStats(accountId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetLookalikeRequests(getLookalikeRequestsParams));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetOfficeUsersAsync(long accountId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetOfficeUsers(accountId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetPostsReachAsync(long accountId, string idsType, string ids)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetPostsReach(accountId, idsType, ids));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetRejectionReasonAsync(long accountId, long adId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetRejectionReason(accountId, adId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetStatisticsAsync(GetStatisticsParams getStatisticsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetStatistics(getStatisticsParams));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetSuggestionsAsync(GetSuggestionsParams getSuggestionsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetSuggestions(getSuggestionsParams));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetTargetGroupsAsync(long accountId, long? clientId = null, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetTargetGroups(accountId, clientId, extended));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> GetTargetPixelsAsync(long accountId, long? clientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetTargetPixels(accountId, clientId));
		}

		/// <inheritdoc/>
		public async Task<object> GetTargetingStatsAsync(GetTargetingStatsParams getTargetingStatsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetTargetingStats(getTargetingStatsParams));
		}

		/// <inheritdoc/>
		public async Task<Uri> GetUploadURLAsync(long adFormat)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetUploadURL(adFormat));
		}

		/// <inheritdoc/>
		public async Task<Uri> GetVideoUploadURLAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(GetVideoUploadURL);
		}

		/// <inheritdoc/>
		public async Task<object> ImportTargetContactsAsync(long accountId, long targetGroupId, string contacts, long? clientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => ImportTargetContacts(accountId, targetGroupId, contacts, clientId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> RemoveOfficeUsersAsync(long accountId, string ids)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => RemoveOfficeUsers(accountId, ids));
		}

		/// <inheritdoc/>
		public async Task<bool> RemoveTargetContactsAsync(long accountId, long targetGroupId, string contacts, long? clientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => RemoveTargetContacts(accountId, targetGroupId, contacts, clientId));
		}

		/// <inheritdoc/>
		public async Task<object> SaveLookalikeRequestResultAsync(long accountId, long requestId, long level, long? clientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => SaveLookalikeRequestResult(accountId, requestId, level, clientId));
		}

		/// <inheritdoc/>
		public async Task<object> ShareTargetGroupAsync(long accountId, long targetGroupId, long? clientId = null,
														long? shareWithClientId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => ShareTargetGroup(accountId, targetGroupId, clientId, shareWithClientId));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> UpdateAdsAsync(long accountId, string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => UpdateAds(accountId, data));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> UpdateCampaignsAsync(long accountId, string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => UpdateCampaigns(accountId, data));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<object>> UpdateClientsAsync(long accountId, string data)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => UpdateClients(accountId, data));
		}

		/// <inheritdoc/>
		public async Task<bool> UpdateTargetGroupAsync(UpdateTargetGroupParams updateTargetGroupParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => UpdateTargetGroup(updateTargetGroupParams));
		}

		/// <inheritdoc/>
		public async Task<bool> UpdateTargetPixelAsync(UpdateTargetPixelParams updateTargetPixelParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => UpdateTargetPixel(updateTargetPixelParams));
		}
	}
}