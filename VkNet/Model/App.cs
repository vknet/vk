using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	/// <summary>
	/// Приложение.
	/// </summary>
	public class App
	{
		/// <summary>
		/// Идентификатор приложения.
		/// </summary>
		public ulong Id
		{ get; set; }

		/// <summary>
		/// Название приложения.
		/// </summary>
		public string Title
		{ get; set; }

        /// <summary>
        /// Uri-адрес обложки приложения шириной 278px.
        /// </summary>
        public string Icon278
		{ get; set; }

        /// <summary>
        /// Uri-адрес обложки приложения шириной 139px.
        /// </summary>
        public string Icon139
        { get; set; }

		/// <summary>
		/// Uri-адрес обложки приложения шириной 75px.
		/// </summary>
		public string Icon75
		{ get; set; }

		/// <summary>
		/// Uri-адрес обложки приложения шириной 150px.
		/// </summary>
		public string Icon150
		{ get; set; }

        /// <summary>
        /// Uri-адрес баннера шириной 560px.
        /// </summary>
        public string Banner560
        { get; set; }

        /// <summary>
        /// Uri-адрес баннера шириной 1120px.
        /// </summary>
        public string Banner1120
		{ get; set; }

		/// <summary>
		/// Тип приложения:.
		/// </summary>
		public AppType Type
		{ get; set; }

		/// <summary>
		/// Категория приложения.
		/// </summary>
		public string Section
		{ get; set; }

		/// <summary>
		/// Адрес страницы автора приложения.
		/// </summary>
		public string AuthorUrl
		{ get; set; }

		/// <summary>
		/// Идентификатор автора приложения.
		/// </summary>
		public ulong? AuthorId
		{ get; set; }

		/// <summary>
		/// Идентификатор официальной группы приложения.
		/// </summary>
		public ulong? AuthorGroup
		{ get; set; }

		/// <summary>
		/// Количество участников приложения.
		/// </summary>
		public ulong MembersCount
		{ get; set; }

		/// <summary>
		/// Дата размещения.
		/// </summary>
		public string PublishedDate
		{ get; set; }

		/// <summary>
		/// Позиция в каталоге.
		/// </summary>
		public ulong? CatalogPosition
		{ get; set; }

		/// <summary>
		/// Является ли приложение мультиязычным (<c>true</c>).
		/// </summary>
		public bool International
		{ get; set; }

		/// <summary>
		/// Тип турнирной таблицы (0 - не поддерживается, 1 - по уровню, 2 - по очкам).
		/// </summary>
		public LeaderboardTypes LeaderBoardType
		{ get; set; }

		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int? GenreId
		{ get; set; }

		/// <summary>
		/// Название жанра.
		/// </summary>
		public string Genre
		{ get; set; }

		/// <summary>
		/// Идентификатор приложения в магазине приложений.
		/// </summary>
		public int? PlatformId
		{ get; set; }

        /// <summary>
        /// Доступно ли приложение в мобильном каталоге.
        /// </summary>
        public bool? IsInCatalog { get; set; }

        #region Опциональные поля
        /// <summary>
        /// Поддомен приложения (или строка idXXXXXXX, если поддомен не задан).
        /// </summary>
        public string ScreenName
        { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// Uri-адрес обложки приложения шириной 16px.
        /// </summary>
        public string Icon16
        { get; set; }

        /// <summary>
        /// Uri-адреса изображений-скриншотов из приложения.
        /// </summary>
        public IEnumerable<Photo> ScreenShots
        { get; set; }
        #endregion


        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static App FromJson(VkResponse response)
		{
			return new App
            {
                Id = response["id"],
                Title = response["title"],
                ScreenName = response["screen_name"],
                Description = response["description"],
                Icon278 = response["icon_278"],
                Icon139 = response["icon_139"],
                Icon75 = response["icon_75"],
                Icon150 = response["icon_150"],
                Icon16 = response["icon_16"],
                Banner560 = response["banner_560"],
                Banner1120 = response["banner_1120"],
                Type = response["type"],
                Section = response["section"],
                AuthorUrl = response["author_url"],
                AuthorId = response["author_id"],
                AuthorGroup = response["author_group"],
                MembersCount = response["members_count"],
                PublishedDate = response["published_date"],
                CatalogPosition = response["catalog_position"],
                ScreenShots = response["screenshots"].ToReadOnlyCollectionOf<Photo>(o => o),
                International = response["international"],
                LeaderBoardType = response["leaderboard_type"],
                GenreId = response["genre_id"],
                Genre = response["genre"],
                PlatformId = response["platform_id"],
                IsInCatalog = response["is_in_catalog"]
            };
        }
	}
}
