using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// История
/// </summary>
[Serializable]
public class Story : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "story";

	/// <summary>
	/// Дата добавления в Unixtime.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// <c>true</c>, если срок хранения истории истёк.
	/// </summary>
	[JsonProperty("is_expired")]
	public bool? IsExpired { get; set; }

	/// <summary>
	/// <c>true</c>, если история удалена или не существует.
	/// </summary>
	[JsonProperty("is_deleted")]
	public bool? IsDeleted { get; set; }

	/// <summary>
	/// Информация о том, может ли пользователь просмотреть историю.
	/// </summary>
	[JsonProperty("can_see")]
	public bool CanSee { get; set; }

	/// <summary>
	/// <c>true</c>, если история просмотрена текущим пользователем.
	/// </summary>
	[JsonProperty("seen")]
	public bool? Seen { get; set; }

	/// <summary>
	/// Тип истории.
	/// </summary>
	[JsonProperty("type")]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public StoryType Type { get; set; }

	/// <summary>
	/// Фотография из истории.
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Видео из истории.
	/// </summary>
	[JsonProperty("video")]
	public Video Video { get; set; }

	/// <summary>
	/// Ссылка для перехода из истории.
	/// </summary>
	[JsonProperty("link")]
	public StoryLink Link { get; set; }

	/// <summary>
	/// Идентификатор пользователя, загрузившего историю, ответом на которую является
	/// текущая.
	/// </summary>
	[JsonProperty("parent_story_owner_id")]
	public long? ParentStoryOwnerId { get; set; }

	/// <summary>
	/// Идентификатор истории, ответом на которую является текущая.
	/// </summary>
	[JsonProperty("parent_story_id")]
	public long? ParentStoryId { get; set; }

	/// <summary>
	/// Родительская история.
	/// </summary>
	[JsonProperty("parent_story")]
	public Story ParentStory { get; set; }

	/// <summary>
	/// Информация об ответах на текущую историю.
	/// </summary>
	[JsonProperty("replies")]
	public StoryReplies Replies { get; set; }

	/// <summary>
	/// Информация о том, может ли пользователь ответить на историю .
	/// </summary>
	[JsonProperty("can_reply")]
	public bool? CanReply { get; set; }

	/// <summary>
	/// Информация о том, может ли пользователь расшарить историю.
	/// </summary>
	[JsonProperty("can_share")]
	public bool? CanShare { get; set; }

	/// <summary>
	/// Информация о том, может ли пользователь комментировать историю.
	/// </summary>
	[JsonProperty("can_comment")]
	public bool? CanComment { get; set; }

	/// <summary>
	/// Число просмотров.
	/// </summary>
	[JsonProperty("views")]
	public int? Views { get; set; }
}