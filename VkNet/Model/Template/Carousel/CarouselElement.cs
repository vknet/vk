using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Объект элементов карусели.
/// </summary>
[Serializable]
public class CarouselElement
{
	/// <summary>
	/// Заголовок, максимум 80 символов
	/// </summary>
	[JsonProperty("title")]
	[CanBeNull]
	public string Title { get; set; }

	/// <summary>
	/// Подзаголовок, максимум 80 символов
	/// </summary>
	[JsonProperty("description")]
	[CanBeNull]
	public string Description { get; set; }

	/// <summary>
	/// Id изображения, которое надо прикрепить.
	/// Пропорции изображения: 13/8.
	/// Минимальный размер: 221х136.
	/// Пример: -123218_50548844
	/// </summary>
	[JsonProperty("photo_id")]
	[CanBeNull]
	public string PhotoId { get; set; }

	/// <summary>
	/// Фото
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Массив с кнопками.
	/// </summary>
	[JsonProperty("buttons")]
	public IEnumerable<MessageKeyboardButton> Buttons { get; set; }

	/// <summary>
	/// Объект, описывающий действие, которое необходимо выполнить при нажатии на элемент карусели.
	/// </summary>
	[JsonProperty("action")]
	[CanBeNull]
	public CarouselElementAction Action { get; set; }
}