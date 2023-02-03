using System;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Возвращает данные о точках, по которым вырезаны профильная и миниатюрная
/// фотографии пользователя.
/// </summary>
[Serializable]
public class CropPhoto
{
	/// <summary>
	/// Объект photo фотографии пользователя из которой вырезается профильная аватарка.
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Вырезанная фотография пользователя, поля: x, y, x2, y2, координаты указаны в
	/// процентах.
	/// </summary>
	[JsonProperty("crop")]
	public Rect Crop { get; set; }

	/// <summary>
	/// Миниатюрная квадратная фотография, вырезанная из фотографии Crop: x, y, x2, y2,
	/// координаты также указаны в
	/// процентах;
	/// </summary>
	[JsonProperty("rect")]
	public Rect Rect { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static CropPhoto FromJson(VkResponse response)
	{
		var cropPhoto = new CropPhoto
		{
			Photo = response[key: "photo"],
			Crop = JsonConvert.DeserializeObject<Rect>(response[key: "crop"].ToString()),
			Rect = JsonConvert.DeserializeObject<Rect>(response[key: "rect"].ToString())
		};

		return cropPhoto;
	}
}