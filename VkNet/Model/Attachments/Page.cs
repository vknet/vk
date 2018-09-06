using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Информация о вики-странице сообщества.
	/// См. описание http://vk.com/dev/pages.get
	/// </summary>
	[Serializable]
	public class Page : MediaAttachment
	{
		/// <summary>
		/// Опрос.
		/// </summary>
		static Page()
		{
			RegisterType(type: typeof(Page), match: "page");
		}

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
		/// Дата последнего изменения (в виде строки).
		/// </summary>
		public string Edited { get; set; }

		/// <summary>
		/// Дата создания страницы (в виде строки).
		/// </summary>
		public string Created { get; set; }

		/// <summary>
		/// Идентификатор пользователя, который редактировал страницу последним.
		/// </summary>
		public long? EditorId { get; set; }

		/// <summary>
		/// Количество просмотров вики-страницы.
		/// </summary>
		public long? Views { get; set; }

		/// <summary>
		/// Заголовок родительской страницы для навигации, если есть.
		/// </summary>
		public string Parent { get; set; }

		/// <summary>
		/// Заголовок второй родительской страницы для навигации, если есть.
		/// </summary>
		public string Parent2 { get; set; }

		/// <summary>
		/// Текст страницы в вики-формате.
		/// </summary>
		public string Source { get; set; }

		/// <summary>
		/// Html-текст страницы.
		/// </summary>
		public string Html { get; set; }

		/// <summary>
		/// Адрес страницы для отображения вики-страницы.
		/// </summary>
		public string ViewUrl { get; set; }

	#region Поля, установленные экспериментально

		/// <summary>
		/// Gets or sets the version created.
		/// </summary>
		public string VersionCreated { get; set; }

	#endregion

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static Page FromJson(VkResponse response)
		{
			var page = new Page
			{
					Id = response[key: "page_id"] ?? response[key: "pid"] ?? response[key: "id"]
					, GroupId = response[key: "group_id"] ?? response[key: "gid"]
					, CreatorId = response[key: "creator_id"]
					, Title = response[key: "title"]
					, Source = response[key: "source"]
					, CurrentUserCanEdit = response[key: "current_user_can_edit"]
					, CurrentUserCanEditAccess = response[key: "current_user_can_edit_access"]
					, WhoCanView = response[key: "who_can_view"]
					, WhoCanEdit = response[key: "who_can_edit"]
					, EditorId = response[key: "editor_id"]
					, Edited = response[key: "edited"]
					, Created = response[key: "created"]
					, Parent = response[key: "parent"]
					, Parent2 = response[key: "parent2"]
					, Html = response[key: "html"]
					, ViewUrl = response[key: "view_url"]
					, VersionCreated = response[key: "version_created"]
					, Views = response[key: "views"]
			};

			return page;
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			return string.Format(format: "page-{0}_{1}", arg0: GroupId, arg1: Id);
		}

	#endregion
	}
}