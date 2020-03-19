using System;
using System.Collections.Generic;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.Market
{
	/// <summary>
	/// Параметры запроса market.search
	/// </summary>
	[Serializable]
	public class MarketSearchParams
	{
		/// <summary>
		/// Идентификатор сообщества, которому принадлежат товары.
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор подборки, товары из которой нужно вернуть.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Строка поискового запроса.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Минимальное значение цены товаров.
		/// </summary>
		public long? PriceFrom { get; set; }

		/// <summary>
		/// Максимальное значение цены товаров.
		/// </summary>
		public long? PriceTo { get; set; }

		/// <summary>
		/// Перечисленные через запятую идентификаторы меток.
		/// </summary>
		public IEnumerable<long> Tags { get; set; }

		/// <summary>
		/// Вид сортировки.
		/// </summary>
		public ProductSort? Sort { get; set; }

		/// <summary>
		/// 0 — не использовать обратный порядок, 1 — использовать обратный порядок.
		/// </summary>
		public bool? Rev { get; set; }

		/// <summary>
		/// Смещение относительно первого найденного товара для выборки определенного
		/// подмножества.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество возвращаемых товаров.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// 1 — будут возвращены дополнительные поля likes, can_comment, can_repost,
		/// ''photos'''.
		/// </summary>
		public bool? Extended { get; set; }
	}
}