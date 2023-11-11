using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IAdsCategory" />
public partial class AdsCategory : IAdsCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk"> API. </param>
	public AdsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc/>
	public ReadOnlyCollection<bool> AddOfficeUsers(AdsDataSpecificationParams<UserSpecification> adsDataSpecification) =>
		_vk.Call<ReadOnlyCollection<bool>>("ads.addOfficeUsers",
			new()
			{
				{
					"account_id", adsDataSpecification.AccountId
				},
				{
					"data", JsonConvert.SerializeObject(adsDataSpecification.Data)
				}
			});

	/// <inheritdoc/>
	public LinkStatus CheckLink(CheckLinkParams checkLinkParams) => _vk.Call<LinkStatus>("ads.checkLink",
		new()
		{
			{
				"account_id", checkLinkParams.AccountId
			},
			{
				"link_type", checkLinkParams.LinkType
			},
			{
				"link_url", checkLinkParams.LinkUrl
			},
			{
				"campaign_id", checkLinkParams.CampaignId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<CreateAdsResult> CreateAds(AdsDataSpecificationParams<AdSpecification> adsDataSpecification) =>
		_vk.Call<ReadOnlyCollection<CreateAdsResult>>("ads.createAds",
			new()
			{
				{
					"account_id", adsDataSpecification.AccountId
				},
				{
					"data", JsonConvert.SerializeObject(adsDataSpecification.Data)
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<CreateCampaignResult> CreateCampaigns(
		AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification)
	{
		if (campaignsDataSpecification.Data.Length > 50)
		{
			throw new ArgumentOutOfRangeException(nameof(campaignsDataSpecification),
				"This method doesn't support more than 50 campaigns per call");
		}

		return _vk.Call<ReadOnlyCollection<CreateCampaignResult>>("ads.createCampaigns",
			new()
			{
				{
					"account_id", campaignsDataSpecification.AccountId
				},
				{
					"data", JsonConvert.SerializeObject(campaignsDataSpecification.Data)
				}
			});
	}

	/// <inheritdoc/>
	public ReadOnlyCollection<CreateClientResult> CreateClients(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification)
	{
		if (clientDataSpecification.Data.Length > 50)
		{
			throw new ArgumentOutOfRangeException(nameof(clientDataSpecification),
				"This method doesn't support more than 50 clients per call");
		}

		return _vk.Call<ReadOnlyCollection<CreateClientResult>>("ads.createClients",
			new()
			{
				{
					"account_id", clientDataSpecification.AccountId
				},
				{
					"data", JsonConvert.SerializeObject(clientDataSpecification.Data)
				}
			});
	}

	/// <inheritdoc/>
	public CreateLookALikeRequestResult CreateLookalikeRequest(CreateLookALikeRequestParams createLookALikeRequestParams) =>
		_vk.Call<CreateLookALikeRequestResult>("ads.createLookalikeRequest",
			new()
			{
				{
					"account_id", createLookALikeRequestParams.AccountId
				},
				{
					"source_type", createLookALikeRequestParams.SourceType
				},
				{
					"client_id", createLookALikeRequestParams.ClientId
				},
				{
					"retargeting_group_id", createLookALikeRequestParams.RetargetingGroupId
				}
			});

	/// <inheritdoc/>
	public CreateTargetGroupResult CreateTargetGroup(CreateTargetGroupParams createTargetGroupParams) => _vk.Call<CreateTargetGroupResult>(
		"ads.createTargetGroup",
		new()
		{
			{
				"account_id", createTargetGroupParams.AccountId
			},
			{
				"name", createTargetGroupParams.Name
			},
			{
				"client_id", createTargetGroupParams.ClientId
			},
			{
				"lifetime", createTargetGroupParams.Lifetime
			},
			{
				"target_pixel_id", createTargetGroupParams.TargetPixelId
			},
			{
				"target_pixel_rules", Utilities.SerializeToJson(createTargetGroupParams.TargetPixelRules)
			}
		});

	/// <inheritdoc/>
	public CreateTargetPixelResult CreateTargetPixel(CreateTargetPixelParams createTargetPixelParams) => _vk.Call<CreateTargetPixelResult>(
		"ads.createTargetPixel",
		new()
		{
			{
				"account_id", createTargetPixelParams.AccountId
			},
			{
				"client_id", createTargetPixelParams.ClientId
			},
			{
				"name", createTargetPixelParams.Name
			},
			{
				"domain", createTargetPixelParams.Domain
			},
			{
				"category_id", createTargetPixelParams.CategoryId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<bool> DeleteAds(DeleteAdsParams deleteAdsParams) => _vk.Call<ReadOnlyCollection<bool>>("ads.deleteAds", new()
	{
		{
			"account_id", deleteAdsParams.AccountId
		},
		{
			"ids", JsonConvert.SerializeObject(deleteAdsParams.Ids)
		}
	});

	/// <inheritdoc/>
	public ReadOnlyCollection<bool> DeleteCampaigns(DeleteCampaignsParams deleteCampaignsParams) => _vk.Call<ReadOnlyCollection<bool>>(
		"ads.deleteCampaigns",
		new()
		{
			{
				"account_id", deleteCampaignsParams.AccountId
			},
			{
				"ids", JsonConvert.SerializeObject(deleteCampaignsParams.Ids)
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<bool> DeleteClients(DeleteClientsParams deleteClientsParams) => _vk.Call<ReadOnlyCollection<bool>>(
		"ads.deleteClients",
		new()
		{
			{
				"account_id", deleteClientsParams.AccountId
			},
			{
				"ids", JsonConvert.SerializeObject(deleteClientsParams.Ids)
			}
		});

	/// <inheritdoc/>
	public bool DeleteTargetGroup(DeleteTargetGroupParams deleteTargetGroupParams) => _vk.Call<bool>("ads.deleteTargetGroup",
		new()
		{
			{
				"account_id", deleteTargetGroupParams.AccountId
			},
			{
				"target_group_id", deleteTargetGroupParams.TargetGroupId
			},
			{
				"client_id", deleteTargetGroupParams.ClientId
			}
		});

	/// <inheritdoc/>
	public bool DeleteTargetPixel(DeleteTargetPixelParams deleteTargetPixelParams) => _vk.Call<bool>("ads.deleteTargetPixel",
		new()
		{
			{
				"account_id", deleteTargetPixelParams.AccountId
			},
			{
				"client_id", deleteTargetPixelParams.ClientId
			},
			{
				"target_pixel_id", deleteTargetPixelParams.TargetPixelId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<AdsAccount> GetAccounts() => _vk.Call<ReadOnlyCollection<AdsAccount>>("ads.getAccounts", VkParameters.Empty);

	/// <inheritdoc/>
	public ReadOnlyCollection<Ad> GetAds(GetAdsParams getAdsParams) => _vk.Call<ReadOnlyCollection<Ad>>("ads.getAds",
		new()
		{
			{
				"account_id", getAdsParams.AccountId
			},
			{
				"campaign_ids", getAdsParams.CampaignIds is not null
					? "[" + string.Join(",", getAdsParams.CampaignIds) + "]"
					: null
			},
			{
				"ad_ids", getAdsParams.AdIds is not null
					? "[" + string.Join(",", getAdsParams.AdIds) + "]"
					: null
			},
			{
				"client_id", getAdsParams.ClientId
			},
			{
				"include_deleted", getAdsParams.IncludeDeleted
			},
			{
				"only_deleted", getAdsParams.OnlyDeleted
			},
			{
				"limit", getAdsParams.Limit
			},
			{
				"offset", getAdsParams.Offset
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<Layout> GetAdsLayout(GetAdsLayoutParams getAdsLayoutParams) => _vk.Call<ReadOnlyCollection<Layout>>(
		"ads.getAdsLayout",
		new()
		{
			{
				"account_id", getAdsLayoutParams.AccountId
			},
			{
				"campaign_ids", JsonConvert.SerializeObject(getAdsLayoutParams.CampaignIds)
			},
			{
				"ad_ids", JsonConvert.SerializeObject(getAdsLayoutParams.AdIds)
			},
			{
				"client_id", getAdsLayoutParams.ClientId
			},
			{
				"include_deleted", getAdsLayoutParams.IncludeDeleted
			},
			{
				"only_deleted", getAdsLayoutParams.OnlyDeleted
			},
			{
				"limit", getAdsLayoutParams.Limit
			},
			{
				"offset", getAdsLayoutParams.Offset
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<AdsTargetingResult> GetAdsTargeting(GetAdsTargetingParams getAdsTargetingParams) =>
		_vk.Call<ReadOnlyCollection<AdsTargetingResult>>("ads.getAdsTargeting",
			new()
			{
				{
					"account_id", getAdsTargetingParams.AccountId
				},
				{
					"campaign_ids", getAdsTargetingParams.CampaignIds
				},
				{
					"ad_ids", getAdsTargetingParams.AdIds
				},
				{
					"client_id", getAdsTargetingParams.ClientId
				},
				{
					"include_deleted", getAdsTargetingParams.IncludeDeleted
				},
				{
					"limit", getAdsTargetingParams.Limit
				},
				{
					"offset", getAdsTargetingParams.Offset
				}
			});

	/// <inheritdoc/>
	public double GetBudget(long accountId) => _vk.Call<double>("ads.getBudget", new()
	{
		{
			"account_id", accountId
		}
	});

	/// <inheritdoc/>
	public ReadOnlyCollection<AdsCampaign> GetCampaigns(AdsGetCampaignsParams adsGetCampaignsParams) =>
		_vk.Call<ReadOnlyCollection<AdsCampaign>>("ads.getCampaigns",
			new()
			{
				{
					"account_id", adsGetCampaignsParams.AccountId
				},
				{
					"client_id", adsGetCampaignsParams.ClientId
				},
				{
					"include_deleted", adsGetCampaignsParams.IncludeDeleted
				},
				{
					"campaign_ids", adsGetCampaignsParams.CampaignIds is not null
						? "[" + string.Join(",", adsGetCampaignsParams.CampaignIds) + "]"
						: null
				}
			});

	/// <inheritdoc/>
	public GetCategoriesResult GetCategories(Language lang) => _vk.Call<GetCategoriesResult>("ads.getCategories", new()
	{
		{
			"lang", lang
		}
	});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetClientsResult> GetClients(long accountId) => _vk.Call<ReadOnlyCollection<GetClientsResult>>(
		"ads.getClients", new()
		{
			{
				"account_id", accountId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetDemographicsResult> GetDemographics(GetDemographicsParams getDemographicsParams) =>
		_vk.Call<ReadOnlyCollection<GetDemographicsResult>>("ads.getDemographics",
			new()
			{
				{
					"account_id", getDemographicsParams.AccountId
				},
				{
					"ids_type", getDemographicsParams.IdsType
				},
				{
					"ids", getDemographicsParams.Ids
				},
				{
					"period", getDemographicsParams.Period
				},
				{
					"date_from", getDemographicsParams.DateFrom
				},
				{
					"date_to", getDemographicsParams.DateTo
				}
			});

	/// <inheritdoc/>
	public GetFloodStatsResult GetFloodStats(long accountId) => _vk.Call<GetFloodStatsResult>("ads.getFloodStats", new()
	{
		{
			"account_id", accountId
		}
	});

	/// <inheritdoc/>
	public GetLookalikeRequestsResult GetLookalikeRequests(GetLookalikeRequestsParams getLookalikeRequestsParams) =>
		_vk.Call<GetLookalikeRequestsResult>("ads.getLookalikeRequests",
			new()
			{
				{
					"account_id", getLookalikeRequestsParams.AccountId
				},
				{
					"requests_ids", getLookalikeRequestsParams.RequestsIds
				},
				{
					"sort_by", getLookalikeRequestsParams.SortBy
				},
				{
					"client_id", getLookalikeRequestsParams.ClientId
				},
				{
					"offset", getLookalikeRequestsParams.Offset
				},
				{
					"limit", getLookalikeRequestsParams.Limit
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetOfficeUsersResult> GetOfficeUsers(long accountId) => _vk.Call<ReadOnlyCollection<GetOfficeUsersResult>>(
		"ads.getOfficeUsers", new()
		{
			{
				"account_id", accountId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetPostsReachResult> GetPostsReach(long accountId, IdsType idsType, string ids) =>
		_vk.Call<ReadOnlyCollection<GetPostsReachResult>>("ads.getPostsReach",
			new()
			{
				{
					"account_id", accountId
				},
				{
					"ids_type", idsType
				},
				{
					"ids", ids
				}
			});

	/// <inheritdoc/>
	public GetRejectionReasonResult GetRejectionReason(long accountId, long adId) => _vk.Call<GetRejectionReasonResult>(
		"ads.getRejectionReason",
		new()
		{
			{
				"account_id", accountId
			},
			{
				"ad_id", adId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetStatisticsResult> GetStatistics(GetStatisticsParams getStatisticsParams) =>
		_vk.Call<ReadOnlyCollection<GetStatisticsResult>>("ads.getStatistics",
			new()
			{
				{
					"account_id", getStatisticsParams.AccountId
				},
				{
					"ids_type", getStatisticsParams.IdsType
				},
				{
					"ids", getStatisticsParams.Ids
				},
				{
					"period", getStatisticsParams.Period
				},
				{
					"date_from", getStatisticsParams.DateFrom
				},
				{
					"date_to", getStatisticsParams.DateTo
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetSuggestionsResult> GetSuggestions(GetSuggestionsParams getSuggestionsParams) =>
		_vk.Call<ReadOnlyCollection<GetSuggestionsResult>>("ads.getSuggestions",
			new()
			{
				{
					"section", getSuggestionsParams.Section
				},
				{
					"ids", getSuggestionsParams.Ids
				},
				{
					"q", getSuggestionsParams.Q
				},
				{
					"cities", getSuggestionsParams.Cities
				},
				{
					"lang", getSuggestionsParams.Lang
				},
				{
					"country", getSuggestionsParams.Country
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetTargetGroupsResult> GetTargetGroups(long accountId, long? clientId = null, bool? extended = null) =>
		_vk.Call<ReadOnlyCollection<GetTargetGroupsResult>>("ads.getTargetGroups",
			new()
			{
				{
					"account_id", accountId
				},
				{
					"client_id", clientId
				},
				{
					"extended", extended
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetTargetPixelsResult> GetTargetPixels(long accountId, long? clientId = null) =>
		_vk.Call<ReadOnlyCollection<GetTargetPixelsResult>>("ads.getTargetPixels",
			new()
			{
				{
					"account_id", accountId
				},
				{
					"client_id", clientId
				}
			});

	/// <inheritdoc/>
	public GetTargetingStatsResult GetTargetingStats(GetTargetingStatsParams getTargetingStatsParams) => _vk.Call<GetTargetingStatsResult>(
		"ads.getTargetingStats",
		new()
		{
			{
				"account_id", getTargetingStatsParams.AccountId
			},
			{
				"criteria", getTargetingStatsParams.Criteria
			},
			{
				"ad_platform", getTargetingStatsParams.AdPlatform
			},
			{
				"ad_platform_no_wall", getTargetingStatsParams.AdPlatformNoWall
			},
			{
				"link_url", getTargetingStatsParams.LinkUrl
			},
			{
				"link_domain", getTargetingStatsParams.LinkDomain
			},
			{
				"client_id", getTargetingStatsParams.ClientId
			},
			{
				"ad_id", getTargetingStatsParams.AdId
			},
			{
				"ad_format", getTargetingStatsParams.AdFormat
			}
		});

	/// <inheritdoc/>
	public Uri GetUploadUrl(GetUploadUrlParams getUploadUrlParams) => _vk.Call<Uri>("ads.getUploadUrl", new()
	{
		{
			"ad_format", getUploadUrlParams.AdFormat
		},
		{
			"icon", getUploadUrlParams.Icon
		}
	});

	/// <inheritdoc/>
	public Uri GetVideoUploadUrl() => _vk.Call<Uri>("ads.getVideoUploadUrl", VkParameters.Empty);

	/// <inheritdoc/>
	public long ImportTargetContacts(ImportTargetContactsParams importTargetContactsParams) => _vk.Call<long>("ads.importTargetContacts",
		new()
		{
			{
				"account_id", importTargetContactsParams.AccountId
			},
			{
				"target_group_id", importTargetContactsParams.TargetGroupId
			},
			{
				"contacts", importTargetContactsParams.Contacts
			},
			{
				"client_id", importTargetContactsParams.ClientId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<bool> RemoveOfficeUsers(RemoveOfficeUsersParams removeOfficeUsersParams) =>
		_vk.Call<ReadOnlyCollection<bool>>("ads.removeOfficeUsers",
			new()
			{
				{
					"account_id", removeOfficeUsersParams.AccountId
				},
				{
					"ids", JsonConvert.SerializeObject(removeOfficeUsersParams.Ids)
				}
			});

	/// <inheritdoc/>
	public RemoveTargetContactsResult RemoveTargetContacts(RemoveTargetContactsParams removeTargetContactsParams) =>
		_vk.Call<RemoveTargetContactsResult>("ads.removeTargetContacts",
			new()
			{
				{
					"account_id", removeTargetContactsParams.AccountId
				},
				{
					"target_group_id", removeTargetContactsParams.TargetGroupId
				},
				{
					"contacts", removeTargetContactsParams.Contacts
				},
				{
					"client_id", removeTargetContactsParams.ClientId
				}
			});

	/// <inheritdoc/>
	public SaveLookALikeRequestResultResult SaveLookalikeRequestResult(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams) =>
		_vk.Call<SaveLookALikeRequestResultResult>("ads.saveLookalikeRequestResult",
			new()
			{
				{
					"account_id", saveLookalikeRequestResultParams.AccountId
				},
				{
					"client_id", saveLookalikeRequestResultParams.ClientId
				},
				{
					"request_id", saveLookalikeRequestResultParams.RequestId
				},
				{
					"level", saveLookalikeRequestResultParams.Level
				}
			});

	/// <inheritdoc/>
	public ShareTargetGroupResult ShareTargetGroup(ShareTargetGroupParams shareTargetGroupParams) => _vk.Call<ShareTargetGroupResult>(
		"ads.shareTargetGroup",
		new()
		{
			{
				"account_id", shareTargetGroupParams.AccountId
			},
			{
				"target_group_id", shareTargetGroupParams.TargetGroupId
			},
			{
				"client_id", shareTargetGroupParams.ClientId
			},
			{
				"share_with_client_id", shareTargetGroupParams.ShareWithClientId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<UpdateAdsResult> UpdateAds(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification) =>
		_vk.Call<ReadOnlyCollection<UpdateAdsResult>>("ads.updateAds",
			new()
			{
				{
					"account_id", adEditDataSpecification.AccountId
				},
				{
					"data", adEditDataSpecification.Data
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<UpdateCampaignsResult> UpdateCampaigns(
		AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification) =>
		_vk.Call<ReadOnlyCollection<UpdateCampaignsResult>>("ads.updateCampaigns",
			new()
			{
				{
					"account_id", campaignModDataSpecification.AccountId
				},
				{
					"data", campaignModDataSpecification.Data
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<UpdateClientsResult> UpdateClients(
		AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification) => _vk.Call<ReadOnlyCollection<UpdateClientsResult>>(
		"ads.updateClients",
		new()
		{
			{
				"account_id", clientModDataSpecification.AccountId
			},
			{
				"data", clientModDataSpecification.Data
			}
		});

	/// <inheritdoc/>
	public bool UpdateTargetGroup(UpdateTargetGroupParams updateTargetGroupParams) => _vk.Call<bool>("ads.updateTargetGroup",
		new()
		{
			{
				"account_id", updateTargetGroupParams.AccountId
			},
			{
				"target_group_id", updateTargetGroupParams.TargetGroupId
			},
			{
				"name", updateTargetGroupParams.Name
			},
			{
				"domain", updateTargetGroupParams.Domain
			},
			{
				"client_id", updateTargetGroupParams.ClientId
			},
			{
				"lifetime", updateTargetGroupParams.Lifetime
			},
			{
				"target_pixel_id", updateTargetGroupParams.TargetPixelId
			},
			{
				"target_pixel_rules", Utilities.SerializeToJson(updateTargetGroupParams.TargetPixelRules)
			}
		});

	/// <inheritdoc/>
	public bool UpdateTargetPixel(UpdateTargetPixelParams updateTargetPixelParams) => _vk.Call<bool>("ads.updateTargetPixel",
		new()
		{
			{
				"account_id", updateTargetPixelParams.AccountId
			},
			{
				"target_pixel_id", updateTargetPixelParams.TargetPixelId
			},
			{
				"name", updateTargetPixelParams.Name
			},
			{
				"domain", updateTargetPixelParams.Domain
			},
			{
				"category_id", updateTargetPixelParams.CategoryId
			},
			{
				"client_id", updateTargetPixelParams.ClientId
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetMusiciansResult> GetMusicians(string artistName) => _vk.Call<ReadOnlyCollection<GetMusiciansResult>>(
		"ads.getMusicians",
		new()
		{
			{
				"artist_name", artistName
			}
		});

	/// <inheritdoc/>
	public ReadOnlyCollection<GetMusiciansByIdsResult> GetMusiciansByIds(string ids) =>
		_vk.Call<ReadOnlyCollection<GetMusiciansByIdsResult>>("ads.getMusiciansByIds",
			new()
			{
				{
					"ids", ids
				}
			});

	/// <inheritdoc/>
	public ReadOnlyCollection<UpdateOfficeUsersResult> UpdateOfficeUsers(
		AdsDataSpecificationParams<OfficeUsersSpecification> officeUsersSpecification) =>
		_vk.Call<ReadOnlyCollection<UpdateOfficeUsersResult>>("ads.updateOfficeUsers",
			new()
			{
				{
					"account_id", officeUsersSpecification.AccountId
				},
				{
					"data", officeUsersSpecification.Data
				}
			});
}