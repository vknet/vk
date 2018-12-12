using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Обложка
	/// </summary>
	[Serializable]
	public class Cover
	{
		/// <summary>
		/// Размеры
		/// </summary>
		[JsonProperty("sizes")]
		public ReadOnlyCollection<CoverSize> Sizes { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Cover FromJson(VkResponse response)
		{
			return new Cover
			{
				Sizes = response["sizes"].ToReadOnlyCollectionOf<CoverSize>(x => x)
			};
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static implicit operator Cover(VkResponse response)
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