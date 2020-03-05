using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AdsCategory
	{
		/// <inheritdoc/>
		public Task<ReadOnlyCollection<bool>> AddOfficeUsersAsync(AdsDataSpecificationParams<UserSpecification> adsDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddOfficeUsers(adsDataSpecification));
		}

		/// <inheritdoc/>
		public Task<LinkStatus> CheckLinkAsync(CheckLinkParams checkLinkParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CheckLink(checkLinkParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<CreateAdsResult>> CreateAdsAsync(AdsDataSpecificationParams<AdSpecification> adsDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateAds(adsDataSpecification));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<CreateCampaignResult>> CreateCampaignsAsync(AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateCampaigns(campaignsDataSpecification));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<CreateClientResult>> CreateClientsAsync(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateClients(clientDataSpecification));
		}

		/// <inheritdoc/>
		public Task<CreateLookALikeRequestResult> CreateLookalikeRequestAsync(CreateLookALikeRequestParams createLookALikeRequestParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateLookalikeRequest(createLookALikeRequestParams));
		}

		/// <inheritdoc/>
		public Task<CreateTargetGroupResult> CreateTargetGroupAsync(CreateTargetGroupParams createTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateTargetGroup(createTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<CreateTargetPixelResult> CreateTargetPixelAsync(CreateTargetPixelParams createTargetPixelParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateTargetPixel(createTargetPixelParams));
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
			return TypeHelper.TryInvokeMethodAsync(GetAccounts);
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
		public Task<GetLookalikeRequestsResult> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams)
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
		public Task<Uri> GetUploadUrlAsync(GetUploadUrlParams getUploadUrlParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetUploadUrl(getUploadUrlParams));
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
		public Task<SaveLookALikeRequestResultResult> SaveLookalikeRequestResultAsync(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams )
		{
			return TypeHelper.TryInvokeMethodAsync(() => SaveLookalikeRequestResult(saveLookalikeRequestResultParams));
		}

		/// <inheritdoc/>
		public Task<ShareTargetGroupResult> ShareTargetGroupAsync(ShareTargetGroupParams shareTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ShareTargetGroup(shareTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<UpdateAdsResult>> UpdateAdsAsync(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateAds(adEditDataSpecification));
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