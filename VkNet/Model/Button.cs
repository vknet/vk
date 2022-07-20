using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Кнопка.
	/// </summary>
	[Serializable]
	public class Button
	{
		/// <summary>
		/// Название кнопки.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Ссылка на которую ведет кнопка.
		/// </summary>
		public Uri Uri { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("action")]
		public LinkButtonAction Action { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Button FromJson(VkResponse response)
		{
			var button = new Button
			{
					Title = response[key: "title"]
					, Uri = response[key: "url"]
					, Action = response[key: "action"]
			};

			return button;
		}
	}
}