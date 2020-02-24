using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Текущее значение
	/// </summary>
	[Serializable]
	public class PrivacySettingsValue
	{
		/// <summary>
		/// Категория
		/// </summary>
		[JsonProperty("category")]
		public string Category { get; set; }
	}
}