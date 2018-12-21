using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// История
	/// </summary>
	[Serializable]
	public class Story : MediaAttachment
	{
	#region Поля

		/// <summary>
		/// История.
		/// </summary>
		static Story()
		{
			RegisterType(typeof(Story), "story");
		}

		/// <summary>
		/// Дата добавления в Unixtime.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// true, если срок хранения истории истёк.
		/// </summary>
		[JsonProperty("is_expired")]
		public bool? IsExpired { get; set; }

		/// <summary>
		/// true, если история удалена или не существует.
		/// </summary>
		[JsonProperty("is_deleted")]
		public bool? IsDeleted { get; set; }

		/// <summary>
		/// информация о том, может ли пользователь просмотреть историю.
		/// </summary>
		[JsonProperty("can_see")]
		public bool CanSee { get; set; }

		/// <summary>
		/// true, если история просмотрена текущим пользователем.
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

		/// <summary>
		/// Ключ доступа для приватного объекта.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

	#endregion

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Story FromJson(VkResponse response)
		{
			var story = new Story
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Date = response["date"],
				IsExpired = response["is_expired"],
				IsDeleted = response["is_deleted"],
				CanSee = response["can_see"],
				Seen = response["seen"],
				Type = response["type"],
				Photo = response["photo"],
				Video = response["video"],
				Link = response["link"],
				ParentStoryOwnerId = response["parent_story_owner_id"],
				ParentStoryId = response["parent_story_id"],
				ParentStory = response["parent_story"],
				Replies = response["replies"],
				CanReply = response["can_reply"],
				CanShare = response["can_share"],
				CanComment = response["can_comment"],
				Views = response["views"],
				AccessKey = response["access_key"]
			};

			return story;
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Story(VkResponse response)
		{
			return response != null && response.HasToken()
				? FromJson(response)
				: null;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return string.IsNullOrWhiteSpace(AccessKey)
				? base.ToString()
				: $"{base.ToString()}_{AccessKey}";
		}

	#endregion
	}
}