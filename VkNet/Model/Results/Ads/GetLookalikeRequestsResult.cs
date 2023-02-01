using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Возвращает список запросов на поиск похожей аудитории.
/// </summary>
[Serializable]
public class GetLookalikeRequestsResult
{
	/// <summary>
	/// Количество запросов на поиск похожей аудитории в данном кабинете.
	/// </summary>
	[JsonProperty("count")]
	public long Count { get; set; }

	/// <summary>
	/// Список объектов-запросов на поиск похожей аудитории запрошенного размера с запрошенным сдвигом
	/// </summary>
	[JsonProperty("items")]
	public ReadOnlyCollection<LookalikeRequestItem> Items { get; set; }
}