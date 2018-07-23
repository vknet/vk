using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Count Value
	/// </summary>
	[Serializable]
	public class CountValue
	{
		/// <summary>
		/// Количество
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Значение
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}