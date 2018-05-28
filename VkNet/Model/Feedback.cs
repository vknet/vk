using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Объект описывающий поступивший ответ. 
	/// </summary>
	[Serializable]
	public class Feedback
	{
		/// <summary>
		/// Количество
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив объектов
		/// </summary>
		[JsonProperty("items")]
		public List<FeedbackItem> Items { get; set; }
	}
}