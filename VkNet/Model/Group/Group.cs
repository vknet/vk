using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о сообществе (группе).
	/// См. описание http://vk.com/dev/fields_groups
	/// </summary>
	[DebuggerDisplay("[{Id}] {Name}")]
	[Serializable]
	public class Group : IVkModel
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public Group()
		{
			Type = new GroupType();
		}

		/// <summary>
		/// Преобразовать из JSON
		/// </summary>
		/// <param name="response"> Ответ от сервера. </param>
		/// <returns> </returns>
		IVkModel IVkModel.FromJson(VkResponse response)
		{
			return FromJson(response);
		}

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Group FromJson(VkResponse response)
		{
			var group = new Group
			{
				Id = response["group_id"] ?? response["gid"] ?? response["id"],
				Name = response["name"],
				ScreenName = response["screen_name"],
				IsClosed = response["is_closed"],
				IsAdmin = response["is_admin"],
				AdminLevel = response["admin_level"],
				IsMember = response["is_member"],
				IsAdvertiser = response["is_advertiser"],
				Type = response["type"],
				PhotoPreviews = response,
				Deactivated = response["deactivated"],
				HasPhoto = response["has_photo"],
				Photo50 = response["photo_50"],
				Photo100 = response["photo_100"],
				Photo200 = response["photo_200"],

				// опциональные поля
				City = response["city"],
				Country = response["country"],
				Place = response["place"],
				Description = response["description"],
				WikiPage = response["wiki_page"],
				MembersCount = response["members_count"],
				Counters = response["counters"],
				StartDate = response["start_date"],
				EndDate = response["finish_date"] ?? response["end_date"],
				CanPost = response["can_post"],
				CanSeeAllPosts = response["can_see_all_posts"],
				CanUploadDocuments = response["can_upload_doc"],
				CanCreateTopic = response["can_create_topic"],
				Activity = response["activity"],
				Status = response["status"],
				StatusAudio = response["status_audio"],
				Contacts = response["contacts"].ToReadOnlyCollectionOf<Contact>(x => x),
				Links = response["links"].ToReadOnlyCollectionOf<ExternalLink>(x => x),
				FixedPost = response["fixed_post"],
				Verified = response["verified"],
				Site = response["site"],
				InvitedBy = response["invited_by"],
				IsFavorite = response["is_favorite"],
				BanInfo = response["ban_info"],
				CanUploadVideo = response["can_upload_video"],
				MainAlbumId = response["main_album_id"],
				IsHiddenFromFeed = response["is_hidden_from_feed"],
				MainSection = response["main_section"],
				IsMessagesAllowed = response["is_messages_allowed"],
				Trending = response["trending"],
				CanMessage = response["can_message"],
				Cover = response["cover"],
				Market = response["market"],
				AgeLimits = response["age_limits"],
				MemberStatus = response["member_status"],
				PublicDateLabel = response["public_date_label"],
				Wall = response["wall"]
			};

			return group;
		}

	#endregion

	#region Стандартные поля

		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Название сообщества.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Короткий адрес страницы сообщества, например, <c>apiclub</c>. Если он не назначен, то
		/// <c>'club'+gid</c>, например, <c>club35828305</c>.
		/// </summary>
		[JsonProperty("screen_name")]
		public string ScreenName { get; set; }

		/// <summary>
		/// Публичность группы.
		/// </summary>
		[JsonProperty("is_closed")]
		public GroupPublicity? IsClosed { get; set; }

		/// <summary>
		/// Возвращается в случае, если сообщество удалено или заблокировано
		/// </summary>
		[JsonProperty("deactivated")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public Deactivated Deactivated { get; set; }

		/// <summary>
		/// Информация о том, является ли текущий пользователь руководителем сообщества.
		/// </summary>
		[JsonProperty("is_admin")]
		public bool IsAdmin { get; set; }

		/// <summary>
		/// Уровень административных полномочий текущего пользователя в сообществе
		/// (действительно, если <c>IsAdmin = true</c>).
		/// </summary>
		[JsonProperty("admin_level")]
		public AdminLevel? AdminLevel { get; set; }

		/// <summary>
		/// Информация о том, является ли текущий пользователь участником сообщества.
		/// </summary>
		[JsonProperty("is_member")]
		public bool? IsMember { get; set; }

		/// <summary>
		/// Идентификатор пользователя пригласившего в группу
		/// </summary>
		[JsonProperty("invited_by")]
		public long? InvitedBy { get; set; }

		/// <summary>
		/// Тип сообщества.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public GroupType Type { get; set; }

		/// <summary>
		/// <c>Uri</c> фотографии сообщества с размером 50x50px
		/// </summary>
		[JsonProperty("photo_50")]
		public Uri Photo50 { get; set; }

		/// <summary>
		/// <c>Uri</c> фотографии сообщества с размером 100x100px
		/// </summary>
		[JsonProperty("photo_100")]
		public Uri Photo100 { get; set; }

		/// <summary>
		/// <c>Uri</c> фотографии сообщества с размером 200x200px
		/// </summary>
		[JsonProperty("photo_200")]
		public Uri Photo200 { get; set; }

	#endregion

	#region Опциональные поля

		/// <summary>
		/// Строка состояния публичной страницы. У групп возвращается строковое значение,
		/// открыта ли группа или нет,
		/// а у событий дата начала.
		/// </summary>
		[JsonProperty("activity")]
		public string Activity { get; set; }

		/// <summary>
		/// Возрастное ограничение
		/// </summary>
		[JsonProperty("age_limits")]
		public AgeLimit AgeLimits { get; set; }

		/// <summary>
		/// Информация о забанненом (добавленном в черный список) пользователе сообщества.
		/// </summary>
		[JsonProperty("ban_info")]
		public BanInfo BanInfo { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь создать тему обсуждения в
		/// группе.
		/// (<c> true </c>, если пользователь может создать обсуждение, <c> false </c> –
		/// если не может).
		/// </summary>
		[JsonProperty("can_create_topic")]
		public bool CanCreateTopic { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь написать сообщение сообществу.
		/// </summary>
		[JsonProperty("can_message")]
		public bool CanMessage { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь оставлять записи на стене
		/// сообщества (<c> true </c> - может,
		/// <c> false </c> - не может).
		/// </summary>
		[JsonProperty("can_post")]
		public bool CanPost { get; set; }

		/// <summary>
		/// Информация о том, разрешено видеть чужие записи на стене группы (<c> true </c>
		/// - разрешено, <c> false </c> - не
		/// разрешено).
		/// </summary>
		[JsonProperty("can_see_all_posts")]
		public bool CanSeeAllPosts { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать документы в группу (
		/// <c> true </c>, если пользователь может
		/// загружать документы, <c> false </c> – если не может).
		/// </summary>
		[JsonProperty("can_upload_documents")]
		public bool CanUploadDocuments { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать видеозаписи в группу.
		/// </summary>
		[JsonProperty("can_upload_video")]
		public bool CanUploadVideo { get; set; }

		/// <summary>
		/// Город.
		/// </summary>
		[JsonProperty("city")]
		public City City { get; set; }

		/// <summary>
		/// Информация из блока контактов публичной страницы.
		/// </summary>
		[JsonProperty("contacts")]
		public ReadOnlyCollection<Contact> Contacts { get; set; }

		/// <summary>
		/// Счетчики сообщества.
		/// </summary>
		[JsonProperty("counters")]
		public Counters Counters { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной в информации о сообществе. Возвращается
		/// идентификатор страны, который можно
		/// использовать для
		/// получения ее названия с помощью метода <c>DatabaseCategory.GetCountriesById</c>
		/// </summary>
		[JsonProperty("country")]
		public Country Country { get; set; }

		/// <summary>
		/// Обложка сообщества
		/// </summary>
		[JsonProperty("cover")]
		public GroupCover Cover { get; set; }

		/// <summary>
		/// Текст описания сообщества.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Идентификатор закрепленного поста сообщества. Сам пост можно получить,
		/// используя <c>WallCategory.GetById</c>
		/// передав идентификатор в виде – <c>{group_id}_{post_id}</c>.
		/// </summary>
		[JsonProperty("fixed_post")]
		public long? FixedPost { get; set; }

		/// <summary>
		/// Содержит фото.
		/// </summary>
		[JsonProperty("has_photo")]
		public bool HasPhoto { get; set; }

		/// <summary>
		/// Возвращается 1, если пользователь является рекламодателем.
		/// </summary>
		[JsonProperty("is_advertiser")]
		public bool IsAdvertiser { get; set; }


		/// <summary>
		/// Возвращается 1, если сообщество находится в закладках у текущего пользователя.
		/// </summary>
		[JsonProperty("is_favorite")]
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Возвращается 1, если сообщество скрыто в новостях у текущего пользователя.
		/// </summary>
		[JsonProperty("is_hidden_from_feed")]
		public bool IsHiddenFromFeed { get; set; }

		/// <summary>
		/// Информация о том, разрешено ли сообществу отправлять сообщения текущему
		/// пользователю.
		/// </summary>
		[JsonProperty("is_messages_allowed")]
		public bool? IsMessagesAllowed { get; set; }

		/// <summary>
		/// Информация из блока ссылок сообщества.
		/// </summary>
		[JsonProperty("links")]
		public ReadOnlyCollection<ExternalLink> Links { get; set; }

		/// <summary>
		/// Идентификатор основного альбома сообщества.
		/// </summary>
		[JsonProperty("main_album_id")]
		public uint? MainAlbumId { get; set; }

		/// <summary>
		/// Информация о главной секции в сообществе
		/// </summary>
		[JsonProperty("main_section")]
		public MainSection? MainSection { get; set; }

		/// <summary>
		/// Информация о магазине
		/// </summary>
		[JsonProperty("market")]
		public GroupMarket Market { get; set; }

		/// <summary>
		/// Статус участника текущего пользователя.
		/// </summary>
		[JsonProperty("member_status")]
		public MemberStatus MemberStatus { get; set; }

		/// <summary>
		/// Количество участников сообщества.
		/// </summary>
		[JsonProperty("members_count")]
		public int? MembersCount { get; set; }

		/// <summary>
		/// Место, указанное в информации о сообществе.
		/// </summary>
		[JsonProperty("place")]
		public Place Place { get; set; }

		/// <summary>
		/// Возвращается для публичных страниц. Текст описания для поля <c>start_date</c>.
		/// </summary>
		[JsonProperty("public_date_label")]
		public string PublicDateLabel { get; set; }

		/// <summary>
		/// Адрес сайта из поля «веб-сайт» в описании сообщества.
		/// </summary>
		[JsonProperty("site")]
		public string Site { get; set; }

		/// <summary>
		/// Время начала встречи (возвращаются только для встреч).
		/// </summary>
		[JsonProperty("start_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Объект аудиозаписи, установленной в статус (если аудиозапись транслируется в текущей момент).
		/// </summary>
		[JsonProperty("status_audio")]
		public Audio StatusAudio { get; set; }

		/// <summary>
		/// Время окончания встречи (возвращаются только для встреч).
		/// </summary>
		[JsonProperty("end_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Статус сообщества. Возвращается строка, содержащая текст статуса,
		/// расположенного на странице сообщества под его
		/// названием.
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		/// Информация о том, есть ли у сообщества «огонёк».
		/// </summary>
		[JsonProperty("trending")]
		public bool Trending { get; set; }

		/// <summary>
		/// Возвращает информацию о том, является ли сообщество верифицированным.
		/// </summary>
		[JsonProperty("verified")]
		public bool Verified { get; set; }

		/// <summary>
		/// Название главной вики-страницы сообщества.
		/// </summary>
		[JsonProperty("wiki_page")]
		public string WikiPage { get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий сообщества.
		/// </summary>
		[JsonProperty("photo_previews")]
		public Previews PhotoPreviews { get; set; }

		/// <summary>
		/// Стена
		/// </summary>
		[JsonProperty("wall")]
		public WallType Wall { get; set; }

	#endregion
	}
}