using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
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
		public Task<ReadOnlyCollection<bool>> DeleteAdsAsync(DeleteAdsParams deleteAdsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteAds(deleteAdsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<bool>> DeleteCampaignsAsync(DeleteCampaignsParams deleteCampaignsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteCampaigns(deleteCampaignsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<bool>> DeleteClientsAsync(DeleteClientsParams deleteClientsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteClients(deleteClientsParams));
		}

		/// <inheritdoc/>
		public Task<bool> DeleteTargetGroupAsync(DeleteTargetGroupParams deleteTargetGroupParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteTargetGroup(deleteTargetGroupParams));
		}

		/// <inheritdoc/>
		public Task<bool> DeleteTargetPixelAsync(DeleteTargetPixelParams deleteTargetPixelParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteTargetPixel(deleteTargetPixelParams));
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
		public Task<ReadOnlyCollection<Layout>> GetAdsLayoutAsync(GetAdsLayoutParams getAdsLayoutParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAdsLayout(getAdsLayoutParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<AdsTargetingResult>> GetAdsTargetingAsync(GetAdsTargetingParams getAdsTargetingParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetAdsTargeting(getAdsTargetingParams));
		}

		/// <inheritdoc/>
		public Task<double> GetBudgetAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetBudget(accountId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams adsGetCampaignsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCampaigns(adsGetCampaignsParams));
		}

		/// <inheritdoc/>
		public Task<GetCategoriesResult> GetCategoriesAsync(Language lang)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCategories(lang));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetClientsResult>> GetClientsAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetClients(accountId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetDemographicsResult>> GetDemographicsAsync(GetDemographicsParams getDemographicsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetDemographics(getDemographicsParams));
		}

		/// <inheritdoc/>
		public Task<GetFloodStatsResult> GetFloodStatsAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetFloodStats(accountId));
		}

		/// <inheritdoc/>
		public Task<GetLookalikeRequestsResult> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLookalikeRequests(getLookalikeRequestsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetOfficeUsersResult>> GetOfficeUsersAsync(long accountId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetOfficeUsers(accountId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetPostsReachResult>> GetPostsReachAsync(long accountId, IdsType idsType, string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPostsReach(accountId, idsType, ids));
		}

		/// <inheritdoc/>
		public Task<GetRejectionReasonResult> GetRejectionReasonAsync(long accountId, long adId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRejectionReason(accountId, adId));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetStatisticsResult>> GetStatisticsAsync(GetStatisticsParams getStatisticsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetStatistics(getStatisticsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetSuggestionsResult>> GetSuggestionsAsync(GetSuggestionsParams getSuggestionsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetSuggestions(getSuggestionsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetTargetGroupsResult>> GetTargetGroupsAsync(long accountId, long? clientId = null, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetGroups(accountId, clientId, extended));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetTargetPixelsResult>> GetTargetPixelsAsync(long accountId, long? clientId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetTargetPixels(accountId, clientId));
		}

		/// <inheritdoc/>
		public Task<GetTargetingStatsResult> GetTargetingStatsAsync(GetTargetingStatsParams getTargetingStatsParams)
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
		public Task<long> ImportTargetContactsAsync(ImportTargetContactsParams importTargetContactsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => ImportTargetContacts(importTargetContactsParams));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<bool>> RemoveOfficeUsersAsync(RemoveOfficeUsersParams removeOfficeUsersParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveOfficeUsers(removeOfficeUsersParams));
		}

		/// <inheritdoc/>
		public Task<RemoveTargetContactsResult> RemoveTargetContactsAsync(RemoveTargetContactsParams removeTargetContactsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveTargetContacts(removeTargetContactsParams));
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
		public Task<ReadOnlyCollection<UpdateCampaignsResult>> UpdateCampaignsAsync(AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateCampaigns(campaignModDataSpecification));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<UpdateClientsResult>> UpdateClientsAsync(AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateClients(clientModDataSpecification));
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

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetMusiciansResult>> GetMusiciansAsync(string artistName)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMusicians(artistName));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<GetMusiciansByIdsResult>> GetMusiciansByIdsAsync(string ids)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMusiciansByIds(ids));
		}

		/// <inheritdoc/>
		public Task<ReadOnlyCollection<UpdateOfficeUsersResult>> UpdateOfficeUsersAsync(
			AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification)
		{
			return TypeHelper.TryInvokeMethodAsync(() => UpdateOfficeUsers(officeUsersSpecification));
		}
	}
}