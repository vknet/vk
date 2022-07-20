using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Поддерживаемые категории
	/// </summary>
	[Serializable]
	public class SupportedCategories
	{
		/// <summary>
		/// Заголовок
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Текущее значение
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}