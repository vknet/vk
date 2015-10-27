using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	using System;

	using VkNet.Categories;
	using VkNet.Enums;
	using VkNet.Utils;

	/// <summary>
	/// Информация о сообществе (группе).
	/// См. описание <see href="http://vk.com/dev/fields_groups"/>.
	/// </summary>
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

		#endregion

		#region Опциональные поля

		/// <summary>
		/// Идентификатор города, указанного в информации о сообществе. Возвращается идентификатор города, который можно использовать для 
		/// получения его названия с помощью метода <see cref="DatabaseCategory.GetCitiesById"/>. Если город не указан, возвращается 0. 
		/// </summary>
		public long? CityId { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной в информации о сообществе. Возвращается идентификатор страны, который можно использовать для 
		/// получения ее названия с помощью метода <see cref="DatabaseCategory.GetCountriesById"/>. Если страна не указана, возвращается 0.
		/// </summary>
		public long? CountryId { get; set; }

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
		public Counters Counters { get; set; }

		/// <summary>
		/// Время начала встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Время окончания встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь оставлять записи на стене сообщества (true - может, false - не может).
		/// </summary>
		public bool CanPost { get; set; }

		/// <summary>
		/// Информация о том, разрешено видеть чужие записи на стене группы (true - разрешено, false - не разрешено).
		/// </summary>
		public bool CanSeelAllPosts { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать документы в группу (true, если пользователь может 
		/// загружать документы, false – если не может).
		/// </summary>
		public bool CanUploadDocuments { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь создать тему обсуждения в группе. 
		/// (true, если пользователь может создать обсуждение, false – если не может). 
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
		/// Идентификатор закрепленного поста сообщества. Сам пост можно получить, используя <see cref="WallCategory.GetById(IEnumerable{KeyValuePair{long, long}})"/>,
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
		#endregion

		#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Group FromJson(VkResponse response)
		{
			var group = new Group();

			group.Id = response["id"] ?? response["gid"];
			group.Name = response["name"];
			group.ScreenName = response["screen_name"];
			group.IsClosed = response["is_closed"];
			group.IsAdmin = response["is_admin"];
			group.AdminLevel = response["admin_level"];
			group.IsMember = response["is_member"];
			group.Type = response["type"];
			group.PhotoPreviews = response;

			// опциональные поля
			group.CityId = response.ContainsKey("city") ? response["city"]["id"] : null;
			group.CountryId = response.ContainsKey("country") ? response["country"]["id"] : null;
			group.Place = response["place"];
			group.Description = response["description"];
			group.WikiPage = response["wiki_page"];
			group.MembersCount = response["members_count"];
			group.Counters = response["counters"];
			group.StartDate = response["start_date"];
			group.EndDate = response["finish_date"] ?? response["end_date"];
			group.CanPost = response["can_post"];
			group.CanSeelAllPosts = response["can_see_all_posts"];
			group.CanUploadDocuments = response["can_upload_doc"];
			group.CanCreateTopic = response["can_create_topic"];
			group.Activity = response["activity"];
			group.Status = response["status"];
			group.Contacts = response["contacts"];
			group.Links = response["links"];
			group.FixedPostId = response["fixed_post"];
			group.IsVerified = response["verified"];
			group.Site = response["site"];
			group.InvitedBy = response["invited_by"];
			group.IsFavorite = response["is_favorite"];
			group.BanInfo = response["ban_info"];

			return group;
		}



		#endregion
	}
}