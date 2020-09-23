using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о подкасте
	/// </summary>
	[Serializable]
	public class PodcastInfo
	{
		/// <summary>
		/// Обложка.
		/// </summary>
		[JsonProperty("cover")]
		public Cover Cover { get; set; }

		/// <summary>
		/// Количество прослушиваний.
		/// </summary>
		[JsonProperty("plays")]
		public long Plays { get; set; }

		/// <summary>
		/// Важный.
		/// </summary>
		[JsonProperty("is_favorite")]
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Позиция.
		/// </summary>
		[JsonProperty("position")]
		public long? Position { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PodcastInfo FromJson(VkResponse response)
		{
			return new PodcastInfo
			{
				Cover = response["cover"],
				Plays = response["plays"],
				IsFavorite = response["is_favorite"],
				Description = response["description"],
				Position = response["position"]
			};
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static implicit operator PodcastInfo(VkResponse response)
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