using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Groups;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class GroupsCategory : IGroupsCategory
	{
		private readonly IVkInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk"> </param>
		public GroupsCategory(IVkInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public AddressResult AddAddress(AddAddressParams @params)
		{
			return _vk.Call<AddressResult>("groups.addAddress",
				new VkParameters
				{
					{ "group_id", @params.GroupId },
					{ "title", @params.Title },
					{ "address", @params.Address },
					{ "additional_address", @params.AdditionalAddress },
					{ "country_id", @params.CountryId },
					{ "city_id", @params.CityId },
					{ "latitude", @params.Latitude },
					{ "longitude", @params.Longitude },
					{ "phone", @params.Phone },
					{ "work_info_status", @params.WorkInfoStatus },
					{ "metro_id", @params.MetroId },
					{ "timetable", @params.Timetable },
					{ "is_main_address", @params.IsMainAddress }
				});
		}

		/// <inheritdoc />
		public AddressResult EditAddress(EditAddressParams @params)
		{
			return _vk.Call<AddressResult>("groups.editAddress",
				new VkParameters
				{
					{ "group_id", @params.GroupId },
					{ "address_id", @params.AddressId },
					{ "title", @params.Title },
					{ "address", @params.Address },
					{ "additional_address", @params.AdditionalAddress },
					{ "phone", @params.Phone },
					{ "work_info_status", @params.WorkInfoStatus },
					{ "country_id", @params.CountryId },
					{ "city_id", @params.CityId },
					{ "metro_id", @params.MetroId },
					{ "latitude", @params.Latitude },
					{ "longitude", @params.Longitude },
					{ "timetable", @params.Timetable },
					{ "is_main_address", @params.IsMainAddress }
				});
		}

		/// <inheritdoc />
		public bool DeleteAddress(ulong groupId, ulong addressId)
		{
			return _vk.Call<bool>("groups.deleteAddress",
				new VkParameters
				{
					{ "group_id", groupId },
					{ "address_id", addressId }
				});
		}

		/// <inheritdoc />
		public VkCollection<AddressResult> GetAddresses(GetAddressesParams @params)
		{
			return _vk.Call<VkCollection<AddressResult>>("groups.getAddresses",
				new VkParameters
				{
					{ "group_id", @params.GroupId },
					{ "fields", @params.Fields },
					{ "address_ids", @params.AddressIds },
					{ "latitude", @params.Latitude },
					{ "longitude", @params.Longitude },
					{ "offset", @params.Offset },
					{ "count", @params.Count }
				});
		}

		/// <inheritdoc />
		public bool Join(long? groupId, bool? notSure = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "not_sure", notSure }
			};

			return _vk.Call("groups.join", parameters);
		}

		/// <inheritdoc />
		public bool Leave(long groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			return _vk.Call("groups.leave", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Group> Get(GroupsGetParams @params, bool skipAuthorization = false)
		{
			VkErrors.ThrowIfNumberIsNegative(() => @params.UserId);

			var response = _vk.Call("groups.get",
				new VkParameters
				{
					{ "user_id", @params.UserId },
					{ "extended", @params.Extended },
					{ "filter", @params.Filter },
					{ "fields", @params.Fields },
					{ "offset", @params.Offset },
					{ "count", @params.Count }
				},
				skipAuthorization);

			// в первой записи количество членов группы для (response["items"])
			if (@params.Extended == null || !@params.Extended.Value)
			{
				return response.ToVkCollectionOf(id => new Group
				{
					Id = id
				});
			}

			return response.ToVkCollectionOf<Group>(r => r);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields,
												bool skipAuthorization = false)
		{
			var parameters = new VkParameters
			{
				{ "group_ids", groupIds },
				{ "group_id", groupId },
				{ "fields", fields }
			};

			return _vk.Call("groups.getById", parameters, skipAuthorization)
				.ToReadOnlyCollectionOf<Group>(x => x);
		}

		/// <inheritdoc />
		public VkCollection<User> GetMembers(GroupsGetMembersParams @params, bool skipAuthorization = false)
		{
			if (@params.Fields != null || @params.Filter != null)
			{
				return _vk.Call("groups.getMembers",
						new VkParameters
						{
							{ "group_id", @params.GroupId },
							{ "sort", @params.Sort },
							{ "offset", @params.Offset },
							{ "count", @params.Count },
							{ "fields", @params.Fields },
							{ "filter", @params.Filter }
						},
						skipAuthorization)
					.ToVkCollectionOf<User>(x => x);
			}

			return _vk.Call("groups.getMembers",
					new VkParameters
					{
						{ "group_id", @params.GroupId },
						{ "sort", @params.Sort },
						{ "offset", @params.Offset },
						{ "count", @params.Count },
						{ "fields", @params.Fields },
						{ "filter", @params.Filter }
					},
					skipAuthorization)
				.ToVkCollectionOf(x => new User
				{
					Id = x
				});
		}

		/// <inheritdoc />
		public ReadOnlyCollection<GroupMember> IsMember(string groupId, long? userId, IEnumerable<long> userIds, bool? extended,
														bool skipAuthorization = false)
		{
			if (userId.HasValue)
			{
				if (userIds != null)
				{
					var enumerable = userIds as long[] ?? userIds.ToArray();

					if (enumerable.Any(id => id < 1))
					{
						throw new ArgumentException("Идентификатор пользователя должен быть больше 0");
					}

					var tempList = enumerable.ToList();
					tempList.Add(userId.Value);
					userIds = tempList;
				} else
				{
					if (userId.Value < 1)
					{
						throw new ArgumentException("Идентификатор пользователя должен быть больше 0");
					}

					userIds = new List<long>
					{
						userId.Value
					};
				}
			}

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_ids", userIds },
				{ "extended", extended }
			};

			var result = _vk.Call("groups.isMember", parameters, skipAuthorization);

			return result.ToReadOnlyCollectionOf<GroupMember>(x => x);
		}

		/// <inheritdoc />
		public VkCollection<Group> Search(GroupsSearchParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("groups.search",
					new VkParameters
					{
						{ "q", @params.Query },
						{ "type", @params.Type },
						{ "country_id", @params.CountryId },
						{ "city_id", @params.CityId },
						{ "future", @params.Future },
						{ "market", @params.Market },
						{ "sort", @params.Sort },
						{ "offset", @params.Offset },
						{ "count", @params.Count }
					},
					skipAuthorization)
				.ToVkCollectionOf<Group>(r => r);
		}

		/// <inheritdoc />
		public VkCollection<Group> GetInvites(long? count, long? offset, bool? extended = null)
		{
			var parameters = new VkParameters
			{
				{ "offset", offset },
				{ "count", count },
				{ "extended", extended }
			};

			return _vk.Call("groups.getInvites", parameters).ToVkCollectionOf<Group>(x => x);
		}

		/// <inheritdoc />
		public bool BanUser(GroupsBanUserParams @params)
		{
			return _vk.Call("groups.banUser",
				new VkParameters
				{
					{ "group_id", @params.GroupId },
					{ "user_id", @params.UserId },
					{ "owner_id", @params.OwnerId },
					{ "end_date", @params.EndDate },
					{ "reason", @params.Reason },
					{ "comment", @params.Comment },
					{ "comment_visible", @params.CommentVisible }
				});
		}

		/// <inheritdoc />
		public VkCollection<GetBannedResult> GetBanned(long groupId, long? offset = null, long? count = null, GroupsFields fields = null,
														long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "owner_id", ownerId }
			};

			return _vk.Call<VkCollection<GetBannedResult>>("groups.getBanned", parameters);
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.UnbanUser, true)]
		public bool UnbanUser(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.unbanUser", parameters);
		}

		/// <inheritdoc />
		public bool Unban(long groupId, long userId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.unban", parameters);
		}

		/// <inheritdoc />
		public bool EditManager(GroupsEditManagerParams @params)
		{
			return _vk.Call("groups.editManager",
				new VkParameters
				{
					{ "group_id", @params.GroupId },
					{ "user_id", @params.UserId },
					{ "role", @params.Role },
					{ "is_contact", @params.IsContact },
					{ "contact_position", @params.ContactPosition },
					{ "contact_phone", @params.ContactPhone },
					{ "contact_email", @params.ContactEmail }
				});
		}

		/// <inheritdoc />
		public GroupsEditParams GetSettings(ulong groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			GroupsEditParams result = _vk.Call("groups.getSettings", parameters);
			result.GroupId = groupId; // Требует метод edit но getSettings не возвращает

			return result;
		}

		/// <inheritdoc />
		public bool Edit(GroupsEditParams @params)
		{
			Dictionary<string, object> market = new Dictionary<string, object>()
			{
				{ "enabled", @params.MarketEnabled }
			};

			if (@params.MarketCommentsEnabled.HasValue)
				market.Add("comments_enabled", @params.MarketCommentsEnabled);

			if (@params.MarketCountry != null)
				market.Add("country_ids", @params.MarketCountry);

			if (@params.MarketCity != null)
				market.Add("city_ids", @params.MarketCity);

			if (@params.MarketContact.HasValue)
				market.Add("contact_id", @params.MarketContact);

			if (@params.MarketCurrency.HasValue)
				market.Add("currency", @params.MarketCurrency);

			var parameters = new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "title", @params.Title },
				{ "description", @params.Description },
				{ "screen_name", @params.ScreenName },
				{ "access", @params.Access },
				{ "website", @params.Website },
				{ "subject", @params.Subject },
				{ "email", @params.Email },
				{ "phone", @params.Phone },
				{ "rss", @params.Rss },
				{ "event_start_date", @params.EventStartDate },
				{ "event_finish_date", @params.EventFinishDate },
				{ "event_group_id", @params.EventGroupId },
				{ "public_category", @params.PublicCategory },
				{ "public_subcategory", @params.PublicSubcategory },
				{ "public_date", @params.PublicDate },
				{ "wall", @params.Wall },
				{ "topics", @params.Topics },
				{ "photos", @params.Photos },
				{ "video", @params.Video },
				{ "audio", @params.Audio },
				{ "links", @params.Links },
				{ "events", @params.Events },
				{ "places", @params.Places },
				{ "contacts", @params.Contacts },
				{ "docs", @params.Docs },
				{ "wiki", @params.Wiki },
				{ "messages", @params.Messages },
				{ "age_limits", @params.AgeLimits },
				{ "market", market },
				{ "market_wiki", @params.MarketWiki },
				{ "obscene_filter", @params.ObsceneFilter },
				{ "obscene_stopwords", @params.ObsceneStopwords },
				{ "obscene_words", @params.ObsceneWords },
				{ "articles", @params.Articles },
				{ "addresses", @params.Addresses },
				{ "main_section", @params.MainSection },
				{ "secondary_section", @params.SecondarySection },
				{ "country", @params.Country },
				{ "city", @params.City }
			};

			return _vk.Call("groups.edit", parameters);
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public bool EditPlace(long groupId, Place place = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			if (place == null)
			{
				place = new Place();
			}

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "title", place.Title },
				{ "address", place.Address },
				{ "country_id", place.CountryId },
				{ "city_id", place.CityId },
				{ "latitude", place.Latitude },
				{ "longitude", place.Longitude }
			};

			var result = _vk.Call("groups.editPlace", parameters);

			return result["success"];
		}

		/// <inheritdoc />
		public VkCollection<User> GetInvitedUsers(long groupId, long? offset = null, long? count = null, UsersFields fields = null,
												NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			return _vk.Call("groups.getInvitedUsers", parameters).ToVkCollectionOf<User>(x => x);
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public bool Invite(long groupId, long userId, long? captchaSid = null, string captchaKey = null)
		{
			return Invite(groupId, userId);
		}

		/// <inheritdoc />
		public bool Invite(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.invite", parameters);
		}

		/// <inheritdoc />
		public ExternalLink AddLink(long groupId, Uri link, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link", link },
				{ "text", text }
			};

			return _vk.Call("groups.addLink", parameters);
		}

		/// <inheritdoc />
		public bool DeleteLink(long groupId, ulong linkId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId }
			};

			return _vk.Call("groups.deleteLink", parameters);
		}

		/// <inheritdoc />
		public bool EditLink(long groupId, ulong linkId, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId },
				{ "text", text }
			};

			return _vk.Call("groups.editLink", parameters);
		}

		/// <inheritdoc />
		public bool ReorderLink(long groupId, long linkId, long? after)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId },
				{ "after", after }
			};

			return _vk.Call("groups.reorderLink", parameters);
		}

		/// <inheritdoc />
		public bool RemoveUser(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.removeUser", parameters);
		}

		/// <inheritdoc />
		public bool ApproveRequest(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.approveRequest", parameters);
		}

		/// <inheritdoc />
		public Group Create(string title, string description = null, GroupType type = null, GroupSubType? subtype = null,
							uint? publicCategory = null)
		{
			var parameters = new VkParameters
			{
				{ "title", title },
				{ "description", description },
				{ "type", type },
				{ "subtype", subtype }
			};

			return _vk.Call("groups.create", parameters);
		}

		/// <inheritdoc />
		public VkCollection<User> GetRequests(long groupId, long? offset = null, long? count = null, UsersFields fields = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields }
			};

			var response = _vk.Call("groups.getRequests", parameters);

			return fields == null
				? response.ToVkCollectionOf<User>(x => new User()
				{
					Id = (long) x
				})
				: response.ToVkCollectionOf<User>(x => x);
		}

		/// <inheritdoc />
		public VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			var parameters = new VkParameters
			{
				{ "category_id", categoryId },
				{ "subcategory_id", subcategoryId }
			};

			return _vk.Call("groups.getCatalog", parameters, true)
				.ToVkCollectionOf<Group>(x => x);
		}

		/// <inheritdoc />
		public GroupsCatalogInfo GetCatalogInfo(bool? extended = null, bool? subcategories = null)
		{
			var parameters = new VkParameters
			{
				{ "extended", extended },
				{ "subcategories", subcategories }
			};

			return _vk.Call("groups.getCatalogInfo", parameters, true);
		}

		/// <inheritdoc />
		public long AddCallbackServer(ulong groupId, string url, string title, string secretKey)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "url", url },
				{ "title", title },
				{ "secret_key", secretKey }
			};

			return _vk.Call("groups.addCallbackServer", parameters)["server_id"];
		}

		/// <inheritdoc />
		public bool DeleteCallbackServer(ulong groupId, ulong serverId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_id", serverId }
			};

			return _vk.Call("groups.deleteCallbackServer", parameters);
		}

		/// <inheritdoc />
		public bool EditCallbackServer(ulong groupId, ulong serverId, string url, string title, string secretKey)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_id", serverId },
				{ "url", url },
				{ "title", title },
				{ "secret_key", secretKey }
			};

			return _vk.Call("groups.editCallbackServer", parameters);
		}

		/// <inheritdoc />
		public string GetCallbackConfirmationCode(ulong groupId)
		{
			var response = _vk.Call("groups.getCallbackConfirmationCode",
				new VkParameters
				{
					{ "group_id", groupId }
				});

			return response["code"];
		}

		/// <inheritdoc />
		public VkCollection<CallbackServerItem> GetCallbackServers(ulong groupId, IEnumerable<ulong> serverIds = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_ids", serverIds }
			};

			return _vk.Call("groups.getCallbackServers", parameters)
				.ToVkCollectionOf<CallbackServerItem>(x => x);
		}

		/// <inheritdoc />
		public CallbackSettings GetCallbackSettings(ulong groupId, ulong serverId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "server_id", serverId }
			};

			return _vk.Call("groups.getCallbackSettings", parameters);
		}

		/// <inheritdoc />
		public bool SetCallbackSettings(CallbackServerParams @params)
		{
			VkParameters res = new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "server_id", @params.ServerId },
			};

			if (@params.CallbackSettings != null)
			{
				var props = @params.CallbackSettings.GetType().GetProperties();

				foreach (var t in props)
				{
					if (!(t.GetCustomAttributes(typeof(JsonPropertyAttribute), true).FirstOrDefault() is JsonPropertyAttribute jsonAttr))
					{
						continue;
					}

					if (t.GetValue(@params.CallbackSettings, null) is bool propVal)
					{
						res.Add(jsonAttr.PropertyName, propVal);
					}
				}
			}

			if (@params.ApiVersion != null)
			{
				res["api_version"] = @params.ApiVersion.Version;
			}

			return _vk.Call("groups.setCallbackSettings", res);
		}

		/// <inheritdoc />
		public LongPollServerResponse GetLongPollServer(ulong groupId)
		{
			return _vk.Call<LongPollServerResponse>("groups.getLongPollServer",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public bool DisableOnline(ulong groupId)
		{
			return _vk.Call<bool>("groups.disableOnline",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public bool EnableOnline(ulong groupId)
		{
			return _vk.Call<bool>("groups.enableOnline",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public BotsLongPollHistoryResponse GetBotsLongPollHistory(BotsLongPollHistoryParams @params)
		{
			return _vk.CallLongPoll(@params.Server,
				new VkParameters
				{
					{ "ts", @params.Ts },
					{ "key", @params.Key },
					{ "wait", @params.Wait },
					{ "act", "a_check" }
				});
		}

		/// <inheritdoc />
		public OnlineStatus GetOnlineStatus(ulong groupId)
		{
			return _vk.Call<OnlineStatus>("groups.getOnlineStatus",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public TokenPermissionsResult GetTokenPermissions()
		{
			return _vk.Call<TokenPermissionsResult>("groups.getTokenPermissions", VkParameters.Empty);
		}

		/// <inheritdoc />
		public bool SetLongPollSettings(SetLongPollSettingsParams @params)
		{
			return _vk.Call<bool>("groups.setLongPollSettings",
				new VkParameters
				{
					{ "group_id", @params.GroupId },
					{ "api_version", @params.ApiVersion },
					{ "enabled", @params.Enabled },
					{ "message_new", @params.MessageNew },
					{ "message_reply", @params.MessageReply },
					{ "message_allow", @params.MessageAllow },
					{ "message_deny", @params.MessageDeny },
					{ "message_edit", @params.MessageEdit },
					{ "message_typing_state", @params.MessageTypingState },
					{ "photo_new", @params.PhotoNew },
					{ "audio_new", @params.AudioNew },
					{ "video_new", @params.VideoNew },
					{ "wall_reply_new", @params.WallReplyNew },
					{ "wall_reply_edit", @params.WallReplyEdit },
					{ "wall_reply_delete", @params.WallReplyDelete },
					{ "wall_reply_restore", @params.WallReplyRestore },
					{ "wall_post_new", @params.WallPostNew },
					{ "wall_repost", @params.WallRepost },
					{ "board_post_new", @params.BoardPostNew },
					{ "board_post_edit", @params.BoardPostEdit },
					{ "board_post_restore", @params.BoardPostRestore },
					{ "board_post_delete", @params.BoardPostDelete },
					{ "photo_comment_new", @params.PhotoCommentNew },
					{ "photo_comment_edit", @params.PhotoCommentEdit },
					{ "photo_comment_delete", @params.PhotoCommentDelete },
					{ "photo_comment_restore", @params.PhotoCommentRestore },
					{ "video_comment_new", @params.VideoCommentNew },
					{ "video_comment_edit", @params.VideoCommentEdit },
					{ "video_comment_delete", @params.VideoCommentDelete },
					{ "video_comment_restore", @params.VideoCommentRestore },
					{ "market_comment_new", @params.MarketCommentNew },
					{ "market_comment_edit", @params.MarketCommentEdit },
					{ "market_comment_delete", @params.MarketCommentDelete },
					{ "market_comment_restore", @params.MarketCommentRestore },
					{ "poll_vote_new", @params.PollVoteNew },
					{ "group_join", @params.GroupJoin },
					{ "group_leave", @params.GroupLeave },
					{ "group_change_settings", @params.GroupChangeSettings },
					{ "group_change_photo", @params.GroupChangePhoto },
					{ "group_officers_edit", @params.GroupOfficersEdit },
					{ "user_block", @params.UserBlock },
					{ "user_unblock", @params.UserUnblock }
				});
		}

		/// <inheritdoc />
		public GetLongPollSettingsResult GetLongPollSettings(ulong groupId)
		{
			return _vk.Call<GetLongPollSettingsResult>("groups.getLongPollSettings",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}
	}
}