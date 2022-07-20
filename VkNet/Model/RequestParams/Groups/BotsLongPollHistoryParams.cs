using System;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры BotsLongPoll API
	/// </summary>
	[Serializable]
	public class BotsLongPollHistoryParams
	{
		/// <summary>
		/// Сервер для подключения Long Poll группы
		/// </summary>
		public string Server { get; set; }

		/// <summary>
		/// Последние полученое событие
		/// </summary>
		public string Ts { get; set; }

		/// <summary>
		/// Ключ сессии
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Время ожидание события
		/// </summary>
		public int Wait { get; set; }
	}
}