using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
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
		public ReadOnlyCollection<bool> AddOfficeUsers(AdsDataSpecification<UserSpecification> adsDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<bool>>("ads.addOfficeUsers",
				new VkParameters
				{
					{ "account_id", adsDataSpecification.AccountId },
					{ "data", JsonConvert.SerializeObject(adsDataSpecification.Data)}
				});
		}

		/// <inheritdoc/>
		public LinkStatus CheckLink(long accountId, AdsLinkType linkType, string linkUrl, long? campaignId = null)
		{
			return _vk.Call<LinkStatus>("ads.checkLink",
				new VkParameters
				{
					{ "account_id", accountId },
					{ "link_type", linkType },
					{ "link_url", linkUrl },
					{ "campaign_id", campaignId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<CreateAdsResult> CreateAds(AdsDataSpecification<AdSpecification> adsDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<CreateAdsResult>>("ads.createAds",
				new VkParameters
				{
					{ "account_id", adsDataSpecification.AccountId },
					{ "data", adsDataSpecification.Data }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<CreateCampaignResult> CreateCampaigns(AdsDataSpecification<CampaignSpecification> campaignDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<CreateCampaignResult>>("ads.createCampaigns",
				new VkParameters
				{
					{ "account_id", campaignDataSpecification.AccountId },
					{ "data", campaignDataSpecification.Data }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<CreateClientResult> CreateClients(AdsDataSpecification<ClientSpecification> clientDataSpecification)
		{
			return _vk.Call<ReadOnlyCollection<CreateClientResult>>("ads.createClients",
				new VkParameters
				{
					{ "account_id", clientDataSpecification.AccountId },
					{ "data", clientDataSpecification.Data }
				});
		}

		/// <inheritdoc/>
		public object CreateLookalikeRequest(long accountId, string sourceType, long? clientId = null, object retargetingGroupId = null)
		{
			return _vk.Call<object>("ads.createLookalikeRequest",
				new VkParameters
				{
					{ "account_id", accountId }, { "source_type", sourceType }, { "client_id", clientId },
					{ "retargeting_group_id", retargetingGroupId }
				});
		}

		/// <inheritdoc/>
		public object CreateTargetGroup(CreateTargetGroupParams createTargetGroupParams)
		{
			return _vk.Call<object>("ads.createTargetGroup",
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
		public object CreateTargetPixel(long accountId, string name, string domain, long categoryId, long? clientId = null)
		{
			return _vk.Call<object>("ads.createTargetPixel",
				new VkParameters
				{
					{ "account_id", accountId }, { "name", name }, { "domain", domain }, { "category_id", categoryId },
					{ "client_id", clientId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> DeleteAds(long accountId, string ids)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.deleteAds", new VkParameters { { "account_id", accountId }, { "ids", ids } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> DeleteCampaigns(long accountId, string ids)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.deleteCampaigns",
				new VkParameters { { "account_id", accountId }, { "ids", ids } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> DeleteClients(long accountId, string ids)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.deleteClients",
				new VkParameters { { "account_id", accountId }, { "ids", ids } });
		}

		/// <inheritdoc/>
		public bool DeleteTargetGroup(long accountId, long targetGroupId, long? clientId = null)
		{
			return _vk.Call<bool>("ads.deleteTargetGroup",
				new VkParameters { { "account_id", accountId }, { "target_group_id", targetGroupId }, { "client_id", clientId } });
		}

		/// <inheritdoc/>
		public bool DeleteTargetPixel(long accountId, long targetPixelId, long? clientId = null)
		{
			return _vk.Call<bool>("ads.deleteTargetPixel",
				new VkParameters { { "account_id", accountId }, { "target_pixel_id", targetPixelId }, { "client_id", clientId } });
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
		public ReadOnlyCollection<object> GetLookalikeRequests(GetLookalikeRequestsParams getLookalikeRequestsParams)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.getLookalikeRequests",
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
		public object ImportTargetContacts(long accountId, long targetGroupId, string contacts, long? clientId = null)
		{
			return _vk.Call<object>("ads.importTargetContacts",
				new VkParameters
				{
					{ "account_id", accountId }, { "target_group_id", targetGroupId }, { "contacts", contacts }, { "client_id", clientId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> RemoveOfficeUsers(long accountId, string ids)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.removeOfficeUsers",
				new VkParameters { { "account_id", accountId }, { "ids", ids } });
		}

		/// <inheritdoc/>
		public bool RemoveTargetContacts(long accountId, long targetGroupId, string contacts, long? clientId = null)
		{
			return _vk.Call<bool>("ads.removeTargetContacts",
				new VkParameters
				{
					{ "account_id", accountId }, { "target_group_id", targetGroupId }, { "contacts", contacts }, { "client_id", clientId }
				});
		}

		/// <inheritdoc/>
		public object SaveLookalikeRequestResult(long accountId, long requestId, long level, long? clientId = null)
		{
			return _vk.Call<object>("ads.saveLookalikeRequestResult",
				new VkParameters
					{ { "account_id", accountId }, { "request_id", requestId }, { "level", level }, { "client_id", clientId } });
		}

		/// <inheritdoc/>
		public object ShareTargetGroup(long accountId, long targetGroupId, long? clientId = null, long? shareWithClientId = null)
		{
			return _vk.Call<object>("ads.shareTargetGroup",
				new VkParameters
				{
					{ "account_id", accountId }, { "target_group_id", targetGroupId }, { "client_id", clientId },
					{ "share_with_client_id", shareWithClientId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> UpdateAds(long accountId, string data)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.updateAds",
				new VkParameters { { "account_id", accountId }, { "data", data } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> UpdateCampaigns(long accountId, string data)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.updateCampaigns",
				new VkParameters { { "account_id", accountId }, { "data", data } });
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<object> UpdateClients(long accountId, string data)
		{
			return _vk.Call<ReadOnlyCollection<object>>("ads.updateClients",
				new VkParameters { { "account_id", accountId }, { "data", data } });
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