using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Копия изображения обложки.
	/// </summary>
	[Serializable]
	public class AppImageResult
	{
		/// <summary>
		/// Общее число результатов
		/// </summary>
		[JsonProperty("count")]
		public int Count { get; set; }

		/// <summary>
		/// Массив объектов, описывающих изображения
		/// </summary>
		[JsonProperty("items")]
		public IEnumerable<AppImage> Items { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AppImageResult FromJson(VkResponse response)
		{
			return new AppImageResult
			{
				Count = response[key: "count"],
				Items = response[key: "items"].ToReadOnlyCollectionOf<AppImage>(x => x)
			};
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static implicit operator AppImageResult(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response: response)
				: null;
		}

	}
}