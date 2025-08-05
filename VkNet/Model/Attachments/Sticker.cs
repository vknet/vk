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

	/// <summary>
	/// URL анимации стикера (для анимированных стикеров)
	/// </summary>
	[JsonProperty("animation_url")]
	public string AnimationUrl { get; set; }

	/// <summary>
	/// Тип, который описывает вариант формата ответа.
	/// </summary>
	/// <remarks>По умолчанию: "base_sticker_new"</remarks>
	[JsonProperty("inner_type")]
	public string InnerType { get; set; }

	/// <summary>
	/// Информация о том, доступен ли стикер
	/// </summary>
	[JsonProperty("is_allowed")]
	public bool IsAllowed { get; set; }
}
