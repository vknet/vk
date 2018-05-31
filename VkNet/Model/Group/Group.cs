using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о сообществе (группе).
	/// См. описание http://vk.com/dev/fields_groups
	/// </summary>
	[DebuggerDisplay(value: "[{Id}] {Name}")]
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
			return FromJson(response: response);
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
					Id = response[key: "group_id"] ?? response[key: "gid"] ?? response[key: "id"]
					, Name = response[key: "name"]
					, ScreenName = response[key: "screen_name"]
					, IsClosed = response[key: "is_closed"]
					, IsAdmin = response[key: "is_admin"]
					, AdminLevel = response[key: "admin_level"]
					, IsMember = response[key: "is_member"]
					, Type = response[key: "type"]
					, PhotoPreviews = response
					, Deactivated = response[key: "deactivated"]
					, HasPhoto = response[key: "has_photo"]
					, Photo50 = response[key: "photo_50"]
					, Photo100 = response[key: "photo_100"]
					, Photo200 = response[key: "photo_200"]
					,

					// опциональные поля
					City = response[key: "city"]
					, Country = response[key: "country"]
					, Place = response[key: "place"]
					, Description = response[key: "description"]
					, WikiPage = response[key: "wiki_page"]
					, MembersCount = response[key: "members_count"]
					, Counters = response[key: "counters"]
					, StartDate = response[key: "start_date"]
					, EndDate = response[key: "finish_date"] ?? response[key: "end_date"]
					, CanPost = response[key: "can_post"]
					, CanSeeAllPosts = response[key: "can_see_all_posts"]
					, CanUploadDocuments = response[key: "can_upload_doc"]
					, CanCreateTopic = response[key: "can_create_topic"]
					, Activity = response[key: "activity"]
					, Status = response[key: "status"]
					, Contacts = response[key: "contacts"].ToReadOnlyCollectionOf<Contact>(selector: x => x)
					, Links = response[key: "links"].ToReadOnlyCollectionOf<ExternalLink>(selector: x => x)
					, FixedPost = response[key: "fixed_post"]
					, Verified = response[key: "verified"]
					, Site = response[key: "site"]
					, InvitedBy = response[key: "invited_by"]
					, IsFavorite = response[key: "is_favorite"]
					, BanInfo = response[key: "ban_info"]
					, CanUploadVideo = response[key: "can_upload_video"]
					, MainAlbumId = response[key: "main_album_id"]
					, IsHiddenFromFeed = response[key: "is_hidden_from_feed"]
					, MainSection = response[key: "main_section"]
					, IsMessagesAllowed = response[key: "is_messages_allowed"]
					, Trending = response[key: "trending"]
					, CanMessage = response[key: "can_message"]
					, Cover = response[key: "cover"]
					, Market = response[key: "market"]
					, AgeLimits = response[key: "age_limits"]
					, MemberStatus = response[key: "member_status"]
					, PublicDateLabel = response[key: "public_date_label"]
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
		public string Name { get; set; }

		/// <summary>
		/// Короткий адрес страницы сообщества, например, apiclub. Если он не назначен, то
		/// 'club'+gid, например, club35828305.
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Публичность группы.
		/// </summary>
		public GroupPublicity? IsClosed { get; set; }

		/// <summary>
		/// Возвращается в случае, если сообщество удалено или заблокировано
		/// </summary>
		public Deactivated Deactivated { get; set; }

		/// <summary>
		/// Признак яляется ли текущий пользователь руководителем сообщества.
		/// </summary>
		public bool IsAdmin { get; set; }

		/// <summary>
		/// Уровень административных полномочий текущего пользователя в сообществе
		/// (действительно, если IsAdmin = true).
		/// </summary>
		public AdminLevel? AdminLevel { get; set; }

		/// <summary>
		/// Признак является ли текущий пользователь участником сообщества.
		/// </summary>
		public bool? IsMember { get; set; }

		/// <summary>
		/// Идентификатор пользователя пригласившего в группу
		/// </summary>
		public long? InvitedBy { get; set; }

		/// <summary>
		/// Тип сообщества.
		/// </summary>
		public GroupType Type { get; set; }

		/// <summary>
		/// url фотографии сообщества с размером 50x50px
		/// </summary>
		public Uri Photo50 { get; set; }

		/// <summary>
		/// url фотографии сообщества с размером 100x100px
		/// </summary>
		public Uri Photo100 { get; set; }

		/// <summary>
		/// url фотографии сообщества с размером 200x200px
		/// </summary>
		public Uri Photo200 { get; set; }

	#endregion

	#region Опциональные поля

		/// <summary>
		/// Строка состояния публичной страницы. У групп возвращается строковое значение,
		/// открыта ли группа или нет,
		/// а у событий дата начала.
		/// </summary>
		public string Activity { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "age_limits")]
		public AgeLimit AgeLimits { get; set; }

		/// <summary>
		/// Информация о забанненом (добавленном в черный список) пользователе сообщества.
		/// </summary>
		public BanInfo BanInfo { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь создать тему обсуждения в
		/// группе.
		/// (<c> true </c>, если пользователь может создать обсуждение, <c> false </c> –
		/// если не может).
		/// </summary>
		public bool CanCreateTopic { get; set; }

		/// <summary>
		/// информация о том, может ли текущий пользователь написать сообщение сообществу.
		/// </summary>
		[JsonProperty(propertyName: "can_message")]
		public bool CanMessage { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь оставлять записи на стене
		/// сообщества (<c> true </c> - может,
		/// <c> false </c> - не может).
		/// </summary>
		public bool CanPost { get; set; }

		/// <summary>
		/// Информация о том, разрешено видеть чужие записи на стене группы (<c> true </c>
		/// - разрешено, <c> false </c> - не
		/// разрешено).
		/// </summary>
		public bool CanSeeAllPosts { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать документы в группу (
		/// <c> true </c>, если пользователь может
		/// загружать документы, <c> false </c> – если не может).
		/// </summary>
		public bool CanUploadDocuments { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать видеозаписи в группу.
		/// </summary>
		public bool CanUploadVideo { get; set; }

		/// <summary>
		/// Город.
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// Информация из блока контактов публичной страницы.
		/// </summary>
		public ReadOnlyCollection<Contact> Contacts { get; set; }

		/// <summary>
		/// Счетчики сообщества.
		/// </summary>
		public Counters Counters { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной в информации о сообществе. Возвращается
		/// идентификатор страны, который можно
		/// использовать для
		/// получения ее названия с помощью метода DatabaseCategory.GetCountriesById
		/// </summary>
		public Country Country { get; set; }

		/// <summary>
		/// обложка сообщества
		/// </summary>
		[JsonProperty(propertyName: "cover")]
		public GroupCover Cover { get; set; }

		/// <summary>
		/// Текст описания сообщества.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Идентификатор закрепленного поста сообщества. Сам пост можно получить,
		/// используя WallCategory.GetById
		/// передав идентификатор в виде – {group_id}_{post_id}.
		/// </summary>
		public long? FixedPost { get; set; }

		/// <summary>
		/// Содержит фото.
		/// </summary>
		public bool HasPhoto { get; set; }

		/// <summary>
		/// Возвращается 1, если сообщество находится в закладках у текущего пользователя.
		/// </summary>
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Возвращается 1, если сообщество скрыто в новостях у текущего пользователя.
		/// </summary>
		public bool IsHiddenFromFeed { get; set; }

		/// <summary>
		/// Информация о том, разрешено ли сообществу отправлять сообщения текущему
		/// пользователю.
		/// </summary>
		public bool? IsMessagesAllowed { get; set; }

		/// <summary>
		/// Информация из блока ссылок сообщества.
		/// </summary>
		public ReadOnlyCollection<ExternalLink> Links { get; set; }

		/// <summary>
		/// Идентификатор основного альбома сообщества.
		/// </summary>
		public uint? MainAlbumId { get; set; }

		/// <summary>
		/// Информация о главной секции в сообществе
		/// </summary>
		public MainSection? MainSection { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "market")]
		public Market Market { get; set; }

		/// <summary>
		/// статус участника текущего пользователя.
		/// </summary>
		[JsonProperty(propertyName: "member_status")]
		public MemberStatus MemberStatus { get; set; }

		/// <summary>
		/// Количество участников сообщества.
		/// </summary>
		public int? MembersCount { get; set; }

		/// <summary>
		/// Место, указанное в информации о сообществе.
		/// </summary>
		public Place Place { get; set; }

		/// <summary>
		/// возвращается для публичных страниц. Текст описания для поля start_date.
		/// </summary>
		[JsonProperty(propertyName: "public_date_label")]
		public string PublicDateLabel { get; set; }

		/// <summary>
		/// Адрес сайта из поля «веб-сайт» в описании сообщества.
		/// </summary>
		public string Site { get; set; }

		/// <summary>
		/// Время начала встречи (возвращаются только для встреч).
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Время окончания встречи (возвращаются только для встреч).
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Статус сообщества. Возвращается строка, содержащая текст статуса,
		/// расположенного на странице сообщества под его
		/// названием.
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// Информация о том, есть ли у сообщества «огонёк».
		/// </summary>
		public bool Trending { get; set; }

		/// <summary>
		/// Возвращает информацию о том, является ли сообщество верифицированным.
		/// </summary>
		public bool Verified { get; set; }

		/// <summary>
		/// Название главной вики-страницы сообщества.
		/// </summary>
		public string WikiPage { get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий сообщества.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

	#endregion
	}
}