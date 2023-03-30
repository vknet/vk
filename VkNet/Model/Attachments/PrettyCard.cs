using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model.Attachments;

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
}