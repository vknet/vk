using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

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
    /// См. описание http://vk.com/dev/fields_groups
    /// </summary>
    [DebuggerDisplay("[{Id}] {Name}")]
    [Serializable]
    public class Group : IVkModel
	{
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="gag">Заглушка для конструктора.</param>
        public Group(bool gag = true)
        {
            Type = new GroupType();
        }

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

		/// <summary>
		/// Признак яляется ли текущий пользователь руководителем сообщества.
		/// </summary>
		public bool IsAdmin { get; set; }

		/// <summary>
		/// Уровень административных полномочий текущего пользователя в сообществе (действительно, если IsAdmin = true).
		/// </summary>
		public AdminLevel? AdminLevel { get; set; }

		/// <summary>
		/// Признак является ли текущий пользователь участником сообщества.
		/// </summary>
		public bool? IsMember { get; set; }

		/// <summary>
		/// Тип сообщества.
		/// </summary>
		public GroupType Type { get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий сообщества.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

		/// <summary>
		/// Возвращается в случае, если сообщество удалено или заблокировано
		/// </summary>
		public Deactivated Deactivated { get; set; }

		/// <summary>
		/// Содержит фото.
		/// </summary>
		public bool HasPhoto { get; set; }

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
		/// Город.
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной в информации о сообществе. Возвращается идентификатор страны, который можно использовать для
		/// получения ее названия с помощью метода DatabaseCategory.GetCountriesById
		/// </summary>
		public Country Country { get; set; }

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

		/// <summary>
		/// Количество участников сообщества.
		/// </summary>
		public int? MembersCount { get; set; }

		/// <summary>
		/// Счетчики сообщества.
		/// </summary>
		public Counters Counters {  get; set; }

		/// <summary>
		/// Время начала встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Время окончания встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь оставлять записи на стене сообщества (<c>true</c> - может, <c>false</c> - не может).
		/// </summary>
		public bool CanPost { get; set; }

		/// <summary>
		/// Информация о том, разрешено видеть чужие записи на стене группы (<c>true</c> - разрешено, <c>false</c> - не разрешено).
		/// </summary>
		public bool CanSeelAllPosts { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать документы в группу (<c>true</c>, если пользователь может
		/// загружать документы, <c>false</c> – если не может).
		/// </summary>
		public bool CanUploadDocuments  { get; set; }
		/// <summary>
		/// Информация о том, может ли текущий пользователь создать тему обсуждения в группе.
		/// (<c>true</c>, если пользователь может создать обсуждение, <c>false</c> – если не может).
		/// </summary>
		public bool CanCreateTopic { get; set; }

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
		/// <summary>
		/// Идентификатор закрепленного поста сообщества. Сам пост можно получить, используя WallCategory.GetById
		/// передав идентификатор в виде – {group_id}_{post_id}.
		/// </summary>
		public long? FixedPostId { get; set; }

		/// <summary>
		/// Возвращает информацию о том, является ли сообщество верифицированным.
		/// </summary>
		public bool IsVerified { get; set; }

		/// <summary>
		/// Адрес сайта из поля «веб-сайт» в описании сообщества.
		/// </summary>
		public string Site { get; set; }

		/// <summary>
		/// Идентификатор пользователя пригласившего в группу
		/// </summary>
		public long? InvitedBy { get; set; }

		/// <summary>
		/// Возвращается 1, если сообщество находится в закладках у текущего пользователя.
		/// </summary>
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Информация о забанненом (добавленном в черный список) пользователе сообщества.
		/// </summary>
		public BanInfo BanInfo { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать видеозаписи в группу.
		/// </summary>
		public bool CanUploadVideo { get; set; }

		/// <summary>
		/// Идентификатор основного альбома сообщества.
		/// </summary>
		public uint? MainAlbumId { get; set; }

		/// <summary>
		/// Возвращается 1, если сообщество скрыто в новостях у текущего пользователя.
		/// </summary>
		public bool IsHiddenFromFeed { get; set; }

		/// <summary>
		/// Информация о главной секции в сообществе
		/// </summary>
		public MainSection? MainSection { get; set; }

        /// <summary>
        /// Информация о том, разрешено ли сообществу отправлять сообщения текущему пользователю.
        /// </summary>
        public bool? IsMessagesAllowed { get; set; }
		
		/// <summary>
		/// Информация о том, есть ли у сообщества «огонёк».
		/// </summary>
		public bool Trending { get; set; }
        #endregion

        #region Методы

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
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
				BanInfo = response["ban_info"],
				CanUploadVideo = response["can_upload_video"],
				MainAlbumId = response["main_album_id"],
				IsHiddenFromFeed = response["is_hidden_from_feed"],
				MainSection = response["main_section"],
                IsMessagesAllowed = response["is_messages_allowed"],
				Trending = response["trending"]
            };

			return group;
		}

		#endregion

	    /// <summary>
	    /// Преобразовать из JSON
	    /// </summary>
	    /// <param name="response">Ответ от сервера.</param>
	    /// <returns></returns>
	    IVkModel IVkModel.FromJson(VkResponse response)
	    {
		    return FromJson(response);
	    }
	}
}