using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Время последнего посещения.
	/// </summary>
	[Serializable]
	public class LastSeen
	{
		/// <summary>
		/// Время последнего посещения в формате unixtime. .
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Time { get; set; }

		/// <summary>
		/// Тип платформы, через которую был осуществлён последний вход. Подробнее cмотрите
		/// на странице Подключение к LongPoll
		/// серверу. .
		/// </summary>
		public string Platform { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static LastSeen FromJson(VkResponse response)
		{
			var giftItem = new LastSeen
			{
					Time = response[key: "time"]
					, Platform = response[key: "platform"]
			};

			return giftItem;
		}
	}
}