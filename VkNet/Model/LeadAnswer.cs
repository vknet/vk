using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// ответ на вопрос
	/// </summary>
	[Serializable]
	public class LeadAnswer
	{
		/// <summary>
		/// ключ ответа (в случае, если был задан при создании формы)
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; set; }

		/// <summary>
		/// текст ответа
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}