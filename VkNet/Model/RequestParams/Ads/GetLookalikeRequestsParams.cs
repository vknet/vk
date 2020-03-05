using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.getLookalikeRequests
	/// </summary>
	[Serializable]
	public class GetLookalikeRequestsParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Список идентификаторов запрашиваемых запросов через запятую. Максимальное количество идентификаторов в списке – 200.
		/// Если этот параметр пуст, возвращаться будут все запросы. строка
		/// </summary>
		[JsonProperty("requests_ids")]
		public string RequestsIds { get; set; }

		/// <summary>
		/// Сортировка элементов. Возможные значения:
		/// id – сортировать по возрастанию идентификаторов
		/// update_time – сортировать по убыванию времени последнего обновления статуса
		/// строка, по умолчанию id
		/// </summary>
		[JsonProperty("sort_by")]
		public string SortBy { get; set; }

		/// <summary>
		/// Только для рекламных агентств.
		/// идентификатор клиента, для которого возвращаются запросы. целое число
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Смещение. Используется в связке с параметром limit. целое число, минимальное значение 0, по умолчанию 0
		/// </summary>
		[JsonProperty("offset")]
		public long? Offset { get; set; }

		/// <summary>
		/// Ограничение на количество возвращаемых запросов на поиск похожей аудитории. Используется в связке с параметром offset.
		/// 0 — вернуть только количество запросов в кабинете (у клиента в случае агентства).
		/// целое число, по умолчанию 10, минимальное значение 0, максимальное значение 200
		/// </summary>
		[JsonProperty("limit")]
		public long? Limit { get; set; }
	}
}