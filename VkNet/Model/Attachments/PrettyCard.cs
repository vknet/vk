using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Карточка приложения
/// </summary>
[Serializable]
public class PrettyCard
{
	/// <summary>
	/// Идентификатор карточки
	/// </summary>
	[JsonProperty("card_id")]
	public string CardId { get; set; }

	/// <summary>
	/// Ссылка на цель
	/// </summary>
	[JsonProperty("link_url_target")]
	public string LinkUrlTarget { get; set; }

	/// <summary>
	/// Ссылка
	/// </summary>
	[JsonProperty("link_url")]
	public string LinkUrl { get; set; }

	/// <summary>
	/// Заголовок
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Кнопка
	/// </summary>
	[JsonProperty("button")]
	public Button Button { get; set; }

	/// <summary>
	/// Фотографии
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
}