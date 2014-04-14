using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Информация о вики-странице сообщества. 
    /// См. описание <see href="http://vk.com/dev/pages.get"/>.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Идентификатор страницы.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор сообщества.
        /// </summary>
        public long? GroupId { get; set; }

        /// <summary>
        /// Идентификатор создателя страницы.
        /// </summary>
        public long? CreatorId { get; set; }

        /// <summary>
        /// Название страницы.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст страницы в вики-формате.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Указывает, может ли текущий пользователь редактировать текст страницы.
        /// </summary>
        public bool CurrentUserCanEdit { get; set; }

        /// <summary>
        /// Указывает, может ли текущий пользователь изменять права доступа на страницу.
        /// </summary>
        public bool CurrentUserCanEditAccess { get; set; }

        /// <summary>
        /// Указывает, кто может просматривать вики-страницу.
        /// </summary>
        public PageAccessKind? WhoCanView { get; set; }

        /// <summary>
        /// Указывает, кто может редактировать вики-страницу.
        /// </summary>
        public PageAccessKind? WhoCanEdit { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который редактировал страницу последним.
        /// </summary>
        public long? EditorId { get; set; }

        /// <summary>
        /// Дата последнего изменения (в виде строки).
        /// </summary>
        public string Edited { get; set; }

        /// <summary>
        /// Дата создания страницы (в виде строки).
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// Заголовок родительской страницы для навигации, если есть.
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// Заголовок второй родительской страницы для навигации, если есть.
        /// </summary>
        public string Parent2 { get; set; }

        #region Поля, установленные экспериментально

        /// <summary>
        /// Html-текст страницы.
        /// </summary>
        public string Html { get; set; }

        #endregion

        #region Методы

        internal static Page FromJson(VkResponse response)
        {
            var page = new Page();

            page.Id = response["pid"];
            page.GroupId = response["group_id"] ?? response["gid"];
            page.CreatorId = response["creator_id"];
            page.Title = response["title"];
            page.Source = response["source"];
            page.CurrentUserCanEdit = response["current_user_can_edit"];
            page.CurrentUserCanEditAccess = response["current_user_can_edit_access"];
            page.WhoCanView = response["who_can_view"];
            page.WhoCanEdit = response["who_can_edit"];
            page.EditorId = response["editor_id"];
            page.Edited = response["edited"];
            page.CreateTime = response["created"];
            page.Parent = response["parent"];
            page.Parent2 = response["parent2"];

            page.Html = response["html"]; // установлено экcпериментальным путем

            return page;
        }

		public override string ToString()
		{
			return string.Format("page{0}_{1}", GroupId, Id);
		}

        #endregion
    }
}