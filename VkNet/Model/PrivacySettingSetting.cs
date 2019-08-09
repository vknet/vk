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
		public string[] Value { get; set; }

		/// <summary>
		/// Секция
		/// </summary>
		[JsonProperty("section")]
		public string Section { get; set; }

		/// <summary>
		/// Поддерживаемые значения
		/// </summary>
		[JsonProperty("supported_values")]
		public string[] SupportedValues { get; set; }
	}
}