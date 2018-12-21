using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация об ответах на текущую историю.
	/// </summary>
	[Serializable]
	public class StoryReplies
	{
		/// <summary>
		/// Число ответов
		/// </summary>
		[JsonProperty("count")]
		public int Count { get; set; }

		/// <summary>
		/// Число новых ответов.
		/// </summary>
		[JsonProperty("new")]
		public int? New { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static StoryReplies FromJson(VkResponse response)
		{
			var link = new StoryReplies
			{
				Count = response["count"],
				New = response["new"]
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
		public static implicit operator StoryReplies(VkResponse response)
		{
			return response != null && response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}