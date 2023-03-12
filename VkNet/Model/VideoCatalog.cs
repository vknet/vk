using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Данные для отображения блока видеокаталога
/// </summary>
[Serializable]
public class VideoCatalog
{
	/// <summary>
	/// Список элементов блока видеокаталога
	/// </summary>
	[JsonProperty("items")]
	public ReadOnlyCollection<VideoCatalogItem> Items { get; set; }

	/// <summary>
	/// Идентификатор блока. Возвращается строка для предопределенных блоков. Для
	/// других возвращается число.
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	/// Заголовок блока.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Параметр для получения следующей страницы результатов. Необходимо передать его
	/// значение в from в следующем вызове,
	/// чтобы получить содержимое каталога, следующее за полученным в текущем вызове.
	/// </summary>
	[JsonProperty("next")]
	public string Next { get; set; }

	/// <summary>
	/// предпочтительный способ отображения контента
	/// </summary>
	[JsonProperty(propertyName: "view")]
	public VideoView View { get; set; }

	/// <summary>
	/// Наличие возможности скрыть блок.
	/// </summary>
	[JsonProperty("can_hide")]
	public bool? CanHide { get; set; }

	/// <summary>
	/// Тип блока.
	/// </summary>
	[JsonProperty("type")]
	public VideoCatalogType Type { get; set; }
}