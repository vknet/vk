using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Объект, с помощью которого можно подключиться к серверу быстрых сообщений для
	/// мгновенного
	/// получения приходящих сообщений и других событий.
	/// См. описание http://vk.com/dev/messages.getLongPollServer
	/// </summary>
	[Serializable]
	public class LongPollServerResponse
	{
		/// <summary>
		/// Ключ для подключения.
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Имя сервера быстрых сообщений.
		/// </summary>
		public string Server { get; set; }

		/// <summary>
		/// Отметка времени.
		/// </summary>
		public ulong Ts { get; set; }

		/// <summary>
		/// Постоянное событие для работы с методом getLongPoolHistory
		/// </summary>
		public ulong? Pts { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static LongPollServerResponse FromJson(VkResponse response)
		{
			var longPollServerResponse = new LongPollServerResponse
			{
					Key = response[key: "key"]
					, Server = response[key: "server"]
					, Ts = response[key: "ts"]
					, Pts = response[key: "pts"]
			};

			return longPollServerResponse;
		}

	#endregion
	}
}