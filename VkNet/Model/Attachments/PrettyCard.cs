using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class PrettyCard
	{
		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "card_id")]
		public string CardId { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "link_url_target")]
		public string LinkUrlTarget { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "link_url")]
		public string LinkUrl { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "button")]
		public Button Button { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "images")]
		public ReadOnlyCollection<Photo> Images { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PrettyCard FromJson(VkResponse response)
		{
			return new PrettyCard
			{
					CardId = response[key: "card_id"]
					, LinkUrlTarget = response[key: "link_url_target"]
					, LinkUrl = response[key: "link_url"]
					, Title = response[key: "title"]
					, Button = response[key: "button"]
					, Images = response[key: "images"].ToReadOnlyCollectionOf<Photo>(selector: x => x)
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PrettyCard(VkResponse response)
		{
			return response != null && !response.HasToken() ? null : FromJson(response: response);
		}
	}
}