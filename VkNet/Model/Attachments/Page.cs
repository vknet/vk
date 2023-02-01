using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.Attachments;

/// <summary>
/// Информация о вики-странице сообщества.
/// См. описание http://vk.com/dev/pages.get
/// </summary>
[Serializable]
public class Page : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "page";

	/// <summary>
	/// Идентификатор сообщества.
	/// </summary>
	[JsonProperty("group_id")]
	public long? GroupId { get; set; }

	/// <summary>
	/// Идентификатор создателя страницы.
	/// </summary>
	[JsonProperty("creator_id")]
	public long? CreatorId { get; set; }

	/// <summary>
	/// Название страницы.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Указывает, может ли текущий пользователь редактировать текст страницы.
	/// </summary>
	[JsonProperty("current_user_can_edit")]
	public bool CurrentUserCanEdit { get; set; }

	/// <summary>
	/// Указывает, может ли текущий пользователь изменять права доступа на страницу.
	/// </summary>
	[JsonProperty("current_user_can_edit_access")]
	public bool CurrentUserCanEditAccess { get; set; }

	/// <summary>
	/// Указывает, кто может просматривать вики-страницу.
	/// </summary>
	[JsonProperty("who_can_view")]
	public PageAccessKind? WhoCanView { get; set; }

	/// <summary>
	/// Указывает, кто может редактировать вики-страницу.
	/// </summary>
	[JsonProperty("who_can_edit")]
	public PageAccessKind? WhoCanEdit { get; set; }

	/// <summary>
	/// Дата последнего изменения (в виде строки).
	/// </summary>
	[JsonProperty("edited")]
	public string Edited { get; set; }

	/// <summary>
	/// Дата создания страницы (в виде строки).
	/// </summary>
	[JsonProperty("created")]
	public string Created { get; set; }

	/// <summary>
	/// Идентификатор пользователя, который редактировал страницу последним.
	/// </summary>
	[JsonProperty("editor_id")]
	public long? EditorId { get; set; }

	/// <summary>
	/// Количество просмотров вики-страницы.
	/// </summary>
	[JsonProperty("views")]
	public long? Views { get; set; }

	/// <summary>
	/// Заголовок родительской страницы для навигации,если есть.
	/// </summary>
	[JsonProperty("parent")]
	public string Parent { get; set; }

	/// <summary>
	/// Заголовок второй родительской страницы для навигации, если есть.
	/// </summary>
	[JsonProperty("parent2")]
	public string Parent2 { get; set; }

	/// <summary>
	/// Текст страницы в вики-формате.
	/// </summary>
	[JsonProperty("source")]
	public string Source { get; set; }

	/// <summary>
	/// Html-текст страницы.
	/// </summary>
	[JsonProperty("html")]
	public string Html { get; set; }

	/// <summary>
	/// Адрес страницы для отображения вики-страницы.
	/// </summary>
	[JsonProperty("view_url")]
	public string ViewUrl { get; set; }

	#region Поля, установленные экспериментально

	/// <summary>
	/// Gets or sets the version created.
	/// </summary>
	[JsonProperty("version_created")]
	public string VersionCreated { get; set; }

	#endregion

	[JsonProperty("page_id")]
	private long? PageId
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("pid")]
	private long? Pid
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("gid")]
	private long? Gid
	{
		get => GroupId;
		set => GroupId = value;
	}

	#region Методы

	/// <summary>
	/// Разобрать из JSON
	/// </summary>
	/// <param name="response"> Ответ сервера </param>
	/// <returns> </returns>
	public static Page FromJson(VkResponse response) => new()
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
		Created = response["created"],
		Parent = response["parent"],
		Parent2 = response["parent2"],
		Html = response["html"],
		ViewUrl = response["view_url"],
		VersionCreated = response["version_created"],
		Views = response["views"]
	};

	/// <inheritdoc />
	public override string ToString() => string.Format("page-{0}_{1}",
		GroupId,
		Id);

	/// <summary>
	/// Преобразование класса <see cref="Page" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns>Результат преобразования в <see cref="Page" /></returns>
	public static implicit operator Page(VkResponse response)
	{
		if (response == null)
		{
			return null;
		}

		return response.HasToken()
			? FromJson(response)
			: null;
	}

	#endregion
}