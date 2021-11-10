using System;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IAdsCategoryAsync"/>
	public interface IAdsCategory : IAdsCategoryAsync
	{
		/// <inheritdoc cref="IAdsCategoryAsync.AddOfficeUsersAsync"/>
		ReadOnlyCollection<bool> AddOfficeUsers(AdsDataSpecificationParams<UserSpecification> adsDataSpecification);

		/// <inheritdoc cref="IAdsCategoryAsync.CheckLinkAsync"/>
		LinkStatus CheckLink(CheckLinkParams checkLinkParams);

		/// <inheritdoc cref="IAdsCategoryAsync.CreateAdsAsync"/>
		ReadOnlyCollection<CreateAdsResult> CreateAds(AdsDataSpecificationParams<AdSpecification> adsDataSpecification);

		/// <inheritdoc cref="IAdsCategoryAsync.CreateCampaignsAsync"/>
		ReadOnlyCollection<CreateCampaignResult> CreateCampaigns(AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification);

		/// <inheritdoc cref="IAdsCategoryAsync.CreateClientsAsync"/>
		ReadOnlyCollection<CreateClientResult> CreateClients(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification);

		/// <inheritdoc cref="IAdsCategoryAsync.CreateLookalikeRequestAsync"/>
		CreateLookALikeRequestResult CreateLookalikeRequest(CreateLookALikeRequestParams createLookALikeRequestParams);

		/// <inheritdoc cref="IAdsCategoryAsync.CreateTargetGroupAsync"/>
		CreateTargetGroupResult CreateTargetGroup(CreateTargetGroupParams createTargetGroupParams);

		/// <inheritdoc cref="IAdsCategoryAsync.CreateTargetPixelAsync"/>
		CreateTargetPixelResult CreateTargetPixel(CreateTargetPixelParams createTargetPixelParams);

		/// <inheritdoc cref="IAdsCategoryAsync.DeleteAdsAsync"/>
		ReadOnlyCollection<bool> DeleteAds(DeleteAdsParams deleteAdsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.DeleteCampaignsAsync"/>
		ReadOnlyCollection<bool> DeleteCampaigns(DeleteCampaignsParams deleteCampaignsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.DeleteClientsAsync"/>
		ReadOnlyCollection<bool> DeleteClients(DeleteClientsParams deleteClientsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.DeleteTargetGroupAsync"/>
		bool DeleteTargetGroup(DeleteTargetGroupParams deleteTargetGroupParams);

		/// <inheritdoc cref="IAdsCategoryAsync.DeleteTargetPixelAsync"/>
		bool DeleteTargetPixel(DeleteTargetPixelParams deleteTargetPixelParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetAccountsAsync"/>
		ReadOnlyCollection<AdsAccount> GetAccounts();

		/// <inheritdoc cref="IAdsCategoryAsync.GetAdsAsync"/>
		ReadOnlyCollection<Ad> GetAds(GetAdsParams getAdsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetAdsLayoutAsync"/>
		ReadOnlyCollection<Layout> GetAdsLayout(GetAdsLayoutParams getAdsLayoutParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetAdsTargetingAsync"/>
		ReadOnlyCollection<AdsTargetingResult> GetAdsTargeting(GetAdsTargetingParams getAdsTargetingParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetBudgetAsync"/>
		double GetBudget(long accountId);

		/// <inheritdoc cref="IAdsCategoryAsync.GetCampaignsAsync"/>
		ReadOnlyCollection<AdsCampaign> GetCampaigns(AdsGetCampaignsParams adsGetCampaignsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetCategoriesAsync"/>
		GetCategoriesResult GetCategories(Language lang);

		/// <inheritdoc cref="IAdsCategoryAsync.GetClientsAsync"/>
		ReadOnlyCollection<GetClientsResult> GetClients(long accountId);

		/// <inheritdoc cref="IAdsCategoryAsync.GetDemographicsAsync"/>
		ReadOnlyCollection<GetDemographicsResult> GetDemographics(GetDemographicsParams getDemographicsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetFloodStatsAsync"/>
		GetFloodStatsResult GetFloodStats(long accountId);

		/// <inheritdoc cref="IAdsCategoryAsync.GetLookalikeRequestsAsync"/>
		GetLookalikeRequestsResult GetLookalikeRequests(GetLookalikeRequestsParams getLookalikeRequestsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetOfficeUsersAsync"/>
		ReadOnlyCollection<GetOfficeUsersResult> GetOfficeUsers(long accountId);

		/// <inheritdoc cref="IAdsCategoryAsync.GetPostsReachAsync"/>
		ReadOnlyCollection<GetPostsReachResult> GetPostsReach(long accountId, IdsType idsType, string ids);

		/// <inheritdoc cref="IAdsCategoryAsync.GetRejectionReasonAsync"/>
		GetRejectionReasonResult GetRejectionReason(long accountId, long adId);

		/// <inheritdoc cref="IAdsCategoryAsync.GetStatisticsAsync"/>
		ReadOnlyCollection<GetStatisticsResult> GetStatistics(GetStatisticsParams getStatisticsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetSuggestionsAsync"/>
		ReadOnlyCollection<GetSuggestionsResult> GetSuggestions(GetSuggestionsParams getSuggestionsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetTargetGroupsAsync"/>
		ReadOnlyCollection<GetTargetGroupsResult> GetTargetGroups(long accountId, long? clientId = null, bool? extended = null);

		/// <inheritdoc cref="IAdsCategoryAsync.GetTargetPixelsAsync"/>
		ReadOnlyCollection<GetTargetPixelsResult> GetTargetPixels(long accountId, long? clientId = null);

		/// <inheritdoc cref="IAdsCategoryAsync.GetTargetingStatsAsync"/>
		GetTargetingStatsResult GetTargetingStats(GetTargetingStatsParams getTargetingStatsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetUploadUrlAsync"/>
		Uri GetUploadUrl(GetUploadUrlParams getUploadUrlParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetVideoUploadUrlAsync"/>
		Uri GetVideoUploadUrl();

		/// <inheritdoc cref="IAdsCategoryAsync.ImportTargetContactsAsync"/>
		long ImportTargetContacts(ImportTargetContactsParams importTargetContactsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.RemoveOfficeUsersAsync"/>
		ReadOnlyCollection<bool> RemoveOfficeUsers(RemoveOfficeUsersParams removeOfficeUsersParams);

		/// <inheritdoc cref="IAdsCategoryAsync.RemoveTargetContactsAsync"/>
		RemoveTargetContactsResult RemoveTargetContacts(RemoveTargetContactsParams removeTargetContactsParams);

		/// <inheritdoc cref="IAdsCategoryAsync.SaveLookalikeRequestResultAsync"/>
		SaveLookALikeRequestResultResult SaveLookalikeRequestResult(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams);

		/// <inheritdoc cref="IAdsCategoryAsync.ShareTargetGroupAsync"/>
		ShareTargetGroupResult ShareTargetGroup(ShareTargetGroupParams shareTargetGroupParams);

		/// <inheritdoc cref="IAdsCategoryAsync.UpdateAdsAsync"/>
		ReadOnlyCollection<UpdateAdsResult> UpdateAds(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification);

		/// <inheritdoc cref="IAdsCategoryAsync.UpdateCampaignsAsync"/>
		ReadOnlyCollection<UpdateCampaignsResult> UpdateCampaigns(AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification);

		/// <inheritdoc cref="IAdsCategoryAsync.UpdateClientsAsync"/>
		ReadOnlyCollection<UpdateClientsResult> UpdateClients(AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification);

		/// <inheritdoc cref="IAdsCategoryAsync.UpdateTargetGroupAsync"/>
		bool UpdateTargetGroup(UpdateTargetGroupParams updateTargetGroupParams);

		/// <inheritdoc cref="IAdsCategoryAsync.UpdateTargetPixelAsync"/>
		bool UpdateTargetPixel(UpdateTargetPixelParams updateTargetPixelParams);

		/// <inheritdoc cref="IAdsCategoryAsync.GetMusiciansAsync"/>
		ReadOnlyCollection<GetMusiciansResult> GetMusicians(string artistName);

		/// <inheritdoc cref="IAdsCategoryAsync.GetMusiciansByIdsAsync"/>
		ReadOnlyCollection<GetMusiciansByIdsResult> GetMusiciansByIds(string ids);

		/// <inheritdoc cref="IAdsCategoryAsync.UpdateOfficeUsersAsync"/>
		ReadOnlyCollection<UpdateOfficeUsersResult> UpdateOfficeUsers(AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification);
	}
}