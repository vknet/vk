using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о чате.
	/// </summary>
	[Serializable]
	public class ChatPreviewField
	{
		/// <summary>
		/// Идентификатор создателя чата
		/// </summary>
		[JsonProperty(propertyName: "admin_id")]
		public long AdminId { get; set; }

		/// <summary>
		/// Массив идентификаторов участников чата
		/// </summary>
		[JsonProperty(propertyName: "members")]
		public IEnumerable<long> Members { get; set; }

		/// <summary>
		/// Название чата
		/// </summary>
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }

		/// <summary>
		/// Обложка чата
		/// </summary>
		[JsonProperty(propertyName: "photo")]
		public ChatPhoto Photo { get; set; }

		/// <summary>
		/// Идентификатор чата для текущего пользователя
		/// </summary>
		[JsonProperty(propertyName: "local_id")]
		public int LocalId { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static ChatPreviewField FromJson(VkResponse response)
		{
			return new ChatPreviewField
			{
					AdminId = response[key: "admin_id"]
					, Members = response[key: "members"].ToReadOnlyCollectionOf<long>(selector: x => x)
					, Title = response[key: "title"]
					, Photo = response[key: "photo"]
					, LocalId = response[key: "local_id"]
			};
		}

	#endregion
	}
}