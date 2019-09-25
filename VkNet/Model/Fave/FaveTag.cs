using System;
using Newtonsoft.Json;

namespace VkNet.Model.Fave
{
	/// <summary>
	/// Метка закладки.
	/// </summary>
	[Serializable]
	public class FaveTag
	{
		/// <summary>
		/// Идентификатор метки.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Название метки.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}