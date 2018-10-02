using System;
using VkNet.Utils;

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

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(BotsLongPollHistoryParams p)
		{
			var parameters = new VkParameters
			{
				{ "ts", p.Ts },
				{ "key", p.Key },
				{ "wait", p.Wait },
				{ "act", "a_check" }
			};

			return parameters;
		}

		/// <summary>
		/// Преобразование класса <see cref="BotsLongPollHistoryParams" /> в VkParameters
		/// </summary>
		/// <param name="p"> Параметр. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VkParameters(BotsLongPollHistoryParams p)
		{
			return ToVkParameters(p: p);
		}
	}
}