using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса
	/// </summary>
	[Serializable]
	public class NotificationGetResult
	{
		/// <summary>
		/// Количество уведомлений
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив оповещений для текущего пользователя.
		/// </summary>
		[JsonProperty(propertyName: "items")]
		public List<Notification> Items { get; set; }

		/// <summary>
		/// Информация о пользователях, которые находятся в списке оповещений.
		/// </summary>
		[JsonProperty(propertyName: "profiles")]
		public List<User> Profiles { get; set; }

		/// <summary>
		/// Информация о сообществах, которые находятся в списке оповещений.
		/// </summary>
		[JsonProperty(propertyName: "groups")]
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Время последнего просмотра пользователем раздела оповещений в формате Unixtime.
		/// </summary>
		[JsonProperty(propertyName: "last_viewed")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime LastViewed { get; set; }

		/// <summary>
		/// Строковый идентификатор оповещения, полученного последним в предыдущем вызове
		/// </summary>
		[JsonProperty(propertyName: "next_from")]
		public string NextFrom { get; set; }
	}
}