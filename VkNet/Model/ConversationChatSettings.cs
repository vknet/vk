using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Беседа настройки чата.
	/// </summary>
	[Serializable]
	public class ConversationChatSettings
	{
		/// <summary>
		/// Число участников;
		/// </summary>
		[JsonProperty("members_count")]
		public long MembersCount { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Объект содержит информацию о закреплённом сообщении в беседе.
		/// </summary>
		[JsonProperty("pinned_message")]
		public PinnedMessage PinnedMessage { get; set; }

		/// <summary>
		/// Статус текущего пользователя.
		/// </summary>
		[JsonProperty("state")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public ConversationChatSettingsState State { get; set; }

		/// <summary>
		/// Изображение-обложка чата.
		/// </summary>
		[JsonProperty("photo")]
		public Photo Photo { get; set; }

		/// <summary>
		/// Идентификаторы последних пользователей, писавших в чат.
		/// </summary>
		[JsonProperty("active_ids")]
		public ReadOnlyCollection<long> ActiveIds { get; set; }

		/// <summary>
		/// Идентификаторы администраторов чата.
		/// </summary>
		[JsonProperty("admin_ids")]
		public ReadOnlyCollection<long> AdminIds { get; set; }

		/// <summary>
		/// Идентификатор владельца чата
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Признак группового канала
		/// </summary>
		[JsonProperty("is_group_channel")]
		public bool IsGroupChannel { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("acl")]
		public Acl Acl { get; set; }
	}
}