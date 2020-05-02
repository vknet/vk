using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class FriendsCategory : IFriendsCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk"> </param>
		public FriendsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<User> Get(FriendsGetParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("friends.get", new VkParameters
				{
					{ "user_id", @params.UserId },
					{ "order", @params.Order },
					{ "list_id", @params.ListId },
					{ "count", @params.Count },
					{ "offset", @params.Offset },
					{ "fields", @params.Fields },
					{ "name_case", @params.NameCase },
					{ "ref", @params.Reference }
				}, skipAuthorization)
				.ToVkCollectionOf(x => @params.Fields != null
					? x
					: new User
					{
						Id = x
					});
		}

		/// <inheritdoc />
		[Pure]
		public ReadOnlyCollection<long> GetAppUsers()
		{
			VkResponseArray response = _vk.Call("friends.getAppUsers", VkParameters.Empty);

			return response.ToReadOnlyCollectionOf<long>(x => x);
		}

		/// <inheritdoc />
		public FriendOnline GetOnline(FriendsGetOnlineParams @params)
		{
			var result = _vk.Call("friends.getOnline", new VkParameters
			{
				{ "user_id", @params.UserId }
				, { "list_id", @params.ListId }
				, { "online_mobile", @params.OnlineMobile }
				, { "order", @params.Order }
				, { "count", @params.Count }
				, { "offset", @params.Offset }
			});

			return FriendOnline.FromJson(result);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<MutualFriend> GetMutual(FriendsGetMutualParams @params)
		{
			if (@params.TargetUid.HasValue)
			{
				@params.TargetUids = new[] { @params.TargetUid.Value };
			}

			VkResponseArray response = _vk.Call("friends.getMutual", new VkParameters
			{
				{ "source_uid", @params.SourceUid },
				{ "target_uids", @params.TargetUids },
				{ "order", @params.Order },
				{ "count", @params.Count },
				{ "offset", @params.Offset }
			});

			return response.ToReadOnlyCollectionOf<MutualFriend>(x => x);
		}

		/// <inheritdoc />
		[Pure]
		public ReadOnlyCollection<AreFriendsResult> AreFriends(IEnumerable<long> userIds, bool? needSign = null)
		{
			if (userIds == null)
			{
				throw new ArgumentNullException(nameof(userIds));
			}

			var parameters = new VkParameters
			{
				{ "user_ids", userIds },
				{ "need_sign", needSign }
			};

			return _vk.Call("friends.areFriends", parameters)
				.ToReadOnlyCollectionOf<AreFriendsResult>(x => x);
		}

		/// <inheritdoc />
		public long AddList(string name, IEnumerable<long> userIds)
		{
			VkErrors.ThrowIfNullOrEmpty(() => name);

			var parameters = new VkParameters
			{
				{ "name", name },
				{ "user_ids", userIds }
			};

			var response = _vk.Call("friends.addList", parameters);

			return response["list_id"];
		}

		/// <inheritdoc />
		public bool DeleteList(long listId)
		{
			var parameters = new VkParameters
			{
				{ "list_id", listId }
			};

			return _vk.Call("friends.deleteList", parameters);
		}

		/// <inheritdoc />
		public VkCollection<FriendList> GetLists(long? userId = null, bool? returnSystem = null)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "return_system", returnSystem }
			};

			return _vk.Call("friends.getLists", parameters).ToVkCollectionOf<FriendList>(x => x);
		}

		/// <inheritdoc />
		public bool EditList(long listId, string name = null, IEnumerable<long> userIds = null, IEnumerable<long> addUserIds = null,
							IEnumerable<long> deleteUserIds = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => listId);

			var parameters = new VkParameters
			{
				{ "name", name },
				{ "list_id", listId },
				{ "user_ids", userIds },
				{ "add_user_ids", addUserIds },
				{ "delete_user_ids", deleteUserIds }
			};

			return _vk.Call("friends.editList", parameters);
		}

		/// <inheritdoc />
		public bool DeleteAllRequests()
		{
			return _vk.Call("friends.deleteAllRequests", VkParameters.Empty);
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public AddFriendStatus Add(long userId, string text = "", bool? follow = null, long? captchaSid = null, string captchaKey = null)
		{
			return Add(userId, text, follow);
		}

		/// <inheritdoc />
		public AddFriendStatus Add(long userId, string text = "", bool? follow = null)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "text", text },
				{ "follow", follow }
			};

			return _vk.Call("friends.add", parameters);
		}

		/// <inheritdoc />
		public FriendsDeleteResult Delete(long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "user_id", userId }
			};

			return _vk.Call("friends.delete", parameters);
		}

		/// <inheritdoc />
		public bool Edit(long userId, IEnumerable<long> listIds)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "list_ids", listIds }
			};

			return _vk.Call("friends.edit", parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<long> GetRecent(long? count = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);

			var parameters = new VkParameters
			{
				{ "count", count }
			};

			VkResponseArray response = _vk.Call("friends.getRecent", parameters);

			return response.ToReadOnlyCollectionOf<long>(x => x);
		}

		/// <inheritdoc />
		public GetRequestsResult GetRequests(FriendsGetRequestsParams @params)
		{
			return _vk.Call<GetRequestsResult>("friends.getRequests", new VkParameters
			{
				{ "offset", @params.Offset }
				, { "count", @params.Count }
				, { "extended", @params.Extended }
				, { "need_mutual", @params.NeedMutual }
				, { "out", @params.Out }
				, { "sort", @params.Sort }
				, { "suggested", @params.Suggested }
				, { "need_viewed", @params.NeedViewed }
			});
		}

		/// <inheritdoc />
		public VkCollection<FriendsGetRequestsResult> GetRequestsExtended(FriendsGetRequestsParams @params)
		{
			@params.Extended = true;

			return _vk.Call<VkCollection<FriendsGetRequestsResult>>("friends.getRequests", new VkParameters
			{
				{ "offset", @params.Offset }
				, { "count", @params.Count }
				, { "extended", @params.Extended }
				, { "need_mutual", @params.NeedMutual }
				, { "out", @params.Out }
				, { "sort", @params.Sort }
				, { "suggested", @params.Suggested }
				, { "need_viewed", @params.NeedViewed }
			});
		}

		/// <inheritdoc />
		public VkCollection<User> GetSuggestions(FriendsFilter filter = null, long? count = null, long? offset = null,
												UsersFields fields = null, NameCase nameCase = null)
		{
			var parameters = new VkParameters
			{
				{ "filter", filter },
				{ "count", count },
				{ "offset", offset },
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			return _vk.Call("friends.getSuggestions", parameters).ToVkCollectionOf<User>(x => x);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<User> GetByPhones(IEnumerable<string> phones, ProfileFields fields)
		{
			var parameters = new VkParameters
			{
				{ "phones", phones },
				{ "fields", fields }
			};

			return _vk.Call("friends.getByPhones", parameters).ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <inheritdoc />
		public VkCollection<User> Search(FriendsSearchParams @params)
		{
			return _vk.Call("friends.search", new VkParameters
			{
				{ "user_id", @params.UserId }
				, { "q", @params.Query }
				, { "fields", @params.Fields }
				, { "name_case", @params.NameCase }
				, { "offset", @params.Offset }
				, { "count", @params.Count }
			}).ToVkCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Создает новый список друзей у текущего пользователя.
		/// </summary>
		/// <param name="name"> Название создаваемого списка друзей. </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного списка
		/// друзей.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Friends
		/// Страница документации ВКонтакте http://vk.com/dev/friends.addList
		/// </remarks>
		[Obsolete(ObsoleteText.FriendsAddList)]
		public long AddList(string name)
		{
			return AddList(name, Enumerable.Empty<long>());
		}

		/// <summary>
		/// Позволяет получить список идентификаторов пользователей, доступных для вызова в
		/// приложении, используя метод JSAPI
		/// callUser.
		/// Подробнее о схеме вызова из приложений.
		/// </summary>
		/// <param name="fields">
		/// Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: nickname, domain, sex, bdate, city, country, timezone,
		/// photo_50, photo_100, photo_200_orig,
		/// has_mobile, contacts, education, online, relation, last_seen, status,
		/// can_write_private_message, can_see_all_posts,
		/// can_post, universities список строк, разделенных через запятую (Список строк,
		/// разделенных через запятую).
		/// </param>
		/// <param name="nameCase">
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom,
		/// родительный – gen, дательный – dat, винительный – acc, творительный – ins,
		/// предложный – abl. По умолчанию nom.
		/// строка, по умолчанию Nom (Строка, по умолчанию Nom).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список идентификаторов (id) друзей
		/// пользователя, доступных для вызова, если
		/// параметр fields не использовался.
		/// При использовании параметра fields  возвращает список объектов пользователей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/friends.getAvailableForCall
		/// </remarks>
		[Obsolete(ObsoleteText.Obsolete)]
		public VkCollection<User> GetAvailableForCall(ProfileFields fields, NameCase nameCase)
		{
			var parameters = new VkParameters
			{
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			return _vk.Call("friends.getAvailableForCall", parameters)
				.ToVkCollectionOf(x => fields != null
					? new User
					{
						Id = x
					}
					: x);
		}
	}
}