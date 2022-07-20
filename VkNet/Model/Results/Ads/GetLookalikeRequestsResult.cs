using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
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

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetLookalikeRequestsResult FromJson(VkResponse response)
		{
			return new GetLookalikeRequestsResult
			{
				Count = response["count"],
				Items = response["items"].ToReadOnlyCollectionOf<LookalikeRequestItem>(x=>x)
			};
		}
	}
}