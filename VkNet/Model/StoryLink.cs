using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static StoryLink FromJson(VkResponse response)
		{
			var link = new StoryLink
			{
				Text = response["text"],
				Url = response["url"]
			};

			return link;
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator StoryLink(VkResponse response)
		{
			return response != null && response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}