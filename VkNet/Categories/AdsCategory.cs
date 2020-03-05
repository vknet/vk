using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class AdsCategory : IAdsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc/>
		/// <param name = "api">
		/// Api vk.com
		/// </param>
		public AdsCategory(IVkApiInvoke api)
		{
			_vk = api;
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<bool> AddOfficeUsers(AdsDataSpecificationParams<UserSpecification> adsDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<bool>>("ads.addOfficeUsers",
				new VkParameters
				{
					{ "account_id", adsDataSpecification.AccountId },
					{ "data", JsonConvert.SerializeObject(adsDataSpecification.Data)}
				});
		}

		/// <inheritdoc/>
		public LinkStatus CheckLink(CheckLinkParams checkLinkParams)
		{
			return _vk.Call<LinkStatus>("ads.checkLink",
				new VkParameters
				{
					{ "account_id", checkLinkParams.AccountId },
					{ "link_type", checkLinkParams.LinkType },
					{ "link_url", checkLinkParams.LinkUrl },
					{ "campaign_id", checkLinkParams.CampaignId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<CreateAdsResult> CreateAds(AdsDataSpecificationParams<AdSpecification> adsDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<CreateAdsResult>>("ads.createAds",
				new VkParameters
				{
					{ "account_id", adsDataSpecification.AccountId },
					{ "data", JsonConvert.SerializeObject(adsDataSpecification.Data) }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<CreateCampaignResult> CreateCampaigns(AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<CreateCampaignResult>>("ads.createCampaigns",
				new VkParameters
				{
					{ "account_id", campaignsDataSpecification.AccountId },
					{ "data", JsonConvert.SerializeObject(campaignsDataSpecification.Data) }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<CreateClientResult> CreateClients(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<CreateClientResult>>("ads.createClients",
				new VkParameters
				{
					{ "account_id", clientDataSpecification.AccountId },
					{ "data", JsonConvert.SerializeObject(clientDataSpecification.Data) }
				});
		}

		/// <inheritdoc/>
		public CreateLookALikeRequestResult CreateLookalikeRequest(CreateLookALikeRequestParams createLookALikeRequestParams)
		{
			return _vk.Call<CreateLookALikeRequestResult>("ads.createLookalikeRequest",
				new VkParameters
				{
					{ "account_id", createLookALikeRequestParams.AccountId }, { "source_type", createLookALikeRequestParams.SourceType }, { "client_id", createLookALikeRequestParams.ClientId },
					{ "retargeting_group_id", createLookALikeRequestParams.RetargetingGroupId }
				});
		}

		/// <inheritdoc/>
		public CreateTargetGroupResult CreateTargetGroup(CreateTargetGroupParams createTargetGroupParams)
		{
			return _vk.Call<CreateTargetGroupResult>("ads.createTargetGroup",
									new VkParameters
									{
										{ "account_id", createTargetGroupParams.AccountId },
										{ "name", createTargetGroupParams.Name },
										{ "client_id", createTargetGroupParams.ClientId },
										{ "lifetime", createTargetGroupParams.Lifetime },
										{ "target_pixel_id", createTargetGroupParams.TargetPixelId },
										{ "target_pixel_rules", Utilities.SerializeToJson(createTargetGroupParams.TargetPixelRules) }
									});
		}

		/// <inheritdoc/>
		public CreateTargetPixelResult CreateTargetPixel(CreateTargetPixelParams createTargetPixelParams)
		{
			return _vk.Call<CreateTargetPixelResult>("ads.createTargetPixel",
				new VkParameters
				{
					{ "account_id", createTargetPixelParams.AccountId }, { "name", createTargetPixelParams.Name },
					{ "domain", createTargetPixelParams.Domain }, { "category_id", createTargetPixelParams.CategoryId },
					{ "client_id", createTargetPixelParams.ClientId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<bool> DeleteAds(DeleteAdsParams deleteAdsParams)
		{
			return _vk.Call<ReadOnlyCollection<bool>>("ads.deleteAds", new VkParameters
			{
				{ "account_id", deleteAdsParams.AccountId }, { "ids", JsonConvert.SerializeObject(deleteAdsParams.Ids) }
			});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<bool> DeleteCampaigns(DeleteCampaignsParams deleteCampaignsParams)
		{
			return _vk.Call<ReadOnlyCollection<bool>>("ads.deleteCampaigns",
				new VkParameters
				{
					{ "account_id", deleteCampaignsParams.AccountId },
					{ "ids", JsonConvert.SerializeObject(deleteCampaignsParams.Ids)
					} });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<bool> DeleteClients(DeleteClientsParams deleteClientsParams)
		{
			return _vk.Call<ReadOnlyCollection<bool>>("ads.deleteClients",
				new VkParameters
				{
					{ "account_id", deleteClientsParams.AccountId }, { "ids", JsonConvert.SerializeObject(deleteClientsParams.Ids) }
				});
		}

		/// <inheritdoc/>
		public bool DeleteTargetGroup(DeleteTargetGroupParams deleteTargetGroupParams)
		{
			return _vk.Call<bool>("ads.deleteTargetGroup",
				new VkParameters
				{
					{ "account_id", deleteTargetGroupParams.AccountId }, { "target_group_id", deleteTargetGroupParams.TargetGroupId },
					{ "client_id", deleteTargetGroupParams.ClientId }
				});
		}

		/// <inheritdoc/>
		public bool DeleteTargetPixel(DeleteTargetPixelParams deleteTargetPixelParams)
		{
			return _vk.Call<bool>("ads.deleteTargetPixel",
				new VkParameters { { "account_id", deleteTargetPixelParams.AccountId }, { "target_pixel_id", deleteTargetPixelParams.TargetPixelId },
					{ "client_id", deleteTargetPixelParams.ClientId } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<AdsAccount> GetAccounts()
		{
			return _vk.Call<ReadOnlyCollection<AdsAccount>>("ads.getAccounts", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<Ad> GetAds(GetAdsParams getAdsParams)
		{
			return _vk.Call<ReadOnlyCollection<Ad>>("ads.getAds",
				new VkParameters
				{
					{ "account_id", getAdsParams.AccountId },
					{ "campaign_ids", getAdsParams.CampaignIds != null ? "[" + string.Join(",", getAdsParams.CampaignIds) + "]" : null },
					{ "ad_ids", getAdsParams.AdIds != null ? "[" + string.Join(",", getAdsParams.AdIds) + "]" : null },
					{ "client_id", getAdsParams.ClientId },
					{ "include_deleted", getAdsParams.IncludeDeleted },
					{ "limit", getAdsParams.Limit },
					{ "offset", getAdsParams.Offset }
				});
		}

		/// <inheritdoc/>
		public Uri GetAdsLayout(GetAdsLayoutParams getAdsLayoutParams)
		{
			return _vk.Call<Uri>("ads.getAdsLayout",
				new VkParameters
				{
					{ "account_id", getAdsLayoutParams.AccountId }, { "campaign_ids", getAdsLayoutParams.CampaignIds },
					{ "ad_ids", getAdsLayoutParams.AdIds }, { "client_id", getAdsLayoutParams.ClientId },
					{ "include_deleted", getAdsLayoutParams.IncludeDeleted }, { "limit", getAdsLayoutParams.Limit },
					{ "offset", getAdsLayoutParams.Offset }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetAdsTargeting(GetAdsTargetingParams getAdsTargetingParams)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getAdsTargeting",
				new VkParameters
				{
					{ "account_id", getAdsTargetingParams.AccountId }, { "campaign_ids", getAdsTargetingParams.CampaignIds },
					{ "ad_ids", getAdsTargetingParams.AdIds }, { "client_id", getAdsTargetingParams.ClientId },
					{ "include_deleted", getAdsTargetingParams.IncludeDeleted }, { "limit", getAdsTargetingParams.Limit },
					{ "offset", getAdsTargetingParams.Offset }
				});
		}

		/// <inheritdoc/>
		public object GetBudget(long accountId)
		{
			return _vk.Call<object>("ads.getBudget", new VkParameters { { "account_id", accountId } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<AdsCampaign> GetCampaigns(long accountId, IEnumerable<long> campaignIds, long? clientId = null,
															bool? includeDeleted = null)
		{
			return _vk.Call<ReadOnlyCollection<AdsCampaign>>("ads.getCampaigns",
				new VkParameters
				{
					{ "account_id", accountId }, { "campaign_ids", campaignIds }, { "client_id", clientId },
					{ "include_deleted", includeDeleted }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetCategories(string lang)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getCategories", new VkParameters { { "lang", lang } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetClients(long accountId)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getClients", new VkParameters { { "account_id", accountId } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetDemographics(GetDemographicsParams getDemographicsParams)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getDemographics",
				new VkParameters
				{
					{ "account_id", getDemographicsParams.AccountId }, { "ids_type", getDemographicsParams.IdsType },
					{ "ids", getDemographicsParams.Ids }, { "period", getDemographicsParams.Period },
					{ "date_from", getDemographicsParams.DateFrom }, { "date_to", getDemographicsParams.DateTo }
				});
		}

		/// <inheritdoc/>
		public object GetFloodStats(long accountId)
		{
			return _vk.Call<object>("ads.getFloodStats", new VkParameters { { "account_id", accountId } });
		}

		/// <inheritdoc/>
		public GetLookalikeRequestsResult GetLookalikeRequests(GetLookalikeRequestsParams getLookalikeRequestsParams)
		{
			return _vk.Call<GetLookalikeRequestsResult>("ads.getLookalikeRequests",
				new VkParameters
				{
					{ "account_id", getLookalikeRequestsParams.AccountId },
					{ "requests_ids", getLookalikeRequestsParams.RequestsIds },
					{ "sort_by", getLookalikeRequestsParams.SortBy },
					{ "client_id", getLookalikeRequestsParams.ClientId },
					{ "offset", getLookalikeRequestsParams.Offset },
					{ "limit", getLookalikeRequestsParams.Limit }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetOfficeUsers(long accountId)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getOfficeUsers", new VkParameters { { "account_id", accountId } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetPostsReach(long accountId, string idsType, string ids)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getPostsReach",
				new VkParameters { { "account_id", accountId }, { "ids_type", idsType }, { "ids", ids } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetRejectionReason(long accountId, long adId)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getRejectionReason",
				new VkParameters { { "account_id", accountId }, { "ad_id", adId } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetStatistics(GetStatisticsParams getStatisticsParams)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getStatistics",
				new VkParameters
				{
					{ "account_id", getStatisticsParams.AccountId }, { "ids_type", getStatisticsParams.IdsType },
					{ "ids", getStatisticsParams.Ids }, { "period", getStatisticsParams.Period },
					{ "date_from", getStatisticsParams.DateFrom }, { "date_to", getStatisticsParams.DateTo }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetSuggestions(GetSuggestionsParams getSuggestionsParams)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getSuggestions",
				new VkParameters
				{
					{ "section", getSuggestionsParams.Section }, { "ids", getSuggestionsParams.Ids }, { "q", getSuggestionsParams.Q },
					{ "cities", getSuggestionsParams.Cities }, { "lang", getSuggestionsParams.Lang },
					{ "country", getSuggestionsParams.Country }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetTargetGroups(long accountId, long? clientId = null, bool? extended = null)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getTargetGroups",
				new VkParameters { { "account_id", accountId }, { "client_id", clientId }, { "extended", extended } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> GetTargetPixels(long accountId, long? clientId = null)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getTargetPixels",
				new VkParameters { { "account_id", accountId }, { "client_id", clientId } });
		}

		/// <inheritdoc/>
		public object GetTargetingStats(GetTargetingStatsParams getTargetingStatsParams)
		{
			return _vk.Call<object>("ads.getTargetingStats",
				new VkParameters
				{
					{ "account_id", getTargetingStatsParams.AccountId }, { "criteria", getTargetingStatsParams.Criteria },
					{ "ad_platform", getTargetingStatsParams.AdPlatform },
					{ "ad_platform_no_wall", getTargetingStatsParams.AdPlatformNoWall }, { "link_url", getTargetingStatsParams.LinkUrl },
					{ "link_domain", getTargetingStatsParams.LinkDomain }, { "client_id", getTargetingStatsParams.ClientId },
					{ "ad_id", getTargetingStatsParams.AdId }, { "ad_format", getTargetingStatsParams.AdFormat }
				});
		}

		/// <inheritdoc/>
		public Uri GetUploadUrl(GetUploadUrlParams getUploadUrlParams)
		{
			return _vk.Call<Uri>("ads.getUploadUrl", new VkParameters
			{
				{ "ad_format", getUploadUrlParams.AdFormat},
				{ "icon", getUploadUrlParams.Icon }
			});
		}

		/// <inheritdoc/>
		public Uri GetVideoUploadUrl()
		{
			return _vk.Call<Uri>("ads.getVideoUploadUrl", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public long ImportTargetContacts(ImportTargetContactsParams importTargetContactsParams)
		{
			return _vk.Call<long>("ads.importTargetContacts",
				new VkParameters
				{
					{ "account_id", importTargetContactsParams.AccountId }, { "target_group_id", importTargetContactsParams.TargetGroupId },
					{ "contacts", importTargetContactsParams.Contacts }, { "client_id", importTargetContactsParams.ClientId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<bool> RemoveOfficeUsers(RemoveOfficeUsersParams removeOfficeUsersParams)
		{
			return _vk.Call<ReadOnlyCollection<bool>>("ads.removeOfficeUsers",
				new VkParameters { { "account_id", removeOfficeUsersParams.AccountId }, { "ids", JsonConvert.SerializeObject(removeOfficeUsersParams.Ids) } });
		}

		/// <inheritdoc/>
		public RemoveTargetContactsResult RemoveTargetContacts(RemoveTargetContactsParams removeTargetContactsParams)
		{
			return _vk.Call<RemoveTargetContactsResult>("ads.removeTargetContacts",
				new VkParameters
				{
					{ "account_id", removeTargetContactsParams.AccountId }, { "target_group_id", removeTargetContactsParams.TargetGroupId },
					{ "contacts", removeTargetContactsParams.Contacts }, { "client_id", removeTargetContactsParams.ClientId }
				});
		}

		/// <inheritdoc/>
		public SaveLookALikeRequestResultResult SaveLookalikeRequestResult(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams)
		{
			return _vk.Call<SaveLookALikeRequestResultResult>("ads.saveLookalikeRequestResult",
				new VkParameters
					{
						{ "account_id", saveLookalikeRequestResultParams.AccountId }, { "request_id", saveLookalikeRequestResultParams.RequestId },
						{ "level", saveLookalikeRequestResultParams.Level }, { "client_id", saveLookalikeRequestResultParams.ClientId }
					});
		}

		/// <inheritdoc/>
		public ShareTargetGroupResult ShareTargetGroup(ShareTargetGroupParams shareTargetGroupParams)
		{
			return _vk.Call<ShareTargetGroupResult>("ads.shareTargetGroup",
				new VkParameters
				{
					{ "account_id", shareTargetGroupParams.AccountId }, { "target_group_id", shareTargetGroupParams.TargetGroupId },
					{ "client_id", shareTargetGroupParams.ClientId}, { "share_with_client_id", shareTargetGroupParams.ShareWithClientId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<UpdateAdsResult> UpdateAds(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<UpdateAdsResult>>("ads.updateAds",
				new VkParameters { { "account_id", adEditDataSpecification.AccountId }, { "data", adEditDataSpecification.Data } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<UpdateCampaignsResult> UpdateCampaigns(AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<UpdateCampaignsResult>>("ads.updateCampaigns",
				new VkParameters { { "account_id", campaignModDataSpecification.AccountId }, { "data", campaignModDataSpecification.Data } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<UpdateClientsResult> UpdateClients(AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<UpdateClientsResult>>("ads.updateClients",
				new VkParameters { { "account_id", clientModDataSpecification.AccountId }, { "data", clientModDataSpecification.Data } });
		}

		/// <inheritdoc/>
		public bool UpdateTargetGroup(UpdateTargetGroupParams updateTargetGroupParams)
		{
			return _vk.Call<bool>("ads.updateTargetGroup",
								  new VkParameters
								  {
									  { "account_id", updateTargetGroupParams.AccountId },
									  { "target_group_id", updateTargetGroupParams.TargetGroupId },
									  { "name", updateTargetGroupParams.Name },
									  { "domain", updateTargetGroupParams.Domain },
									  { "client_id", updateTargetGroupParams.ClientId },
									  { "lifetime", updateTargetGroupParams.Lifetime },
									  { "target_pixel_id", updateTargetGroupParams.TargetPixelId },
									  { "target_pixel_rules", Utilities.SerializeToJson(updateTargetGroupParams.TargetPixelRules) }
								  });
		}

		/// <inheritdoc/>
		public bool UpdateTargetPixel(UpdateTargetPixelParams updateTargetPixelParams)
		{
			return _vk.Call<bool>("ads.updateTargetPixel",
				new VkParameters
				{
					{ "account_id", updateTargetPixelParams.AccountId }, { "target_pixel_id", updateTargetPixelParams.TargetPixelId },
					{ "name", updateTargetPixelParams.Name }, { "domain", updateTargetPixelParams.Domain },
					{ "category_id", updateTargetPixelParams.CategoryId }, { "client_id", updateTargetPixelParams.ClientId }
				});
		}
	}
}