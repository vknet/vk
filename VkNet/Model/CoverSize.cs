using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Размер
	/// </summary>
	[Serializable]
	public class CoverSize
	{
		/// <summary>
		/// URL
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// Ширина
		/// </summary>
		[JsonProperty("width")]
		public long Width { get; set; }

		/// <summary>
		/// Высота
		/// </summary>
		[JsonProperty("height")]
		public long Height { get; set; }

		/// <summary>
		/// Тип
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CoverSize FromJson(VkResponse response)
		{
			return new CoverSize
			{
				Url = response["url"],
				Width = response["width"],
				Height = response["height"],
				Type = response["type"]
			};
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static implicit operator CoverSize(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}