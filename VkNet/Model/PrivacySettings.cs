using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Приватные настройки
	/// </summary>
	[Serializable]
	public class PrivacySettings
	{
		/// <summary>
		/// Настройки
		/// </summary>
		[JsonProperty("settings")]
		public PrivacySettingSetting[] Settings { get; set; }

		/// <summary>
		/// Секции
		/// </summary>
		[JsonProperty("sections")]
		public PrivacySettingsSection[] Sections { get; set; }

		/// <summary>
		/// Поддерживаемые категории
		/// </summary>
		[JsonProperty("supported_categories")]
		public SupportedCategories[] SupportedCategories { get; set; }
	}
}