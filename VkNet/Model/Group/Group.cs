using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VkNet.Model
{
	using System;
    using System.Diagnostics;

    using Enums.SafetyEnums;
    using Categories;
	using Enums;
	using Utils;

    /// <summary>
    /// Информация о сообществе (группе).
    /// См. описание <see href="http://vk.com/dev/fields_groups"/>.
    /// </summary>
    [DebuggerDisplay("[{Id}] {Name}")]
    [Serializable]
    public class Group
	{
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
		/// Короткий адрес страницы сообщества, например, apiclub. Если он не назначен, то 'club'+gid, например, club35828305.
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Публичность группы.
		/// </summary>
		public GroupPublicity? IsClosed { get; set; }

        [NonSerialized]
        private bool _IsAdmin;
		/// <summary>
		/// Признак яляется ли текущий пользователь руководителем сообщества.
		/// </summary>
		public bool IsAdmin { get { return _IsAdmin; } set { _IsAdmin = value; } }

        [NonSerialized]
        private AdminLevel? _AdminLevel;
		/// <summary>
		/// Уровень административных полномочий текущего пользователя в сообществе (действительно, если IsAdmin = true).
		/// </summary>
		public AdminLevel? AdminLevel { get { return _AdminLevel; } set { _AdminLevel = value; } }

        [NonSerialized]
        private bool? _IsMember;
		/// <summary>
		/// Признак является ли текущий пользователь участником сообщества.
		/// </summary>
		public bool? IsMember { get { return _IsMember; } set { _IsMember = value; } }

		/// <summary>
		/// Тип сообщества.
		/// </summary>
		public GroupType Type { get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий сообщества.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

		#endregion

		#region Опциональные поля

		/// <summary>
		/// Город. 
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной в информации о сообществе. Возвращается идентификатор страны, который можно использовать для 
		/// получения ее названия с помощью метода <see cref="DatabaseCategory.GetCountriesById"/>. Если страна не указана, возвращается 0.
		/// </summary>
		public ulong? CountryId { get; set; }

		/// <summary>
		/// Место, указанное в информации о сообществе.
		/// </summary>
		public Place Place { get; set; }

		/// <summary>
		/// Текст описания сообщества. 
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Название главной вики-страницы сообщества.
		/// </summary>
		public string WikiPage { get; set; }

        [NonSerialized]
        private int? _MemberCount;
        /// <summary>
		/// Количество участников сообщества. 
		/// </summary>
		public int? MembersCount { get { return _MemberCount; } set { _MemberCount = value; } }

        [NonSerialized]
        private Counters _Counters;
		/// <summary>
		/// Счетчики сообщества.
		/// </summary>
		public Counters Counters { get { return _Counters; } set { _Counters = value; } }

		/// <summary>
		/// Время начала встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Время окончания встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? EndDate { get; set; }

        [NonSerialized]
        private bool _CanPost;
		/// <summary>
		/// Информация о том, может ли текущий пользователь оставлять записи на стене сообщества (<c>true</c> - может, <c>false</c> - не может).
		/// </summary>
		public bool CanPost { get { return _CanPost; } set { _CanPost = value; } }

        [NonSerialized]
        private bool _CanSeeAllPosts;
		/// <summary>
		/// Информация о том, разрешено видеть чужие записи на стене группы (<c>true</c> - разрешено, <c>false</c> - не разрешено).
		/// </summary>
		public bool CanSeelAllPosts { get { return _CanSeeAllPosts; } set { _CanSeeAllPosts = value; } }

        [NonSerialized]
        private bool _CanUploadDocuments;
		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать документы в группу (<c>true</c>, если пользователь может 
		/// загружать документы, <c>false</c> – если не может).
		/// </summary>
		public bool CanUploadDocuments { get { return _CanUploadDocuments; } set { _CanUploadDocuments = value; } }

        [NonSerialized]
        private bool _CanCreateTopic;
		/// <summary>
		/// Информация о том, может ли текущий пользователь создать тему обсуждения в группе. 
		/// (<c>true</c>, если пользователь может создать обсуждение, <c>false</c> – если не может). 
		/// </summary>
		public bool CanCreateTopic { get { return _CanCreateTopic; } set { _CanCreateTopic = value; } }

		/// <summary>
		/// Строка состояния публичной страницы. У групп возвращается строковое значение, открыта ли группа или нет, 
		/// а у событий дата начала. 
		/// </summary>
		public string Activity { get; set; }

		/// <summary>
		/// Статус сообщества. Возвращается строка, содержащая текст статуса, расположенного на странице сообщества под его названием. 
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// Информация из блока контактов публичной страницы.
		/// </summary>
		public Collection<Contact> Contacts { get; set; }

		/// <summary>
		/// Информация из блока ссылок сообщества.
		/// </summary>
		public Collection<ExternalLink> Links { get; set; }

        [NonSerialized]
        private long? _FixedPostId;
		/// <summary>
		/// Идентификатор закрепленного поста сообщества. Сам пост можно получить, используя <see cref="WallCategory.GetById(IEnumerable{KeyValuePair{long, long}})"/>,
		/// передав идентификатор в виде – {group_id}_{post_id}.
		/// </summary>
		public long? FixedPostId { get { return _FixedPostId; } set { _FixedPostId = value; } }

		/// <summary>
		/// Возвращает информацию о том, является ли сообщество верифицированным.
		/// </summary>
		public bool IsVerified { get; set; }

		/// <summary>
		/// Адрес сайта из поля «веб-сайт» в описании сообщества.
		/// </summary>
		public string Site { get; set; }

        [NonSerialized]
        private long? _InvitedBy;
		/// <summary>
		/// Идентификатор пользователя пригласившего в группу
		/// </summary>
		public long? InvitedBy { get { return _InvitedBy; } set { _InvitedBy = value; } }

        [NonSerialized]
        private bool _IsFavorite;
		/// <summary>
		/// Возвращается 1, если сообщество находится в закладках у текущего пользователя.
		/// </summary>
		public bool IsFavorite { get { return _IsFavorite; } set { _IsFavorite = value; } }

        [NonSerialized]
        private BanInfo _BanInfo;
		/// <summary>
		/// Информация о забанненом (добавленном в черный список) пользователе сообщества.
		/// </summary>
		public BanInfo BanInfo { get { return _BanInfo; } set { _BanInfo = value; } }
		#endregion

		#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Group FromJson(VkResponse response)
		{
			var group = new Group
			{
				Id = response["id"] ?? response["gid"],
				Name = response["name"],
				ScreenName = response["screen_name"],
				IsClosed = response["is_closed"],
				IsAdmin = response["is_admin"],
				AdminLevel = response["admin_level"],
				IsMember = response["is_member"],
				Type = response["type"],
				PhotoPreviews = response,

				// опциональные поля
				City = response["city"],
				CountryId = response.ContainsKey("country") ? response["country"]["id"] : null,
				Place = response["place"],
				Description = response["description"],
				WikiPage = response["wiki_page"],
				MembersCount = response["members_count"],
				Counters = response["counters"],
				StartDate = response["start_date"],
				EndDate = response["finish_date"] ?? response["end_date"],
				CanPost = response["can_post"],
				CanSeelAllPosts = response["can_see_all_posts"],
				CanUploadDocuments = response["can_upload_doc"],
				CanCreateTopic = response["can_create_topic"],
				Activity = response["activity"],
				Status = response["status"],
				Contacts = response["contacts"],
				Links = response["links"],
				FixedPostId = response["fixed_post"],
				IsVerified = response["verified"],
				Site = response["site"],
				InvitedBy = response["invited_by"],
				IsFavorite = response["is_favorite"],
				BanInfo = response["ban_info"]
			};

			return group;
		}



		#endregion
	}
}