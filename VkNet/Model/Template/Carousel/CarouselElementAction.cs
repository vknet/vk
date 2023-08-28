using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Объект, описывающий действие, которое необходимо выполнить при нажатии на элемент карусели.
/// Поддерживается два действия:
/// open_link - открыть ссылку из поля "link".
/// open_photo - открыть фото текущего элемента карусели.
/// </summary>
[Serializable]
public class CarouselElementAction
{
	/// <summary>
	/// Тип клавиши.
	/// </summary>
	[JsonProperty("type")]
	public CarouselElementActionType? Type { get; set; }

	/// <summary>
	/// ссылка, которую необходимо открыть по нажатию на кнопку.
	/// </summary>
	[JsonProperty("link")]
	public Uri Link { get; set; }
}