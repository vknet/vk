using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Стикер.
/// </summary>
[Serializable]
public class Sticker : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "sticker";

	/// <summary>
	/// Идентификатор набора.
	/// </summary>
	[JsonProperty("product_id")]
	public long? ProductId { get; set; }

	/// <summary>
	/// Изображения для стикера (с прозрачным фоном).
	/// </summary>
	[JsonProperty("images")]
	public IEnumerable<Image> Images { get; set; }

	/// <summary>
	/// Изображения для стикера (с непрозрачным фоном).
	/// </summary>
	[JsonProperty("images_with_background")]
	public IEnumerable<Image> ImagesWithBackground { get; set; }

	[JsonProperty("sticker_id")]
	private long? StickerId
	{
		get => Id;
		set => Id = value;
	}
}