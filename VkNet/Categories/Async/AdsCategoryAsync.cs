using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AdsCategory
{
	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> AddOfficeUsersAsync(AdsDataSpecificationParams<UserSpecification> adsDataSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => AddOfficeUsers(adsDataSpecification));

	/// <inheritdoc/>
	public Task<LinkStatus> CheckLinkAsync(CheckLinkParams checkLinkParams) =>
		TypeHelper.TryInvokeMethodAsync(() => CheckLink(checkLinkParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateAdsResult>> CreateAdsAsync(AdsDataSpecificationParams<AdSpecification> adsDataSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateAds(adsDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateCampaignResult>> CreateCampaignsAsync(
		AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateCampaigns(campaignsDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateClientResult>>
		CreateClientsAsync(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateClients(clientDataSpecification));

	/// <inheritdoc/>
	public Task<CreateLookALikeRequestResult> CreateLookalikeRequestAsync(CreateLookALikeRequestParams createLookALikeRequestParams) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateLookalikeRequest(createLookALikeRequestParams));

	/// <inheritdoc/>
	public Task<CreateTargetGroupResult> CreateTargetGroupAsync(CreateTargetGroupParams createTargetGroupParams) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateTargetGroup(createTargetGroupParams));

	/// <inheritdoc/>
	public Task<CreateTargetPixelResult> CreateTargetPixelAsync(CreateTargetPixelParams createTargetPixelParams) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateTargetPixel(createTargetPixelParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteAdsAsync(DeleteAdsParams deleteAdsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteAds(deleteAdsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteCampaignsAsync(DeleteCampaignsParams deleteCampaignsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteCampaigns(deleteCampaignsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteClientsAsync(DeleteClientsParams deleteClientsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteClients(deleteClientsParams));

	/// <inheritdoc/>
	public Task<bool> DeleteTargetGroupAsync(DeleteTargetGroupParams deleteTargetGroupParams) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteTargetGroup(deleteTargetGroupParams));

	/// <inheritdoc/>
	public Task<bool> DeleteTargetPixelAsync(DeleteTargetPixelParams deleteTargetPixelParams) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteTargetPixel(deleteTargetPixelParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync() => TypeHelper.TryInvokeMethodAsync(GetAccounts);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<Ad>> GetAdsAsync(GetAdsParams getAdsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAds(getAdsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<Layout>> GetAdsLayoutAsync(GetAdsLayoutParams getAdsLayoutParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAdsLayout(getAdsLayoutParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsTargetingResult>> GetAdsTargetingAsync(GetAdsTargetingParams getAdsTargetingParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAdsTargeting(getAdsTargetingParams));

	/// <inheritdoc/>
	public Task<double> GetBudgetAsync(long accountId) => TypeHelper.TryInvokeMethodAsync(() => GetBudget(accountId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams adsGetCampaignsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCampaigns(adsGetCampaignsParams));

	/// <inheritdoc/>
	public Task<GetCategoriesResult> GetCategoriesAsync(Language lang) => TypeHelper.TryInvokeMethodAsync(() => GetCategories(lang));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetClientsResult>> GetClientsAsync(long accountId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetClients(accountId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetDemographicsResult>> GetDemographicsAsync(GetDemographicsParams getDemographicsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetDemographics(getDemographicsParams));

	/// <inheritdoc/>
	public Task<GetFloodStatsResult> GetFloodStatsAsync(long accountId) => TypeHelper.TryInvokeMethodAsync(() => GetFloodStats(accountId));

	/// <inheritdoc/>
	public Task<GetLookalikeRequestsResult> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetLookalikeRequests(getLookalikeRequestsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetOfficeUsersResult>> GetOfficeUsersAsync(long accountId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetOfficeUsers(accountId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetPostsReachResult>> GetPostsReachAsync(long accountId, IdsType idsType, string ids) =>
		TypeHelper.TryInvokeMethodAsync(() => GetPostsReach(accountId, idsType, ids));

	/// <inheritdoc/>
	public Task<GetRejectionReasonResult> GetRejectionReasonAsync(long accountId, long adId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetRejectionReason(accountId, adId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetStatisticsResult>> GetStatisticsAsync(GetStatisticsParams getStatisticsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetStatistics(getStatisticsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetSuggestionsResult>> GetSuggestionsAsync(GetSuggestionsParams getSuggestionsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetSuggestions(getSuggestionsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetTargetGroupsResult>>
		GetTargetGroupsAsync(long accountId, long? clientId = null, bool? extended = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetTargetGroups(accountId, clientId, extended));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetTargetPixelsResult>> GetTargetPixelsAsync(long accountId, long? clientId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetTargetPixels(accountId, clientId));

	/// <inheritdoc/>
	public Task<GetTargetingStatsResult> GetTargetingStatsAsync(GetTargetingStatsParams getTargetingStatsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetTargetingStats(getTargetingStatsParams));

	/// <inheritdoc/>
	public Task<Uri> GetUploadUrlAsync(GetUploadUrlParams getUploadUrlParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetUploadUrl(getUploadUrlParams));

	/// <inheritdoc/>
	public Task<Uri> GetVideoUploadUrlAsync() => TypeHelper.TryInvokeMethodAsync(GetVideoUploadUrl);

	/// <inheritdoc/>
	public Task<long> ImportTargetContactsAsync(ImportTargetContactsParams importTargetContactsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => ImportTargetContacts(importTargetContactsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> RemoveOfficeUsersAsync(RemoveOfficeUsersParams removeOfficeUsersParams) =>
		TypeHelper.TryInvokeMethodAsync(() => RemoveOfficeUsers(removeOfficeUsersParams));

	/// <inheritdoc/>
	public Task<RemoveTargetContactsResult> RemoveTargetContactsAsync(RemoveTargetContactsParams removeTargetContactsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => RemoveTargetContacts(removeTargetContactsParams));

	/// <inheritdoc/>
	public Task<SaveLookALikeRequestResultResult>
		SaveLookalikeRequestResultAsync(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams) =>
		TypeHelper.TryInvokeMethodAsync(() => SaveLookalikeRequestResult(saveLookalikeRequestResultParams));

	/// <inheritdoc/>
	public Task<ShareTargetGroupResult> ShareTargetGroupAsync(ShareTargetGroupParams shareTargetGroupParams) =>
		TypeHelper.TryInvokeMethodAsync(() => ShareTargetGroup(shareTargetGroupParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateAdsResult>>
		UpdateAdsAsync(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateAds(adEditDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateCampaignsResult>> UpdateCampaignsAsync(
		AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateCampaigns(campaignModDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateClientsResult>> UpdateClientsAsync(
		AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateClients(clientModDataSpecification));

	/// <inheritdoc/>
	public Task<bool> UpdateTargetGroupAsync(UpdateTargetGroupParams updateTargetGroupParams) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateTargetGroup(updateTargetGroupParams));

	/// <inheritdoc/>
	public Task<bool> UpdateTargetPixelAsync(UpdateTargetPixelParams updateTargetPixelParams) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateTargetPixel(updateTargetPixelParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetMusiciansResult>> GetMusiciansAsync(string artistName) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMusicians(artistName));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetMusiciansByIdsResult>> GetMusiciansByIdsAsync(string ids) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMusiciansByIds(ids));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateOfficeUsersResult>> UpdateOfficeUsersAsync(
		AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateOfficeUsers(officeUsersSpecification));
}