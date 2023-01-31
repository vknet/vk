using System;
using Newtonsoft.Json;

namespace VkNet.Model;

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
}