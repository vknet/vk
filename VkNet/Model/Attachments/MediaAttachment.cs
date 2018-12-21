using System;
using Newtonsoft.Json;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Медиа вложение.
	/// </summary>
	[Serializable]
	public abstract class MediaAttachment
	{
		/// <summary>
		/// Наименование типа которое приходит от vk.com
		/// </summary>
		protected abstract string Alias { get; }

		/// <summary>
		/// Идентификатор вложенеия.
		/// </summary>
		[JsonProperty("id")]
		public long? Id { get; set; }

		/// <summary>
		/// Идентификатор владельца вложения.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Ключ доступа
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// Преобразовать вложение в строку.
		/// </summary>
		public override string ToString()
		{
			var result = $"{Alias}{OwnerId}_{Id}";

			return string.IsNullOrWhiteSpace(AccessKey)
				? result
				: $"{result}_{AccessKey}";
		}
	}
}