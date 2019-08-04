using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Параметр запроса
	/// </summary>
	[Serializable]
	public class RequestParam
	{
		/// <summary>
		/// Ключ
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; set; }

		/// <summary>
		/// Значение
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}