using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Просмотры
	/// </summary>
	[Serializable]
	public class Views
	{
		/// <summary>
		/// Количество
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }
	}
}