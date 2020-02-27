using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Настройка
	/// </summary>
	[Serializable]
	public class PrivacySettingSetting
	{
		/// <summary>
		/// Ключ
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; set; }

		/// <summary>
		/// Заголовок
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Текущее значение
		/// </summary>
		[JsonProperty("value")]
		public PrivacySettingsValue Value { get; set; }

		/// <summary>
		/// Секция
		/// </summary>
		[JsonProperty("section")]
		public string Section { get; set; }

		/// <summary>
		/// Тип
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Поддерживаемые категории
		/// </summary>
		[JsonProperty("supported_categories")]
		public string[] SupportedCategories { get; set; }
	}
}