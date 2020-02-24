using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Секция
	/// </summary>
	[Serializable]
	public class PrivacySettingsSection
	{
		/// <summary>
		/// Наименование секции
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Заголовок секции
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}