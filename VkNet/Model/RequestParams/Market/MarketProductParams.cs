using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Abstractions;

namespace VkNet.Model.RequestParams.Market
{
	/// <summary>
	/// Параметр для добавления / редактирования товара
	/// </summary>
	[Serializable]
	public class MarketProductParams
	{
		/// <summary>
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id необходимо
		/// указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору
		/// сообщества ВКонтакте API (club1)
		/// целое число, обязательный параметр (целое число, обязательный параметр).
		/// </summary>
		[JsonProperty("photo_ids")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор товара.
		/// </summary>
		/// <remarks>
		/// Только для метода <see cref="IMarketsCategory.Edit"/>
		/// </remarks>
		[JsonProperty("item_id")]
		public long? ItemId { get; set; }

		/// <summary>
		/// Название товара. строка, минимальная длина 4, максимальная длина 100,
		/// обязательный параметр (строка, минимальная
		/// длина 4, максимальная длина 100, обязательный параметр).
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Описание товара. строка, минимальная длина 10, обязательный параметр (строка,
		/// минимальная длина 10, обязательный
		/// параметр).
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Идентификатор категории товара. положительное число, обязательный параметр
		/// (положительное число, обязательный
		/// параметр).
		/// </summary>
		[JsonProperty("category_id")]
		public long CategoryId { get; set; }

		/// <summary>
		/// Цена товара. дробное число, обязательный параметр, минимальное значение 0.01
		/// (дробное число, обязательный параметр,
		/// минимальное значение 0.01).
		/// </summary>
		[JsonProperty("price")]
		public decimal Price { get; set; }

		/// <summary>
		/// Цена товара. дробное число, обязательный параметр, минимальное значение 0.01
		/// (дробное число, обязательный параметр,
		/// минимальное значение 0.01).
		/// </summary>
		[JsonProperty("old_price")]
		public decimal OldPrice { get; set; }

		/// <summary>
		/// Статус товара (1 — товар удален, 0 — товар не удален). флаг, может принимать
		/// значения 1 или 0 (флаг, может
		/// принимать значения 1 или 0).
		/// </summary>
		[JsonProperty("deleted")]
		public bool Deleted { get; set; }

		/// <summary>
		/// Идентификатор фотографии обложки товара. положительное число, обязательный
		/// параметр (положительное число,
		/// обязательный параметр).
		/// </summary>
		[JsonProperty("main_photo_id")]
		public long MainPhotoId { get; set; }

		/// <summary>
		/// Идентификаторы дополнительных фотографий товара. список положительных чисел,
		/// разделенных запятыми, количество
		/// элементов должно составлять не более 4 (список положительных чисел, разделенных
		/// запятыми, количество элементов
		/// должно составлять не более 4).
		/// </summary>
		[JsonProperty("photo_ids")]
		public IEnumerable<long> PhotoIds { get; set; }

		/// <summary>
		/// Ссылка на сайт товара.
		/// </summary>
		/// <remarks>
		/// Строка, минимальная длина 0, максимальная длина 320
		/// </remarks>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// Ширина в миллиметрах.
		/// </summary>
		[JsonProperty("dimension_width")]
		public int DimensionWidth { get; set; }

		/// <summary>
		/// Высота в миллиметрах.
		/// </summary>
		[JsonProperty("dimension_height")]
		public int DimensionHeight { get; set; }

		/// <summary>
		/// Глубина в миллиметрах.
		/// </summary>
		[JsonProperty("dimension_length")]
		public int DimensionLength { get; set; }

		/// <summary>
		/// Вес в граммах.
		/// </summary>
		[JsonProperty("weight")]
		public int Weight { get; set; }

		/// <summary>
		/// Артикул товара, произвольная строка
		/// </summary>
		[JsonProperty("sku")]
		public string Sku { get; set; }
	}
}