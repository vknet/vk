using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Cсылка для перехода из истории
	/// </summary>
	[Serializable]
	public class StoryLink
	{
		/// <summary>
		/// Текст ссылки
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// URL для перехода.
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }
	}
}