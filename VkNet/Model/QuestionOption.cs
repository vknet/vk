using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Вариант ответа
	/// </summary>
	[Serializable]
	public class QuestionOption
	{
		/// <summary>
		/// Ключ ответа (необязательно)
		/// </summary>
		[JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
		public string Key { get; set; }

		/// <summary>
		/// Текст ответа
		/// </summary>
		[JsonProperty("label")]
		public string Label { get; set; }
	}
}