﻿using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Информация о вики-странице сообщества.
	/// См. описание <see href="http://vk.com/dev/pages.get"/>.
	/// </summary>
	[Serializable]
	public class Page : MediaAttachment
    {
		/// <summary>
		/// Опрос.
		/// </summary>
		static Page()
		{
			RegisterType(typeof(Page), "page");
		}
		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		public long? GroupId {
	        get { return OwnerId; }
	        set { OwnerId = value; }
        }

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

		/// <summary>
		/// Адрес страницы для отображения вики-страницы.
		/// </summary>
		public string ViewUrl { get; set; }

		/// <summary>
		/// Gets or sets the version created.
		/// </summary>
		public string VersionCreated { get; set; }

		/// <summary>
		/// Количество просмотров вики-страницы.
		/// </summary>
		public long? Views { get; set; }
		#endregion

		#region Методы

		internal static Page FromJson(VkResponse response)
		{
			var page = new Page
			{
				Id = response["page_id"] ?? response["pid"] ?? response["id"],
				GroupId = response["group_id"] ?? response["gid"],
				CreatorId = response["creator_id"],
				Title = response["title"],
				Source = response["source"],
				CurrentUserCanEdit = response["current_user_can_edit"],
				CurrentUserCanEditAccess = response["current_user_can_edit_access"],
				WhoCanView = response["who_can_view"],
				WhoCanEdit = response["who_can_edit"],
				EditorId = response["editor_id"],
				Edited = response["edited"],
				CreateTime = response["created"],
				Parent = response["parent"],
				Parent2 = response["parent2"],
				Html = response["html"],
				ViewUrl = response["view_url"],
				VersionCreated = response["version_created"],
				Views = response["views"]
			};
			return page;
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			return string.Format("page-{0}_{1}", GroupId, Id);
		}

        #endregion
    }
}
