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
		[JsonProperty("card_id")]
		public string CardId { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("link_url_target")]
		public string LinkUrlTarget { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("link_url")]
		public string LinkUrl { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("button")]
		public Button Button { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("images")]
		public ReadOnlyCollection<Photo> Images { get; set; }

		/// <summary>
		/// Текст кнопки.
		/// </summary>
		[JsonProperty("button_text")]
		public string ButtonText { get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		[JsonProperty("photo")]
		public string Photo { get; set; }

		/// <summary>
		/// Цена.
		/// </summary>
		[JsonProperty("price")]
		public string Price { get; set; }

		/// <summary>
		/// Старая цена.
		/// </summary>
		[JsonProperty("price_old")]
		public string PriceOld { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PrettyCard FromJson(VkResponse response)
		{
			return new PrettyCard
			{
				CardId = response["card_id"],
				LinkUrlTarget = response["link_url_target"],
				LinkUrl = response["link_url"],
				Title = response["title"],
				Button = response["button"],
				Images = response["images"].ToReadOnlyCollectionOf<Photo>(x => x),
				ButtonText = response["button_text"],
				Price = response["price"],
				PriceOld = response["price_old"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="PrettyCard" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="PrettyCard" /></returns>
		public static implicit operator PrettyCard(VkResponse response)
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