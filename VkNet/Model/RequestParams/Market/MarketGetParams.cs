using System;

namespace VkNet.Model
{
	/// <summary>
	/// Параметры для запроса market.get
	/// </summary>
	[Serializable]
	public class MarketGetParams
	{
		/// <summary>
		/// Идентификатор сообщества, которому принадлежат товары.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор подборки, товары из которой нужно вернуть.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Количество возвращаемых товаров.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение относительно первого найденного товара для выборки определенного
		/// подмножества.
		/// </summary>
		public long? Offset { get; set; }


		/// <summary>
		/// 1 - чтобы вернуть доп.поля likes, can_comment, can_repost, photos, views_count.
		/// По умолчанию 0
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Параметр для сортировки выгрузки товаров, загруженных с определенной даты
		/// DateFrom - строка вида dd.MM.yyyy или dd.MM(год текущий по умолчанию)
		/// </summary>
		public string DateFrom { get; set; }

		/// <summary>
		/// Параметр для сортировки выгрузки товаров, загруженных до определенной даты
		/// DateTo - строка вида dd.MM.yyyy или dd.MM(год текущий по умолчанию)
		/// </summary>
		public string DateTo { get; set; }

		/// <summary>
		/// Флаг для получения вариантов одного товара,если они существуют
		/// </summary>
		public bool? NeedVariants { get; set; }

		/// <summary>
		/// Флаг для получения выведденых товаров с продажи
		/// </summary>
		public bool? WithDisabled { get; set; }
	};
}
