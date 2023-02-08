using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments;

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
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Sticker FromJson(VkResponse response) => new()
	{
		Id = response["id"] ?? response["sticker_id"],
		ProductId = response["product_id"],
		Images = !response.ContainsKey("images")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<Image>>(response["images"].ToString()),
		ImagesWithBackground = !response.ContainsKey("images_with_background")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<Image>>(response["images_with_background"].ToString())
	};

	/// <summary>
	/// Преобразование класса <see cref="Sticker" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns>Результат преобразования в <see cref="Sticker" /></returns>
	public static implicit operator Sticker(VkResponse response)
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