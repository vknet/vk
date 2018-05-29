using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

// ReSharper disable UnusedAutoPropertyAccessor.Global

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Model
{
	/// <summary>
	/// Информация о пользователя.
	/// См. описание https://vk.com/dev/objects/user
	/// </summary>
	[DebuggerDisplay(value: "[{Id}] {FirstName} {LastName}")]
	[Serializable]
	public class User
	{
	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static User FromJson(VkResponse response)
		{
			var user = new User
			{
					Id = response[key: "user_id"] ?? response[key: "uid"] ?? response[key: "id"] ?? 0
					, FirstName = response[key: "first_name"]
					, LastName = response[key: "last_name"]
					, Sex = response[key: "sex"]
					, BirthDate = response[key: "bdate"]
					, City = response[key: "city"]
					, Country = response[key: "country"]
					, PhotoPreviews = response
					, Online = response[key: "online"]
					, FriendLists = response[key: "lists"].ToReadOnlyCollectionOf<long>(selector: x => x)
					, Domain = response[key: "domain"]
					, HasMobile = response[key: "has_mobile"]
					, MobilePhone = response[key: "mobile_phone"] ?? response[key: "phone"]
					, HomePhone = response[key: "home_phone"]
					, Connections = response
					, Site = response[key: "site"]
					, Education = response
					, Universities = response[key: "universities"].ToReadOnlyCollectionOf<University>(selector: x => x)
					, Schools = response[key: "schools"].ToReadOnlyCollectionOf<School>(selector: x => x)
					, CanPost = response[key: "can_post"]
					, CanSeeAllPosts = response[key: "can_see_all_posts"]
					, CanSeeAudio = response[key: "can_see_audio"]
					, CanWritePrivateMessage = response[key: "can_write_private_message"]
					, Status = response[key: "status"]
					, LastSeen = response[key: "last_seen"]
					, CommonCount = response[key: "common_count"]
					, Relation = response[key: "relation"]
					, Relatives = response[key: "relatives"].ToReadOnlyCollectionOf<Relative>(selector: x => x)
					, Counters = response[key: "counters"]
					, ScreenName = response[key: "screen_name"]
					, Nickname = response[key: "nickname"]
					, Timezone = response[key: "timezone"]
					, Language = response[key: "language"]
					, OnlineMobile = response[key: "online_mobile"]
					, OnlineApp = response[key: "online_app"]
					, RelationPartner = response[key: "relation_partner"]
					, StandInLife = response[key: "personal"]
					, Interests = response[key: "interests"]
					, Music = response[key: "music"]
					, Activities = response[key: "activities"]
					, Movies = response[key: "movies"]
					, Tv = response[key: "tv"]
					, Books = response[key: "books"]
					, Games = response[key: "games"]
					, About = response[key: "about"]
					, Quotes = response[key: "quotes"]
					, InvitedBy = response[key: "invited_by"]
					, BanInfo = response[key: "ban_info"]
					, Deactivated = response[key: "deactivated"]
					, MaidenName = response[key: "maiden_name"]
					, BirthdayVisibility = response[key: "bdate_visibility"]
					, HomeTown = response[key: "home_town"]
					, ChangeNameRequest = response[key: "name_request"]
					, Contacts = response[key: "contacts"]
					, Hidden = response[key: "hidden"]
					, PhotoId = response[key: "photo_id"]
					, Verified = response[key: "verified"]
					, HasPhoto = response[key: "has_photo"]
					, Photo50 = response[key: "photo_50"]
					, Photo100 = response[key: "photo_100"]
					, Photo200Orig = response[key: "photo_200_orig"]
					, Photo200 = response[key: "photo_200"]
					, Photo400Orig = response[key: "photo_400_orig"]
					, PhotoMax = response[key: "photo_max"]
					, PhotoMaxOrig = response[key: "photo_max_orig"]
					, FollowersCount = response[key: "followers_count"]
					, Occupation = response[key: "occupation"]
					, Exports = response[key: "exports"]
					, WallComments = response[key: "wall_comments"]
					, CanSendFriendRequest = response[key: "can_send_friend_request"]
					, IsFavorite = response[key: "is_favorite"]
					, IsHiddenFromFeed = response[key: "is_hidden_from_feed"]
					, CropPhoto = response[key: "crop_photo"]
					, IsFriend = response[key: "is_friend"] == "1"
					, FriendStatus = response[key: "friend_status"]
					, Career = response[key: "career"].ToReadOnlyCollectionOf<Career>(selector: x => x)
					, Military = response[key: "military"]
					, Blacklisted = response[key: "blacklisted"]
					, BlacklistedByMe = response[key: "blacklisted_by_me"]
					, Trending = response[key: "trending"]
					, FirstNameNom = response[key: "first_name_nom"]
					, FirstNameGen = response[key: "first_name_gen"]
					, FirstNameDat = response[key: "first_name_dat"]
					, FirstNameAcc = response[key: "first_name_acc"]
					, FirstNameIns = response[key: "first_name_ins"]
					, FirstNameAbl = response[key: "first_name_abl"]
					, LastNameNom = response[key: "last_name_nom"]
					, LastNameGen = response[key: "last_name_gen"]
					, LastNameDat = response[key: "last_name_dat"]
					, LastNameAcc = response[key: "last_name_acc"]
					, LastNameIns = response[key: "last_name_ins"]
					, LastNameAbl = response[key: "last_name_abl"]
			};

			user.IsDeactivated = user.Deactivated != null;

			if (response[key: "name"] != null)
			{
				// Разделить имя и фамилию
				var parts = ((string) response[key: "name"]).Split(' ');

				if (parts.Length < 2)
				{
					user.FirstName = response[key: "name"];
				} else
				{
					user.FirstName = parts[0];
					user.LastName = parts[1];
				}
			}

			if (user.BirthDate == null || response[key: "bdate_visibility"] != null)
			{
				return user;
			}

			var birdthdayParts = user.BirthDate.Split('.');

			user.BirthdayVisibility = birdthdayParts.Length > 2
					? Enums.BirthdayVisibility.Full
					: Enums.BirthdayVisibility.OnlyDayAndMonth;

			return user;
		}

	#endregion

	#region Базовые поля

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public long Id { get; set; }

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия пользователя.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Причина блокирования аккаунта
		/// </summary>
		public Deactivated Deactivated { get; set; }

		/// <summary>
		/// Возвращается при вызове без access_token, если пользователь установил настройку
		/// «Кому в интернете видна моя
		/// страница» — «Только пользователям ВКонтакте».
		/// Обратите внимание, в этом случае дополнительные поля fields не возвращаются.
		/// </summary>
		public bool Hidden { get; set; }

	#endregion

	#region Опциональные поля

		/// <summary>
		/// Информация пользователя о себе.
		/// </summary>
		public string About { get; set; }

		/// <summary>
		/// Чем занимается пользователь.
		/// </summary>
		public string Activities { get; set; }

		/// <summary>
		/// Дата рождения пользователя. Возвращается в формате DD.MM.YYYY или DD.MM (если
		/// год рождения скрыт).
		/// Если дата рождения скрыта целиком, поле отсутствует в ответе.
		/// </summary>
		public string BirthDate { get; set; }

		/// <summary>
		/// Возвращается 1, если текущий пользователь находится в черном списке у
		/// запрашиваемого пользователя.
		/// </summary>
		public bool Blacklisted { get; set; }

		/// <summary>
		/// Возвращается 1, если запрашиваемый пользователь находится в черном списке у
		/// текущего пользователя.
		/// </summary>
		public bool BlacklistedByMe { get; set; }

		/// <summary>
		/// Любимые книги пользователя.
		/// </summary>
		public string Books { get; set; }

		/// <summary>
		/// Признак разрешено ли оставлять записи на стене у пользователя.
		/// </summary>
		public bool CanPost { get; set; }

		/// <summary>
		/// Признак разрешено ли видеть чужие записи на стене пользователя.
		/// </summary>
		public bool CanSeeAllPosts { get; set; }

		/// <summary>
		/// Признак разрешено ли видеть чужие аудиозаписи на стене пользователя.
		/// </summary>
		public bool CanSeeAudio { get; set; }

		/// <summary>
		/// Информация о том, будет ли отправлено уведомление пользователю о заявке в
		/// друзья.
		/// </summary>
		public bool CanSendFriendRequest { get; set; }

		/// <summary>
		/// Признак разрешено ли написание личных сообщений данному пользователю.
		/// </summary>
		public bool CanWritePrivateMessage { get; set; }

		/// <summary>
		/// Информация о карьере пользователя.
		/// </summary>
		public ReadOnlyCollection<Career> Career { get; set; }

		/// <summary>
		/// Идентификатор города, указанного на странице пользователя в разделе «Контакты».
		/// Если город не указан, или основная информация страницы скрыта настройками
		/// приватности, то 0.
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// Общее количество друзей с текущим пользователем.
		/// </summary>
		public int? CommonCount { get; set; }

		/// <summary>
		/// Данные о подключенных сервисах пользователя, таких как: skype, facebook,
		/// twitter, instagram.
		/// </summary>
		public Connections Connections { get; set; }

		/// <summary>
		/// Информация о телефонных номерах пользователя.
		/// </summary>
		public Contacts Contacts { get; set; }

		/// <summary>
		/// Различные счетчики пользователя.
		/// </summary>
		public Counters Counters { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной на странице пользователя в разделе «Контакты».
		/// Если страна не указана или основная информация страницы скрыта настройками
		/// приватности, то 0.
		/// </summary>
		public Country Country { get; set; }

		/// <summary>
		/// Возвращает данные о точках, по которым вырезаны профильная и миниатюрная
		/// фотографии пользователя.
		/// </summary>
		public CropPhoto CropPhoto { get; set; }

		/// <summary>
		/// Короткий адрес страницы пользователя. Возвращается строка, содержащая короткий
		/// адрес страницы (возвращается только
		/// сам поддомен, например, andrew). Если он не назначен, то "id"+uid, например,
		/// id35828305.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Сведения об образовании пользователя.
		/// </summary>
		public Education Education { get; set; }

		/// <summary>
		/// Внешние сервисы, в которые настроен экспорт из ВК.
		/// </summary>
		public Exports Exports { get; set; }

		/// <summary>
		/// Имя в именительном падеже
		/// </summary>
		public string FirstNameNom { get; set; }

		/// <summary>
		/// Имя в родительном падеже
		/// </summary>
		public string FirstNameGen { get; set; }

		/// <summary>
		/// Имя в дательном падеже
		/// </summary>
		public string FirstNameDat { get; set; }

		/// <summary>
		/// Имя в винительном падеже
		/// </summary>
		public string FirstNameAcc { get; set; }

		/// <summary>
		/// Имя в творительном падеже
		/// </summary>
		public string FirstNameIns { get; set; }

		/// <summary>
		/// Имя в предложном падеже
		/// </summary>
		public string FirstNameAbl { get; set; }

		/// <summary>
		/// Количество подписчиков пользователя.
		/// </summary>
		public long? FollowersCount { get; set; }

		/// <summary>
		/// Состояние дружбы с пользователями.
		/// </summary>
		public FriendStatus FriendStatus { get; set; }

		/// <summary>
		/// Любимые игры пользователя.
		/// </summary>
		public string Games { get; set; }

		/// <summary>
		/// Информация о том, известен ли номер мобильного телефона пользователя (true -
		/// известен, false - не известен).
		/// </summary>
		public bool? HasMobile { get; set; }

		/// <summary>
		/// Возвращается 1, если текущий пользователь установил фотографию для профиля.
		/// </summary>
		public bool? HasPhoto { get; set; }

		/// <summary>
		/// Родной город пользователя.
		/// </summary>
		public string HomeTown { get; set; }

		/// <summary>
		/// Интересы пользователя.
		/// </summary>
		public string Interests { get; set; }

		/// <summary>
		/// Возвращается 1, если пользователь находится в закладках у текущего
		/// пользователя.
		/// </summary>
		public bool IsFavorite { get; set; }

		/// <summary>
		/// 1 – пользователь друг, 2 – пользователь не в друзьях.
		/// </summary>
		public bool? IsFriend { get; set; }

		/// <summary>
		/// Возвращается 1, если пользователь скрыт в новостях у текущего пользователя.
		/// </summary>
		public bool IsHiddenFromFeed { get; set; }

		/// <summary>
		/// Фамилия в именительном падеже
		/// </summary>
		public string LastNameNom { get; set; }

		/// <summary>
		/// Фамилия в родительном падеже
		/// </summary>
		public string LastNameGen { get; set; }

		/// <summary>
		/// Фамилия в дательном падеже
		/// </summary>
		public string LastNameDat { get; set; }

		/// <summary>
		/// Фамилия в винительном падеже
		/// </summary>
		public string LastNameAcc { get; set; }

		/// <summary>
		/// Фамилия в творительном падеже
		/// </summary>
		public string LastNameIns { get; set; }

		/// <summary>
		/// Фамилия в предложном падеже
		/// </summary>
		public string LastNameAbl { get; set; }

		/// <summary>
		/// Время последнего посещения сайта.
		/// </summary>
		public LastSeen LastSeen { get; set; }

		/// <summary>
		/// Идентификаторы списков друзей, в которых состоит пользователь. Поле доступно
		/// только для метода
		/// FriendsCategory.Get. Получить информацию об идентификаторах и названиях списков
		/// друзей можно с
		/// помощью метода FriendsCategory.GetLists. Если пользователь не состоит ни в
		/// одном списке друзей, данное
		/// поле принимает значение null.
		/// </summary>
		/// <remarks>
		/// поле lists
		/// </remarks>
		public ReadOnlyCollection<long> FriendLists { get; set; }

		/// <summary>
		/// Девичья фамилия (только для женского пола)
		/// </summary>
		public string MaidenName { get; set; }

		/// <summary>
		/// Информация о военной службе пользователя.
		/// </summary>
		public Military Military { get; set; }

		/// <summary>
		/// Любимые фильмы пользователя.
		/// </summary>
		public string Movies { get; set; }

		/// <summary>
		/// Любимая музыка пользователя.
		/// </summary>
		public string Music { get; set; }

		/// <summary>
		/// Прозвище (ник) пользователя.
		/// </summary>
		public string Nickname { get; set; }

		/// <summary>
		/// Информация о текущем роде занятия пользователя.
		/// </summary>
		public Occupation Occupation { get; set; }

		/// <summary>
		/// Признак находится ли пользователь сейчас на сайте.
		/// </summary>
		public bool? Online { get; set; }

		/// <summary>
		/// Жизненная позиция.
		/// </summary>
		/// <remarks>
		/// поле <c> personal </c>
		/// </remarks>
		public StandInLife StandInLife { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 50 пикселей. В случае
		/// отсутствия у пользователя фотографии
		/// возвращается http://vk.com/images/camera_c.gif
		/// </summary>
		public Uri Photo50 { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 100 пикселей. В случае
		/// отсутствия у пользователя фотографии
		/// возвращается http://vk.com/images/camera_b.gif.
		/// </summary>
		public Uri Photo100 { get; set; }

		/// <summary>
		/// url фотографии пользователя, имеющей ширину 200 пикселей. В случае отсутствия у
		/// пользователя фотографии
		/// возвращается http://vk.com/images/camera_a.gif.
		/// </summary>
		public Uri Photo200Orig { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 200 пикселей. Если
		/// фотография была загружена давно,
		/// изображения с такими размерами может не быть, в этом случае ответ не будет
		/// содержать этого поля.
		/// </summary>
		public Uri Photo200 { get; set; }

		/// <summary>
		/// url фотографии пользователя, имеющей ширину 400 пикселей.
		/// Если у пользователя отсутствует фотография такого размера, ответ не будет
		/// содержать этого поля.
		/// </summary>
		public Uri Photo400Orig { get; set; }

		/// <summary>
		/// id главной фотографии профиля пользователя в формате user_id+photo_id,
		/// например, 6492_192164258.
		/// В некоторых случаях (если фотография была установлена очень давно) это поле не
		/// возвращается.
		/// </summary>
		public string PhotoId { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя с максимальной шириной.
		/// Может быть возвращена фотография, имеющая ширину как 200, так и 100 пикселей.
		/// В случае отсутствия у пользователя фотографии возвращается
		/// http://vk.com/images/camera_b.gif.
		/// </summary>
		public Uri PhotoMax { get; set; }

		/// <summary>
		/// url фотографии пользователя максимального размера.
		/// Может быть возвращена фотография, имеющая ширину как 400, так и 200 пикселей.
		/// В случае отсутствия у пользователя фотографии возвращается
		/// http://vk.com/images/camera_a.gif.
		/// </summary>
		public Uri PhotoMaxOrig { get; set; }

		/// <summary>
		/// Избранные пользователем цитаты.
		/// </summary>
		public string Quotes { get; set; }

		/// <summary>
		/// Родственники пользователя.
		/// </summary>
		public ReadOnlyCollection<Relative> Relatives { get; set; }

		/// <summary>
		/// Семейное положение.
		/// </summary>
		public RelationType Relation { get; set; }

		/// <summary>
		/// Школы, в которых учился пользователь.
		/// </summary>
		public ReadOnlyCollection<School> Schools { get; set; }

		/// <summary>
		/// Короткое имя (поддомен) страницы пользователя.
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Пол пользователя.
		/// </summary>
		public Sex Sex { get; set; }

		/// <summary>
		/// Возвращает указанный в профиле сайт пользователя.
		/// </summary>
		public string Site { get; set; }

		/// <summary>
		/// Строка со статусом пользователя.
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// Часовой пояс пользователя.
		/// </summary>
		public int? Timezone { get; set; }

		/// <summary>
		/// Возвращается 1, если запрашиваемый пользователь находится в черном списке у
		/// текущего пользователя.
		/// </summary>
		public bool Trending { get; set; }

		/// <summary>
		/// Любимые телешоу пользователя.
		/// </summary>
		public string Tv { get; set; }

		/// <summary>
		/// Список высших учебных заведений, в которых учился пользователь.
		/// </summary>
		public ReadOnlyCollection<University> Universities { get; set; }

		/// <summary>
		/// Возвращается 1, если страница пользователя верифицирована, 0 — если не
		/// верифицирована.
		/// </summary>
		public bool? Verified { get; set; }

		/// <summary>
		/// Доступно ли комментирование стены (1 — доступно, 0 — недоступно).
		/// </summary>
		public bool WallComments { get; set; }

	#endregion

	#region Поля, установленные экспериментально

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий пользователя.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

		/// <summary>
		/// Номер мобильного телефона (если нет записи или скрыт, то null).
		/// </summary>
		public string MobilePhone { get; set; }

		/// <summary>
		/// Номер домашнего телефона (если нет записи или скрыт, то null).
		/// </summary>
		public string HomePhone { get; set; }

		/// <summary>
		/// Информация о блокировке пользователя
		/// </summary>
		public BanInfo BanInfo { get; set; }

		/// <summary>
		/// Является ли пользователь заблокированным
		/// </summary>
		public bool IsDeactivated { get; set; }

		/// <summary>
		/// Идентификатор языка, установленный в настройках.
		/// </summary>
		public long? Language { get; set; }

		/// <summary>
		/// Признак использует ли пользователь мобильное приложение либо мобильную версию
		/// сайта.
		/// </summary>
		public bool? OnlineMobile { get; set; }

		/// <summary>
		/// Если пользователь зашёл через приложение, то Id приложения иначе null.
		/// </summary>
		public long? OnlineApp { get; set; }

		/// <summary>
		/// Партнер в семейных отношениях.
		/// </summary>
		public User RelationPartner { get; set; }

		/// <summary>
		/// Идентификатор пользователя, пригласившего пользователя в беседу (для
		/// GetChatUsers).
		/// </summary>
		public long? InvitedBy { get; set; }

		/// <summary>
		/// Видимость даты рождения.
		/// </summary>
		public BirthdayVisibility? BirthdayVisibility { get; set; }

		/// <summary>
		/// Информация о заявке на смену имени.
		/// </summary>
		public ChangeNameRequest ChangeNameRequest { get; set; }

	#endregion

	#region private

		[JsonProperty(propertyName: "uid")]
		private long Uid
		{
			get => Id;
			set => Id = value;
		}

		[JsonProperty(propertyName: "user_id")]
		private long UserId
		{
			get => Id;
			set => Id = value;
		}

		[JsonProperty(propertyName: "phone")]
		private string Phone
		{
			get => MobilePhone;
			set => MobilePhone = value;
		}

	#endregion
	}
}