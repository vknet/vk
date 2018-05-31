using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Приложение.
	/// </summary>
	[Serializable]
	public class App
	{
		/// <summary>
		/// Идентификатор приложения.
		/// </summary>
		public ulong Id { get; set; }

		/// <summary>
		/// Название приложения.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Uri-адрес обложки приложения шириной 278px.
		/// </summary>
		public string Icon278 { get; set; }

		/// <summary>
		/// Uri-адрес обложки приложения шириной 139px.
		/// </summary>
		public string Icon139 { get; set; }

		/// <summary>
		/// Uri-адрес обложки приложения шириной 150px.
		/// </summary>
		public string Icon150 { get; set; }

		/// <summary>
		/// Uri-адрес обложки приложения шириной 75px.
		/// </summary>
		public string Icon75 { get; set; }

		/// <summary>
		/// Uri-адрес баннера шириной 560px.
		/// </summary>
		public string Banner560 { get; set; }

		/// <summary>
		/// Uri-адрес баннера шириной 1120px.
		/// </summary>
		public string Banner1120 { get; set; }

		/// <summary>
		/// Тип приложения:.
		/// </summary>
		public AppType Type { get; set; }

		/// <summary>
		/// Категория приложения.
		/// </summary>
		public string Section { get; set; }

		/// <summary>
		/// Адрес страницы автора приложения.
		/// </summary>
		public string AuthorUrl { get; set; }

		/// <summary>
		/// Идентификатор автора приложения.
		/// </summary>
		public ulong? AuthorId { get; set; }

		/// <summary>
		/// Идентификатор официальной группы приложения.
		/// </summary>
		public ulong? AuthorGroup { get; set; }

		/// <summary>
		/// Количество участников приложения.
		/// </summary>
		public ulong MembersCount { get; set; }

		/// <summary>
		/// Дата размещения.
		/// </summary>
		public string PublishedDate { get; set; }

		/// <summary>
		/// Позиция в каталоге.
		/// </summary>
		public ulong? CatalogPosition { get; set; }

		/// <summary>
		/// Является ли приложение мультиязычным (<c> true </c>).
		/// </summary>
		public bool International { get; set; }

		/// <summary>
		/// Тип турнирной таблицы (0 - не поддерживается, 1 - по уровню, 2 - по очкам).
		/// </summary>
		public LeaderboardTypes LeaderBoardType { get; set; }

		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int? GenreId { get; set; }

		/// <summary>
		/// Название жанра.
		/// </summary>
		public string Genre { get; set; }

		/// <summary>
		/// Идентификатор приложения в магазине приложений.
		/// </summary>
		public int? PlatformId { get; set; }

		/// <summary>
		/// Доступно ли приложение в мобильном каталоге.
		/// </summary>
		public bool? IsInCatalog { get; set; }

		/// <summary>
		/// список идентификаторов друзей текущего пользователя, которые установили
		/// приложение
		/// (если был передан параметр return_friends = 1.
		/// </summary>
		[JsonProperty(propertyName: "friends")]
		public ReadOnlyCollection<long> Friends { get; set; }

		/// <summary>
		/// 1, если приложение установлено у текущего пользователя.
		/// </summary>
		[JsonProperty(propertyName: "installed")]
		public bool? Installed { get; set; }

		/// <summary>
		/// 1, если приложение — html5 игра.
		/// </summary>
		[JsonProperty(propertyName: "is_html_5_app")]
		public bool IsHtml5App { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static App FromJson(VkResponse response)
		{
			return new App
			{
					Id = response[key: "id"]
					, Title = response[key: "title"]
					, ScreenName = response[key: "screen_name"]
					, Description = response[key: "description"]
					, Icon278 = response[key: "icon_278"]
					, Icon139 = response[key: "icon_139"]
					, Icon75 = response[key: "icon_75"]
					, Icon150 = response[key: "icon_150"]
					, Icon16 = response[key: "icon_16"]
					, Banner560 = response[key: "banner_560"]
					, Banner1120 = response[key: "banner_1120"]
					, Type = response[key: "type"]
					, Section = response[key: "section"]
					, AuthorUrl = response[key: "author_url"]
					, AuthorId = response[key: "author_id"]
					, AuthorGroup = response[key: "author_group"]
					, MembersCount = response[key: "members_count"]
					, PublishedDate = response[key: "published_date"]
					, CatalogPosition = response[key: "catalog_position"]
					, Screenshots = response[key: "screenshots"].ToReadOnlyCollectionOf<Photo>(selector: o => o)
					, International = response[key: "international"]
					, LeaderBoardType = response[key: "leaderboard_type"]
					, GenreId = response[key: "genre_id"]
					, Genre = response[key: "genre"]
					, PlatformId = response[key: "platform_id"]
					, IsInCatalog = response[key: "is_in_catalog"]
					, Friends = response[key: "friends"].ToReadOnlyCollectionOf<long>(selector: x => x)
					, Installed = response[key: "installed"]
					, IsHtml5App = response[key: "is_html_5_app"]
					, PushEnabled = response[key: "push_enabled"]
			};
		}

	#region Опциональные поля

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Поддомен приложения (или строка idXXXXXXX, если поддомен не задан).
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Uri-адрес обложки приложения шириной 16px.
		/// </summary>
		public string Icon16 { get; set; }

		/// <summary>
		/// Uri-адреса изображений-скриншотов из приложения.
		/// </summary>
		public IEnumerable<Photo> Screenshots { get; set; }

		/// <summary>
		/// 1, если у пользователя включены уведомления из этого приложения.
		/// </summary>
		[JsonProperty(propertyName: "push_enabled")]
		public bool? PushEnabled { get; set; }

	#endregion
	}
}