using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AdsCategory
	{
		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> AddOfficeUsersAsync(long accountId, string data)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddOfficeUsers(accountId, data));
		}

		/// <inheritdoc/>
		public Task<LinkStatus> CheckLinkAsync(long accountId, AdsLinkType linkType, string linkUrl, long? campaignId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CheckLink(accountId, linkType, linkUrl, campaignId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> CreateAdsAsync(long accountId, string data)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateAds(accountId, data));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> CreateCampaignsAsync(long accountId, string data)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateCampaigns(accountId, data));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> CreateClientsAsync(long accountId, string data)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateClients(accountId, data));
		}

		/// <inheritdoc/>
		public Task<object> CreateLookalikeRequestAsync(long accountId, string sourceType, long? clientId = null,
														object retargetingGroupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateLookalikeRequest(accountId, sourceType, clientId, retargetingGroupId));
		}

		/// <inheritdoc/>
		public Task<object> CreateTargetGroupAsync(CreateTargetGroupParams createTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateTargetGroup(createTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<object> CreateTargetPixelAsync(long accountId, string name, string domain, long categoryId, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateTargetPixel(accountId, name, domain, categoryId, clientId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> DeleteAdsAsync(long accountId, string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteAds(accountId, ids));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> DeleteCampaignsAsync(long accountId, string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteCampaigns(accountId, ids));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> DeleteClientsAsync(long accountId, string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteClients(accountId, ids));
		}

		/// <inheritdoc/>
		public Task<bool> DeleteTargetGroupAsync(long accountId, long targetGroupId, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteTargetGroup(accountId, targetGroupId, clientId));
		}

		/// <inheritdoc/>
		public Task<bool> DeleteTargetPixelAsync(long accountId, long targetPixelId, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteTargetPixel(accountId, targetPixelId, clientId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAccounts());
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<Ad>> GetAdsAsync(GetAdsParams getAdsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAds(getAdsParams));
		}

		/// <inheritdoc/>
		public Task<Uri> GetAdsLayoutAsync(GetAdsLayoutParams getAdsLayoutParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAdsLayout(getAdsLayoutParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetAdsTargetingAsync(GetAdsTargetingParams getAdsTargetingParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAdsTargeting(getAdsTargetingParams));
		}

		/// <inheritdoc/>
		public Task<object> GetBudgetAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetBudget(accountId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(long accountId, IEnumerable<long> campaignIds,
																		long? clientId = null,
																		bool? includeDeleted = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCampaigns(accountId, campaignIds, clientId, includeDeleted));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetCategoriesAsync(string lang)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCategories(lang));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetClientsAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetClients(accountId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetDemographicsAsync(GetDemographicsParams getDemographicsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetDemographics(getDemographicsParams));
		}

		/// <inheritdoc/>
		public Task<object> GetFloodStatsAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetFloodStats(accountId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLookalikeRequests(getLookalikeRequestsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetOfficeUsersAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetOfficeUsers(accountId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetPostsReachAsync(long accountId, string idsType, string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPostsReach(accountId, idsType, ids));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetRejectionReasonAsync(long accountId, long adId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRejectionReason(accountId, adId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetStatisticsAsync(GetStatisticsParams getStatisticsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetStatistics(getStatisticsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetSuggestionsAsync(GetSuggestionsParams getSuggestionsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetSuggestions(getSuggestionsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetTargetGroupsAsync(long accountId, long? clientId = null, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetGroups(accountId, clientId, extended));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> GetTargetPixelsAsync(long accountId, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetPixels(accountId, clientId));
		}

		/// <inheritdoc/>
		public Task<object> GetTargetingStatsAsync(GetTargetingStatsParams getTargetingStatsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetingStats(getTargetingStatsParams));
		}

		/// <inheritdoc/>
		public Task<Uri> GetUploadUrlAsync(long adFormat)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetUploadUrl(adFormat));
		}

		/// <inheritdoc/>
		public Task<Uri> GetVideoUploadUrlAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetVideoUploadUrl);
		}

		/// <inheritdoc/>
		public Task<object> ImportTargetContactsAsync(long accountId, long targetGroupId, string contacts, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ImportTargetContacts(accountId, targetGroupId, contacts, clientId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> RemoveOfficeUsersAsync(long accountId, string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveOfficeUsers(accountId, ids));
		}

		/// <inheritdoc/>
		public Task<bool> RemoveTargetContactsAsync(long accountId, long targetGroupId, string contacts, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveTargetContacts(accountId, targetGroupId, contacts, clientId));
		}

		/// <inheritdoc/>
		public Task<object> SaveLookalikeRequestResultAsync(long accountId, long requestId, long level, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SaveLookalikeRequestResult(accountId, requestId, level, clientId));
		}

		/// <inheritdoc/>
		public Task<object> ShareTargetGroupAsync(long accountId, long targetGroupId, long? clientId = null,
												long? shareWithClientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ShareTargetGroup(accountId, targetGroupId, clientId, shareWithClientId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> UpdateAdsAsync(long accountId, string data)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateAds(accountId, data));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> UpdateCampaignsAsync(long accountId, string data)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateCampaigns(accountId, data));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<object>> UpdateClientsAsync(long accountId, string data)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateClients(accountId, data));
		}

		/// <inheritdoc/>
		public Task<bool> UpdateTargetGroupAsync(UpdateTargetGroupParams updateTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateTargetGroup(updateTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<bool> UpdateTargetPixelAsync(UpdateTargetPixelParams updateTargetPixelParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateTargetPixel(updateTargetPixelParams));
		}
	}
}