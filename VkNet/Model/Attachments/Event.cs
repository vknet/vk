using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Infrastructure;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Встреча
	/// </summary>
	[Serializable]
	public class Event : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "event";

		/// <summary>
		/// Время начала встречи в Unixtime
		/// </summary>
		[JsonProperty("time")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Time { get; set; }

		/// <summary>
		/// Идёт ли текущий пользователь на встречу.
		/// </summary>
		[JsonProperty("member_status")]
		public EventMemberStatus MemberStatus { get; set; }

		/// <summary>
		/// Добавлена ли встреча в закладки.
		/// </summary>
		[JsonProperty("is_favorite")]
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Место проведения встречи.
		/// </summary>
		[JsonProperty("address")]
		public string Address { get; set; }

		/// <summary>
		/// Текст для отображения сниппета.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Текст на кнопке сниппета.
		/// </summary>
		[JsonProperty("button_text")]
		public string ButtonText { get; set; }

		/// <summary>
		/// Список идентификаторов друзей, которые также идут на мероприятие.
		/// </summary>
		[JsonProperty("friends")]
		public IEnumerable<ulong> Friends { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Event FromJson(VkResponse response)
		{
			return response != null
				? JsonConvert.DeserializeObject<Event>(response.ToString(), JsonConfigure.JsonSerializerSettings)
				: null;
		}

		/// <summary>
		/// Преобразование класса <see cref="Event" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Event" /></returns>
		public static implicit operator Event(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}