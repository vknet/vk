using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса Search.GetHints
	/// </summary>
	[Serializable]
	public class SearchGetHintsParams
	{
		/// <summary>
		/// текст запроса, результаты которого нужно получить
		/// </summary>
		[JsonProperty(propertyName: "q")]
		public string Query { get; set; }

		/// <summary>
		/// смещение для выборки определённого подмножества результатов.
		/// </summary>
		[JsonProperty(propertyName: "offset")]
		public uint Offset { get; set; }

		/// <summary>
		/// ограничение на количество возвращаемых результатов.
		/// </summary>
		[JsonProperty(propertyName: "limit")]
		public uint Limit { get; set; }

		/// <summary>
		/// Перечисленные через запятую типы данных, которые необходимо вернуть. По
		/// умолчанию возвращаются все.
		/// </summary>
		[JsonProperty(propertyName: "filters")]
		public SearchFilter Filters { get; set; }

		/// <summary>
		/// дополнительные поля профилей и сообществ для получения.
		/// </summary>
		[JsonProperty(propertyName: "fields")]
		public ProfileFields ProfileFields { get; set; }

		/// <summary>
		/// 1 — к результатам поиска добавляются результаты глобального поиска по всем
		/// пользователям и группам.
		/// </summary>
		[JsonProperty(propertyName: "search_global")]
		public bool SearchGlobal { get; set; } = true;
	}
}