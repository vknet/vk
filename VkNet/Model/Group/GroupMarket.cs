using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о магазине.
	/// </summary>
	[Serializable]
	public class GroupMarket
	{
		/// <summary>
		/// Информация о том, включен ли блок товаров в сообществе.
		/// </summary>
		[JsonProperty("enabled")]
		public bool Enabled { get; set; }

		/// <summary>
		/// Минимальная цена товаров;
		/// </summary>
		[JsonProperty("price_min")]
		public int PriceMin { get; set; }

		/// <summary>
		/// Максимальная цена товаров
		/// </summary>
		[JsonProperty("price_max")]
		public int PriceMax { get; set; }

		/// <summary>
		/// Идентификатор главной подборки товаров
		/// </summary>
		[JsonProperty("main_album_id")]
		public long MainAlbumId { get; set; }

		/// <summary>
		/// Идентификатор контактного лица для связи с продавцом. Возвращается отрицательное значение,
		/// если для связи с продавцом используются сообщения сообщества;
		/// </summary>
		[JsonProperty("contact_id")]
		public long ContactId { get; set; }

		/// <summary>
		/// Информация о валюте.
		/// </summary>
		[JsonProperty("currency")]
		public Currency Currency { get; set; }

		/// <summary>
		/// Строковое обозначение.
		/// </summary>
		[JsonProperty("currency_text")]
		public string CurrencyText { get; set; }

		/// <summary>
		/// Тип, может иметь значения basic и advanced в зависимости от типа магазина.
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Десериализовать из Json.
		/// </summary>
		/// <param name="response"> Ответ от vk. </param>
		/// <returns> </returns>
		public static GroupMarket FromJson(VkResponse response)
		{
			return new GroupMarket
			{
				Enabled = response["enabled"],
				PriceMin = response["price_min"],
				PriceMax = response["price_max"],
				MainAlbumId = response["main_album_id"],
				ContactId = response["contact_id"],
				Currency = response["currency"],
				CurrencyText = response["currency_text"],
				Type = response["type"]
			};
		}

		/// <summary>
		/// Неявное преобразование к объекту <see cref="GroupMarket"/> из <see cref="VkResponse"/>
		/// </summary>
		/// <param name="response">Ответ от vk.</param>
		/// <returns></returns>
		public static implicit operator GroupMarket(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}