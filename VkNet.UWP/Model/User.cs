using System.Runtime.Serialization;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	using System;
	using System.Collections.ObjectModel;
	using System.Diagnostics;

	using Categories;
	using Enums;
	using Exception;
	using Utils;

	/// <summary>
	/// Информация о пользователя.
	/// См. описание <see href="http://vk.com/dev/fields"/> и <see href="http://vk.com/pages?oid=-1&amp;p=users.get"/>.
	/// </summary>
	[DebuggerDisplay("[{Id}] {FirstName} {LastName}")]
	[DataContract]
	public class User
	{
		#region Стандартные поля

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
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
		/// Возвращается при вызове без access_token, если пользователь установил настройку «Кому в интернете видна моя страница» — «Только пользователям ВКонтакте».
		/// Обратите внимание, в этом случае дополнительные поля fields не возвращаются.
		/// </summary>
		public bool Hidden { get; set; }
		#endregion

		#region Опциональные поля

		/// <summary>
		/// Пол пользователя.
		/// </summary>
		public Sex Sex { get; set; }

		/// <summary>
		/// Дата рождения пользователя. Возвращается в формате DD.MM.YYYY или DD.MM (если год рождения скрыт).
		/// Если дата рождения скрыта целиком, поле отсутствует в ответе.
		/// </summary>
		public string BirthDate { get; set; }

		/// <summary>
		/// Идентификатор города, указанного на странице пользователя в разделе «Контакты».
		/// Если город не указан, или основная информация страницы скрыта настройками приватности, то 0.
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной на странице пользователя в разделе «Контакты».
		/// Если страна не указана или основная информация страницы скрыта настройками приватности, то 0.
		/// </summary>
		public Country Country { get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий пользователя.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

		/// <summary>
		/// Признак находится ли пользователь сейчас на сайте.
		/// </summary>
		public bool? Online { get; set; }

		/// <summary>
		/// Идентификаторы списков друзей, в которых состоит пользователь. Поле доступно только для метода
		/// <see cref="FriendsCategory.Get"/>. Получить информацию об идентификаторах и названиях списков друзей можно с
		/// помощью метода <see cref="FriendsCategory.GetLists"/>. Если пользователь не состоит ни в одном списке друзей, данное
		/// поле принимает значение null.
		/// </summary>
		public Collection<long> FriendLists { get; set; }

		/// <summary>
		/// Короткий адрес страницы пользователя. Возвращается строка, содержащая короткий адрес страницы (возвращается только
		/// сам поддомен, например, andrew). Если он не назначен, то "id"+uid, например, id35828305.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Информация о том, известен ли номер мобильного телефона пользователя (true - известен, false - не известен).
		/// </summary>
		public bool? HasMobile { get; set; }

		/// <summary>
		/// Номер мобильного телефона (если нет записи или скрыт, то null).
		/// </summary>
		public string MobilePhone { get; set; }

		/// <summary>
		/// Номер домашнего телефона (если нет записи или скрыт, то null).
		/// </summary>
		public string HomePhone { get; set; }

		/// <summary>
		/// Данные о подключенных сервисах пользователя, таких как: skype, facebook, twitter, instagram.
		/// </summary>
		public Connections Connections { get; set; }

		/// <summary>
		/// Возвращает указанный в профиле сайт пользователя.
		/// </summary>
		public string Site { get; set; }

		/// <summary>
		/// Сведения об образовании пользователя.
		/// </summary>
		public Education Education { get; set; }

		/// <summary>
		/// Список высших учебных заведений, в которых учился пользователь.
		/// </summary>
		public Collection<University> Universities { get; set; }

		/// <summary>
		/// Школы, в которых учился пользователь.
		/// </summary>
		public Collection<School> Schools { get; set; }

		/// <summary>
		/// Признак разрешено ли оставлять записи на стене у пользователя.
		/// </summary>
		public bool CanPost
		{
			get;
			set;
		}

		/// <summary>
		/// Признак разрешено ли видеть чужие записи на стене пользователя.
		/// </summary>
		public bool CanSeeAllPosts
		{
			get;
			set;
		}

		/// <summary>
		/// Признак разрешено ли видеть чужие аудиозаписи на стене пользователя.
		/// </summary>
		public bool CanSeeAudio
		{
			get;
			set;
		}

		/// <summary>
		/// Признак разрешено ли написание личных сообщений данному пользователю.
		/// </summary>
		public bool CanWritePrivateMessage
		{
			get;
			set;
		}

		/// <summary>
		/// Строка со статусом пользователя.
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// Время последнего посещения сайта.
		/// </summary>
		public LastSeen LastSeen
		{
			get;
			set;
		}

		/// <summary>
		/// Общее количество друзей с текущим пользователем.
		/// </summary>
		public int? CommonCount
		{
			get;
			set;
		}

		/// <summary>
		/// Семейное положение.
		/// </summary>
		public RelationType Relation { get; set; }

		/// <summary>
		/// Родственники пользователя.
		/// </summary>
		public Collection<Relative> Relatives { get; set; }

		/// <summary>
		/// Различные счетчики пользователя.
		/// </summary>
		public Counters Counters
		{
			get;
			set;
		}

		/// <summary>
		/// Информация о блокировке пользователя
		/// </summary>
		public BanInfo BanInfo
		{
			get;
			set;
		}

		/// <summary>
		/// Является ли пользователь заблокированным
		/// </summary>
		public bool IsDeactivated { get; set; }

		/// <summary>
		/// Причина блокирования аккаунта
		/// </summary>
		[Obsolete("Устаревшее свойство. Используйте Deactivated")]
		public Deactivated DeactiveReason => Deactivated;

	    /// <summary>
		/// Причина блокирования аккаунта
		/// </summary>
		public Deactivated Deactivated
		{ get; set; }

		#endregion

		#region Дополнительные поля из http://vk.com/pages?oid=-1&p=users.get

		/// <summary>
		/// Прозвище (ник) пользователя.
		/// </summary>
		public string Nickname { get; set; }

		/// <summary>
		/// Часовой пояс пользователя.
		/// </summary>
		public int? Timezone { get; set; }

		#endregion

		#region Поля, установленные экспериментально

		/// <summary>
		/// Идентификатор языка, установленный в настройках.
		/// </summary>
		public long? Language { get; set; }

		/// <summary>
		/// Признак использует ли пользователь мобильное приложение либо мобильную версию сайта.
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
		/// Жизненные интересы.
		/// </summary>
		public StandInLife StandInLife { get; set; }

		/// <summary>
		/// Интересы пользователя.
		/// </summary>
		public string Interests { get; set; }

		/// <summary>
		/// Любимая музыка пользователя.
		/// </summary>
		public string Music { get; set; }

		/// <summary>
		/// Чем занимается пользователь.
		/// </summary>
		public string Activities { get; set; }

		/// <summary>
		/// Любимые фильмы пользователя.
		/// </summary>
		public string Movies { get; set; }

		/// <summary>
		/// Любимые телешоу пользователя.
		/// </summary>
		public string Tv { get; set; }

		/// <summary>
		/// Любимые книги пользователя.
		/// </summary>
		public string Books { get; set; }

		/// <summary>
		/// Любимые игры пользователя.
		/// </summary>
		public string Games { get; set; }

		/// <summary>
		/// Информация пользователя о себе.
		/// </summary>
		public string About { get; set; }

		/// <summary>
		/// Избранные пользователем цитаты.
		/// </summary>
		public string Quotes { get; set; }

		/// <summary>
		/// Идентификатор пользователя, пригласившего пользователя в беседу (для GetChatUsers).
		/// </summary>
		public long? InvitedBy { get; set; }

		/// <summary>
		/// Короткое имя (поддомен) страницы пользователя.
		/// </summary>
		public string ScreenName
		{ get; set; }

		#endregion

		#region Поля, доступные через запрос https://vk.com/dev/account.getProfileInfo

		/// <summary>
		/// Девичья фамилия (только для женского пола)
		/// </summary>
		public string MaidenName { get; set; }

		/// <summary>
		/// Видимость даты рождения.
		/// </summary>
		public BirthdayVisibility? BirthdayVisibility { get; set; }

		/// <summary>
		/// Родной город пользователя.
		/// </summary>
		public string HomeTown { get; set; }

		/// <summary>
		/// Информация о заявке на смену имени.
		/// </summary>
		public ChangeNameRequest ChangeNameRequest { get; set; }

		/// <summary>
		/// Информация о телефонных номерах пользователя.
		/// </summary>
		public string Contacts { get; set; }

		/// <summary>
		/// Показывать дату?
		/// </summary>
		[Obsolete("Пожалуйста используйте поле BirthdayVisibility")]
		public bool? BdateVisibility { get; set; }

		/// <summary>
		/// id главной фотографии профиля пользователя в формате user_id+photo_id, например, 6492_192164258. В некоторых случаях (если фотография была установлена очень давно) это поле не возвращается.
		/// </summary>
		public string PhotoId { get; set; }

		/// <summary>
		/// Возвращается 1, если страница пользователя верифицирована, 0 — если не верифицирована.
		/// </summary>
		public bool? Verified { get; set; }

		/// <summary>
		/// Возвращается 1, если текущий пользователь установил фотографию для профиля.
		/// </summary>
		public bool? HasPhoto { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 50 пикселей. В случае отсутствия у пользователя фотографии возвращается http://vk.com/images/camera_c.gif
		/// </summary>
		public Uri Photo50 { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 100 пикселей. В случае отсутствия у пользователя фотографии возвращается http://vk.com/images/camera_b.gif.
		/// </summary>
		public Uri Photo100 { get; set; }

		/// <summary>
		/// url фотографии пользователя, имеющей ширину 200 пикселей. В случае отсутствия у пользователя фотографии возвращается http://vk.com/images/camera_a.gif.
		/// </summary>
		public Uri Photo200Orig { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя, имеющей ширину 200 пикселей. Если фотография была загружена давно, изображения с такими размерами может не быть, в этом случае ответ не будет содержать этого поля.
		/// </summary>
		public Uri Photo200 { get; set; }

		/// <summary>
		/// url фотографии пользователя, имеющей ширину 400 пикселей. Если у пользователя отсутствует фотография такого размера, ответ не будет содержать этого поля.
		/// </summary>
		public Uri Photo400Orig { get; set; }

		/// <summary>
		/// url квадратной фотографии пользователя с максимальной шириной. Может быть возвращена фотография, имеющая ширину как 200, так и 100 пикселей. В случае отсутствия у пользователя фотографии возвращается http://vk.com/images/camera_b.gif.
		/// </summary>
		public Uri PhotoMax { get; set; }

		/// <summary>
		/// url фотографии пользователя максимального размера. Может быть возвращена фотография, имеющая ширину как 400, так и 200 пикселей. В случае отсутствия у пользователя фотографии возвращается http://vk.com/images/camera_a.gif.
		/// </summary>
		public Uri PhotoMaxOrig { get; set; }

		/// <summary>
		/// Количество подписчиков пользователя.
		/// </summary>
		public long? FollowersCount { get; set; }

		/// <summary>
		/// Информация о текущем роде занятия пользователя.
		/// </summary>
		public Occupation Occupation { get; set; }

		/// <summary>
		/// Внешние сервисы, в которые настроен экспорт из ВК.
		/// </summary>
		public Exports Exports { get; set; }

		/// <summary>
		/// Доступно ли комментирование стены (1 — доступно, 0 — недоступно).
		/// </summary>
		public bool WallComments { get; set; }

		/// <summary>
		/// Информация о том, будет ли отправлено уведомление пользователю о заявке в друзья.
		/// </summary>
		public bool CanSendFriendRequest { get; set; }

		/// <summary>
		/// Возвращается 1, если пользователь находится в закладках у текущего пользователя.
		/// </summary>
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Возвращается 1, если пользователь скрыт в новостях у текущего пользователя.
		/// </summary>
		public bool IsHiddenFromFeed { get; set; }

		/// <summary>
		/// Возвращает данные о точках, по которым вырезаны профильная и миниатюрная фотографии пользователя.
		/// </summary>
		public CropPhoto CropPhoto { get; set; }

		/// <summary>
		/// 1 – пользователь друг, 2 – пользователь не в друзьях.
		/// </summary>
		public bool? IsFriend { get; set; }

		/// <summary>
		/// Состояние дружбы с пользователями.
		/// </summary>
		public FriendStatus FriendStatus { get; set; }

		/// <summary>
		/// Информация о карьере пользователя.
		/// </summary>
		public Collection<Career> Career { get; set; }

        /// <summary>
        /// Информация о военной службе пользователя.
        /// </summary>
        public Military Military { get; set; }

		/// <summary>
		/// Возвращается 1, если текущий пользователь находится в черном списке у запрашиваемого пользователя.
		/// </summary>
		public bool Blacklisted { get; set; }

		/// <summary>
		/// Возвращается 1, если запрашиваемый пользователь находится в черном списке у текущего пользователя.
		/// </summary>
		public bool BlacklistedByMe { get; set; }
		#endregion

		#region Методы

		internal static User FromJson(VkResponse response)
		{
			var user = new User
			{
				Id = response["user_id"] ?? response["uid"] ?? response["id"] ?? 0,
				FirstName = response["first_name"],
				LastName = response["last_name"],
				Sex = response["sex"],
				BirthDate = response["bdate"],
				City = response["city"],
				Country = response["country"],
				PhotoPreviews = response,
				Online = response["online"],
				FriendLists = response["lists"],
				Domain = response["domain"],
				HasMobile = response["has_mobile"],
				MobilePhone = response["mobile_phone"] ?? response["phone"],
				HomePhone = response["home_phone"],
				Connections = response,
				Site = response["site"],
				Education = response,
				Universities = response["universities"],
				Schools = response["schools"],
				CanPost = response["can_post"],
				CanSeeAllPosts = response["can_see_all_posts"],
				CanSeeAudio = response["can_see_audio"],
				CanWritePrivateMessage = response["can_write_private_message"],
				Status = response["status"],
				LastSeen = response["last_seen"],
				CommonCount = response["common_count"],
				Relation = response["relation"],
				Relatives = response["relatives"],
				Counters = response["counters"],
				ScreenName = response["screen_name"],
				Nickname = response["nickname"],
				Timezone = response["timezone"],
				Language = response["language"],
				OnlineMobile = response["online_mobile"],
				OnlineApp = response["online_app"],
				RelationPartner = response["relation_partner"],
				StandInLife = response["personal"],
				Interests = response["interests"],
				Music = response["music"],
				Activities = response["activities"],
				Movies = response["movies"],
				Tv = response["tv"],
				Books = response["books"],
				Games = response["games"],
				About = response["about"],
				Quotes = response["quotes"],
				InvitedBy = response["invited_by"],
				BanInfo = response["ban_info"],
				Deactivated = response["deactivated"],
				MaidenName = response["maiden_name"],
				BirthdayVisibility = response["bdate_visibility"],
				HomeTown = response["home_town"],
				ChangeNameRequest = response["name_request"],
				BdateVisibility = response["bdate_visibility"],
				Contacts = response["contacts"],
				Hidden = response["hidden"],
				PhotoId = response["photo_id"],
				Verified = response["verified"],
				HasPhoto = response["has_photo"],
				Photo50 = response["photo_50"],
				Photo100 = response["photo_100"],
				Photo200Orig = response["photo_200_orig"],
				Photo200 = response["photo_200"],
				Photo400Orig = response["photo_400_orig"],
				PhotoMax = response["photo_max"],
				PhotoMaxOrig = response["photo_max_orig"],
				FollowersCount = response["followers_count"],
				Occupation = response["occupation"],
				Exports = response["exports"],
				WallComments = response["wall_comments"],
				CanSendFriendRequest = response["can_send_friend_request"],
				IsFavorite = response["is_favorite"],
				IsHiddenFromFeed = response["is_hidden_from_feed"],
				CropPhoto = response["crop_photo"],
				IsFriend = response["is_friend"] == "1",
				FriendStatus = response["friend_status"],
				Career = response["career"],
				Military = response["military"],
				Blacklisted = response["blacklisted"],
				BlacklistedByMe = response["blacklisted_by_me"]
			};
			user.IsDeactivated = user.Deactivated != null;
			if (response["name"] != null)
			{
				// Разделить имя и фамилию
				var parts = ((string)response["name"]).Split(' ');
				if (parts.Length < 2)
				{
					throw new VkApiException("Invalid name in response");
				}

				user.FirstName = parts[0];
				user.LastName = parts[1];
			}

		    if (user.BirthDate != null && response["bdate_visibility"] == null)
		    {
		        var parts = user.BirthDate.Split('.');
		        user.BirthdayVisibility = parts.Length > 2 ? Enums.BirthdayVisibility.Full : Enums.BirthdayVisibility.OnlyDayAndMonth;
		    }

		    return user;
		}

		#endregion
	}
}