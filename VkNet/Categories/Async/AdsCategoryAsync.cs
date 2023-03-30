using System;
using System.Collections.ObjectModel;
using System.Threading;
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
	public Task<ReadOnlyCollection<bool>> AddOfficeUsersAsync(AdsDataSpecificationParams<UserSpecification> adsDataSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => AddOfficeUsers(adsDataSpecification));

	/// <inheritdoc/>
	public Task<LinkStatus> CheckLinkAsync(CheckLinkParams checkLinkParams,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CheckLink(checkLinkParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateAdsResult>> CreateAdsAsync(AdsDataSpecificationParams<AdSpecification> adsDataSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateAds(adsDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateCampaignResult>> CreateCampaignsAsync(
		AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateCampaigns(campaignsDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateClientResult>>
		CreateClientsAsync(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateClients(clientDataSpecification));

	/// <inheritdoc/>
	public Task<CreateLookALikeRequestResult> CreateLookalikeRequestAsync(CreateLookALikeRequestParams createLookALikeRequestParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateLookalikeRequest(createLookALikeRequestParams));

	/// <inheritdoc/>
	public Task<CreateTargetGroupResult> CreateTargetGroupAsync(CreateTargetGroupParams createTargetGroupParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateTargetGroup(createTargetGroupParams));

	/// <inheritdoc/>
	public Task<CreateTargetPixelResult> CreateTargetPixelAsync(CreateTargetPixelParams createTargetPixelParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateTargetPixel(createTargetPixelParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteAdsAsync(DeleteAdsParams deleteAdsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteAds(deleteAdsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteCampaignsAsync(DeleteCampaignsParams deleteCampaignsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteCampaigns(deleteCampaignsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteClientsAsync(DeleteClientsParams deleteClientsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteClients(deleteClientsParams));

	/// <inheritdoc/>
	public Task<bool> DeleteTargetGroupAsync(DeleteTargetGroupParams deleteTargetGroupParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteTargetGroup(deleteTargetGroupParams));

	/// <inheritdoc/>
	public Task<bool> DeleteTargetPixelAsync(DeleteTargetPixelParams deleteTargetPixelParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteTargetPixel(deleteTargetPixelParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetAccounts);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<Ad>> GetAdsAsync(GetAdsParams getAdsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAds(getAdsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<Layout>> GetAdsLayoutAsync(GetAdsLayoutParams getAdsLayoutParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAdsLayout(getAdsLayoutParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsTargetingResult>> GetAdsTargetingAsync(GetAdsTargetingParams getAdsTargetingParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAdsTargeting(getAdsTargetingParams));

	/// <inheritdoc/>
	public Task<double> GetBudgetAsync(long accountId,
										CancellationToken token) => TypeHelper.TryInvokeMethodAsync(() => GetBudget(accountId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams adsGetCampaignsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCampaigns(adsGetCampaignsParams));

	/// <inheritdoc/>
	public Task<GetCategoriesResult> GetCategoriesAsync(Language lang,
														CancellationToken token) => TypeHelper.TryInvokeMethodAsync(() => GetCategories(lang));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetClientsResult>> GetClientsAsync(long accountId,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetClients(accountId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetDemographicsResult>> GetDemographicsAsync(GetDemographicsParams getDemographicsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetDemographics(getDemographicsParams));

	/// <inheritdoc/>
	public Task<GetFloodStatsResult> GetFloodStatsAsync(long accountId,
														CancellationToken token) => TypeHelper.TryInvokeMethodAsync(() => GetFloodStats(accountId));

	/// <inheritdoc/>
	public Task<GetLookalikeRequestsResult> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetLookalikeRequests(getLookalikeRequestsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetOfficeUsersResult>> GetOfficeUsersAsync(long accountId,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetOfficeUsers(accountId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetPostsReachResult>> GetPostsReachAsync(long accountId, IdsType idsType, string ids,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetPostsReach(accountId, idsType, ids));

	/// <inheritdoc/>
	public Task<GetRejectionReasonResult> GetRejectionReasonAsync(long accountId, long adId,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetRejectionReason(accountId, adId));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetStatisticsResult>> GetStatisticsAsync(GetStatisticsParams getStatisticsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetStatistics(getStatisticsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetSuggestionsResult>> GetSuggestionsAsync(GetSuggestionsParams getSuggestionsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetSuggestions(getSuggestionsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetTargetGroupsResult>>
		GetTargetGroupsAsync(long accountId, long? clientId = null, bool? extended = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetTargetGroups(accountId, clientId, extended));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetTargetPixelsResult>> GetTargetPixelsAsync(long accountId, long? clientId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetTargetPixels(accountId, clientId));

	/// <inheritdoc/>
	public Task<GetTargetingStatsResult> GetTargetingStatsAsync(GetTargetingStatsParams getTargetingStatsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetTargetingStats(getTargetingStatsParams));

	/// <inheritdoc/>
	public Task<Uri> GetUploadUrlAsync(GetUploadUrlParams getUploadUrlParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetUploadUrl(getUploadUrlParams));

	/// <inheritdoc/>
	public Task<Uri> GetVideoUploadUrlAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetVideoUploadUrl);

	/// <inheritdoc/>
	public Task<long> ImportTargetContactsAsync(ImportTargetContactsParams importTargetContactsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => ImportTargetContacts(importTargetContactsParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> RemoveOfficeUsersAsync(RemoveOfficeUsersParams removeOfficeUsersParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => RemoveOfficeUsers(removeOfficeUsersParams));

	/// <inheritdoc/>
	public Task<RemoveTargetContactsResult> RemoveTargetContactsAsync(RemoveTargetContactsParams removeTargetContactsParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => RemoveTargetContacts(removeTargetContactsParams));

	/// <inheritdoc/>
	public Task<SaveLookALikeRequestResultResult>
		SaveLookalikeRequestResultAsync(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SaveLookalikeRequestResult(saveLookalikeRequestResultParams));

	/// <inheritdoc/>
	public Task<ShareTargetGroupResult> ShareTargetGroupAsync(ShareTargetGroupParams shareTargetGroupParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => ShareTargetGroup(shareTargetGroupParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateAdsResult>>
		UpdateAdsAsync(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateAds(adEditDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateCampaignsResult>> UpdateCampaignsAsync(
		AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateCampaigns(campaignModDataSpecification));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateClientsResult>> UpdateClientsAsync(
		AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateClients(clientModDataSpecification));

	/// <inheritdoc/>
	public Task<bool> UpdateTargetGroupAsync(UpdateTargetGroupParams updateTargetGroupParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateTargetGroup(updateTargetGroupParams));

	/// <inheritdoc/>
	public Task<bool> UpdateTargetPixelAsync(UpdateTargetPixelParams updateTargetPixelParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateTargetPixel(updateTargetPixelParams));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetMusiciansResult>> GetMusiciansAsync(string artistName,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMusicians(artistName));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetMusiciansByIdsResult>> GetMusiciansByIdsAsync(string ids,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMusiciansByIds(ids));

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateOfficeUsersResult>> UpdateOfficeUsersAsync(
		AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateOfficeUsers(officeUsersSpecification));
}