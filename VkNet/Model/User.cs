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
	[Serializable]
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

		[NonSerialized]
		private bool _CanPost;
		/// <summary>
		/// Признак разрешено ли оставлять записи на стене у пользователя.
		/// </summary>
		public bool CanPost { get { return _CanPost; } set { _CanPost = value; } }

		[NonSerialized]
		private bool _CanSeeAllPosts;
		/// <summary>
		/// Признак разрешено ли видеть чужие записи на стене пользователя.
		/// </summary>
		public bool CanSeeAllPosts { get { return _CanSeeAllPosts; } set { _CanSeeAllPosts = value; } }

		[NonSerialized]
		private bool _CanSeeAudio;
		/// <summary>
		/// Признак разрешено ли видеть чужие аудиозаписи на стене пользователя.
		/// </summary>
		public bool CanSeeAudio { get { return _CanSeeAudio; } set { _CanSeeAudio = value; } }

		[NonSerialized]
		private bool _CanWritePrivateMessage;
		/// <summary>
		/// Признак разрешено ли написание личных сообщений данному пользователю.
		/// </summary>
		public bool CanWritePrivateMessage { get { return _CanWritePrivateMessage; } set { _CanWritePrivateMessage = value; } }

		/// <summary>
		/// Строка со статусом пользователя.
		/// </summary>
		public string Status { get; set; }

		[NonSerialized]
		private DateTime? _LastSeen;
		/// <summary>
		/// Время последнего посещения сайта.
		/// </summary>
		public DateTime? LastSeen { get { return _LastSeen; } set { _LastSeen = value; } }

		[NonSerialized]
		private int? _CommonCount;
		/// <summary>
		/// Общее количество друзей с текущим пользователем.
		/// </summary>
		public int? CommonCount { get { return _CommonCount; } set { _CommonCount = value; } }

		/// <summary>
		/// Семейное положение.
		/// </summary>
		public RelationType Relation { get; set; }

		/// <summary>
		/// Родственники пользователя.
		/// </summary>
		public Collection<Relative> Relatives { get; set; }

		[NonSerialized]
		private Counters _Counters;
		/// <summary>
		/// Различные счетчики пользователя.
		/// </summary>
		public Counters Counters { get { return _Counters; } set { _Counters = value; } }

		[NonSerialized]
		private BanInfo _BanInfo;
		/// <summary>
		/// Информация о блокировке пользователя
		/// </summary>
		public BanInfo BanInfo { get { return _BanInfo; } set { _BanInfo = value; } }

		/// <summary>
		/// Является ли пользователь заблокированным
		/// </summary>
		public bool IsDeactivated { get; set; }

		/// <summary>
		/// Причина блокирования аккаунта
		/// </summary>
		public string DeactiveReason { get; set; }

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
		/// Gets or sets the screen_name.
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
		public BirthdayVisibility BirthdayVisibility { get; set; }

		/// <summary>
		/// Родной город пользователя.
		/// </summary>
		public string HomeTown { get; set; }

		/// <summary>
		/// Информация о заявке на смену имени.
		/// </summary>
		public ChangeNameRequest ChangeNameRequest { get; set; }

		/// <summary>
		/// Gets or sets the contact.
		/// </summary>
		public string contact { get; set; }

		/// <summary>
		/// Gets or sets the common_count.
		/// </summary>
		public long common_count { get; set; }
		#endregion

		#region Методы

		internal static User FromJson(VkResponse response)
		{
			var user = new User();

			// ---- стандартные поля ----
			user.Id = response["uid"] ?? response["id"] ?? 0;

			user.FirstName = response["first_name"];
			user.LastName = response["last_name"];

			if (response["name"] != null)
			{
				// split for name and surname
				var parts = ((string)response["name"]).Split(' ');
				if (parts.Length < 2)
					throw new VkApiException("Invalid name in response");

				user.FirstName = parts[0];
				user.LastName = parts[1];
			}

			// ---- дополнительные поля ----

			user.Sex = response["sex"];
			user.BirthDate = response["bdate"];
			user.City =response["city"];
			user.Country = response["country"];
			user.PhotoPreviews = response;
			user.Online = response["online"];
			user.FriendLists = response["lists"];
			user.Domain = response["domain"];
			user.HasMobile = response["has_mobile"];
			user.MobilePhone = response["mobile_phone"];
			user.HomePhone = response["home_phone"];
			user.Connections = response;
			user.Site = response["site"];
			user.Education = response;
			user.Universities = response["universities"];
			user.Schools = response["schools"];
			user.CanPost = response["can_post"];
			user.CanSeeAllPosts = response["can_see_all_posts"];
			user.CanSeeAudio = response["can_see_audio"];
			user.CanWritePrivateMessage = response["can_write_private_message"];
			user.Status = response["status"];
			user.LastSeen = response["last_seen"] != null ? response["last_seen"]["time"] : null;
			user.CommonCount = response["common_count"];
			user.Relation = response["relation"];
			user.Relatives = response["relatives"];
			user.Counters = response["counters"];
			user.ScreenName = response["screen_name"];
			// -- дополнительные поля из http://vk.com/pages?oid=-1p=users.get

			user.Nickname = response["nickname"];
			user.Timezone = response["timezone"];

			// поля, установленные экспериментально
			user.Language = response["language"];
			user.OnlineMobile = response["online_mobile"];
			user.OnlineApp = response["online_app"];
			user.RelationPartner = response["relation_partner"];
			user.StandInLife = response["personal"];
			user.Interests = response["interests"];
			user.Music = response["music"];
			user.Activities = response["activities"];
			user.Movies = response["movies"];
			user.Tv = response["tv"];
			user.Books = response["books"];
			user.Games = response["games"];
			user.About = response["about"];
			user.Quotes = response["quotes"];
			user.InvitedBy = response["invited_by"];
			user.BanInfo = response["ban_info"];
			user.DeactiveReason = response["deactivated"];
			user.IsDeactivated = !string.IsNullOrEmpty(user.DeactiveReason);

			//Поля, доступные через запрос https://vk.com/dev/account.getProfileInfo
			user.MaidenName = response["maiden_name"];
			user.BirthdayVisibility = (BirthdayVisibility)(response["bdate_visibility"] ?? 0);
			user.HomeTown = response["home_town"];
			user.ChangeNameRequest = response["name_request"];

			return user;
		}

		#endregion
	}
}