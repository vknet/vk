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
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddOfficeUsers(adsDataSpecification), token);

	/// <inheritdoc/>
	public Task<LinkStatus> CheckLinkAsync(CheckLinkParams checkLinkParams,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckLink(checkLinkParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateAdsResult>> CreateAdsAsync(AdsDataSpecificationParams<AdSpecification> adsDataSpecification,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateAds(adsDataSpecification), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateCampaignResult>> CreateCampaignsAsync(AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification,
																				CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateCampaigns(campaignsDataSpecification), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<CreateClientResult>>
		CreateClientsAsync(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification,
							CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateClients(clientDataSpecification), token);

	/// <inheritdoc/>
	public Task<CreateLookALikeRequestResult> CreateLookalikeRequestAsync(CreateLookALikeRequestParams createLookALikeRequestParams,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateLookalikeRequest(createLookALikeRequestParams), token);

	/// <inheritdoc/>
	public Task<CreateTargetGroupResult> CreateTargetGroupAsync(CreateTargetGroupParams createTargetGroupParams,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateTargetGroup(createTargetGroupParams), token);

	/// <inheritdoc/>
	public Task<CreateTargetPixelResult> CreateTargetPixelAsync(CreateTargetPixelParams createTargetPixelParams,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateTargetPixel(createTargetPixelParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteAdsAsync(DeleteAdsParams deleteAdsParams,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteAds(deleteAdsParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteCampaignsAsync(DeleteCampaignsParams deleteCampaignsParams,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteCampaigns(deleteCampaignsParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> DeleteClientsAsync(DeleteClientsParams deleteClientsParams,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteClients(deleteClientsParams), token);

	/// <inheritdoc/>
	public Task<bool> DeleteTargetGroupAsync(DeleteTargetGroupParams deleteTargetGroupParams,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteTargetGroup(deleteTargetGroupParams), token);

	/// <inheritdoc/>
	public Task<bool> DeleteTargetPixelAsync(DeleteTargetPixelParams deleteTargetPixelParams,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteTargetPixel(deleteTargetPixelParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetAccounts, token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<Ad>> GetAdsAsync(GetAdsParams getAdsParams,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAds(getAdsParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<Layout>> GetAdsLayoutAsync(GetAdsLayoutParams getAdsLayoutParams,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAdsLayout(getAdsLayoutParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsTargetingResult>> GetAdsTargetingAsync(GetAdsTargetingParams getAdsTargetingParams,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAdsTargeting(getAdsTargetingParams), token);

	/// <inheritdoc/>
	public Task<double> GetBudgetAsync(long accountId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBudget(accountId), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams adsGetCampaignsParams,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCampaigns(adsGetCampaignsParams), token);

	/// <inheritdoc/>
	public Task<GetCategoriesResult> GetCategoriesAsync(Language lang,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCategories(lang), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetClientsResult>> GetClientsAsync(long accountId,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetClients(accountId), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetDemographicsResult>> GetDemographicsAsync(GetDemographicsParams getDemographicsParams,
																				CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetDemographics(getDemographicsParams), token);

	/// <inheritdoc/>
	public Task<GetFloodStatsResult> GetFloodStatsAsync(long accountId,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetFloodStats(accountId), token);

	/// <inheritdoc/>
	public Task<GetLookalikeRequestsResult> GetLookalikeRequestsAsync(GetLookalikeRequestsParams getLookalikeRequestsParams,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLookalikeRequests(getLookalikeRequestsParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetOfficeUsersResult>> GetOfficeUsersAsync(long accountId,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetOfficeUsers(accountId), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetPostsReachResult>> GetPostsReachAsync(long accountId,
																			IdsType idsType,
																			string ids,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPostsReach(accountId, idsType, ids), token);

	/// <inheritdoc/>
	public Task<GetRejectionReasonResult> GetRejectionReasonAsync(long accountId,
																long adId,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRejectionReason(accountId, adId), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetStatisticsResult>> GetStatisticsAsync(GetStatisticsParams getStatisticsParams,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStatistics(getStatisticsParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetSuggestionsResult>> GetSuggestionsAsync(GetSuggestionsParams getSuggestionsParams,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSuggestions(getSuggestionsParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetTargetGroupsResult>>
		GetTargetGroupsAsync(long accountId, long?
								clientId = null,
							bool? extended = null,
							CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTargetGroups(accountId, clientId, extended), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetTargetPixelsResult>> GetTargetPixelsAsync(long accountId,
																				long? clientId = null,
																				CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTargetPixels(accountId, clientId), token);

	/// <inheritdoc/>
	public Task<GetTargetingStatsResult> GetTargetingStatsAsync(GetTargetingStatsParams getTargetingStatsParams,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTargetingStats(getTargetingStatsParams), token);

	/// <inheritdoc/>
	public Task<Uri> GetUploadUrlAsync(GetUploadUrlParams getUploadUrlParams,

										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUploadUrl(getUploadUrlParams), token);

	/// <inheritdoc/>
	public Task<Uri> GetVideoUploadUrlAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetVideoUploadUrl, token);

	/// <inheritdoc/>
	public Task<long> ImportTargetContactsAsync(ImportTargetContactsParams importTargetContactsParams,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ImportTargetContacts(importTargetContactsParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<bool>> RemoveOfficeUsersAsync(RemoveOfficeUsersParams removeOfficeUsersParams,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveOfficeUsers(removeOfficeUsersParams), token);

	/// <inheritdoc/>
	public Task<RemoveTargetContactsResult> RemoveTargetContactsAsync(RemoveTargetContactsParams removeTargetContactsParams,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveTargetContacts(removeTargetContactsParams), token);

	/// <inheritdoc/>
	public Task<SaveLookALikeRequestResultResult>
		SaveLookalikeRequestResultAsync(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveLookalikeRequestResult(saveLookalikeRequestResultParams), token);

	/// <inheritdoc/>
	public Task<ShareTargetGroupResult> ShareTargetGroupAsync(ShareTargetGroupParams shareTargetGroupParams,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ShareTargetGroup(shareTargetGroupParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateAdsResult>>
		UpdateAdsAsync(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification,
						CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UpdateAds(adEditDataSpecification), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateCampaignsResult>> UpdateCampaignsAsync(
		AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification,
		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UpdateCampaigns(campaignModDataSpecification), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateClientsResult>> UpdateClientsAsync(
		AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification,
		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UpdateClients(clientModDataSpecification), token);

	/// <inheritdoc/>
	public Task<bool> UpdateTargetGroupAsync(UpdateTargetGroupParams updateTargetGroupParams,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UpdateTargetGroup(updateTargetGroupParams), token);

	/// <inheritdoc/>
	public Task<bool> UpdateTargetPixelAsync(UpdateTargetPixelParams updateTargetPixelParams,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UpdateTargetPixel(updateTargetPixelParams), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetMusiciansResult>> GetMusiciansAsync(string artistName,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMusicians(artistName), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<GetMusiciansByIdsResult>> GetMusiciansByIdsAsync(string ids,
																					CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMusiciansByIds(ids), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<UpdateOfficeUsersResult>> UpdateOfficeUsersAsync(
		AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification,
		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UpdateOfficeUsers(officeUsersSpecification), token);
}