using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Структура статистики
	/// </summary>
	[Serializable]
	public class StatsStruct
	{
		/// <summary>
		/// Аудитория для показателя value;.
		/// </summary>
		public long Visitors { get; set; }

		/// <summary>
		/// Значение демографического показателя, имеет разные возможные значения для
		/// разных показателей.
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// Код страны.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Наглядное название значения указанного в value (только для городов).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static StatsStruct FromJson(VkResponse response)
		{
			var statsStruct = new StatsStruct
			{
					Visitors = response[key: "visitors"]
					, Value = response[key: "value"]
					, Code = response[key: "code"]
					, Name = response[key: "name"]
			};

			return statsStruct;
		}
	}
}