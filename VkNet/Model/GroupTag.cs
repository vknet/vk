using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Тэг группы
	/// </summary>
	[Serializable]
	public class GroupTag
	{
		/// <summary>
		/// Идентификатор тэга
		/// </summary>
		[JsonProperty("id")]
		public ulong Id { get; set; }

		/// <summary>
		/// Название тэга
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Цвет тэга в формате #ffffff
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }
	}
}