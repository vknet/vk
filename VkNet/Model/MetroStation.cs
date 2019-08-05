using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Станция метро
	/// </summary>
	[Serializable]
	public class MetroStation
	{
		/// <summary>
		/// Идентификатор станции метро
		/// </summary>
		[JsonProperty("id")]
		public ulong Id { get; set; }

		/// <summary>
		/// Название станции метро
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Цвет ветки станции метро
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }
	}
}