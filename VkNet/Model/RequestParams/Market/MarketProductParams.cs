using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
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
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор товара.
		/// </summary>
		public long? ItemId { get; set; }

		/// <summary>
		/// Название товара. строка, минимальная длина 4, максимальная длина 100,
		/// обязательный параметр (строка, минимальная
		/// длина 4, максимальная длина 100, обязательный параметр).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание товара. строка, минимальная длина 10, обязательный параметр (строка,
		/// минимальная длина 10, обязательный
		/// параметр).
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Идентификатор категории товара. положительное число, обязательный параметр
		/// (положительное число, обязательный
		/// параметр).
		/// </summary>
		public long CategoryId { get; set; }

		/// <summary>
		/// Цена товара. дробное число, обязательный параметр, минимальное значение 0.01
		/// (дробное число, обязательный параметр,
		/// минимальное значение 0.01).
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Статус товара (1 — товар удален, 0 — товар не удален). флаг, может принимать
		/// значения 1 или 0 (флаг, может
		/// принимать значения 1 или 0).
		/// </summary>
		public bool Deleted { get; set; }

		/// <summary>
		/// Идентификатор фотографии обложки товара. положительное число, обязательный
		/// параметр (положительное число,
		/// обязательный параметр).
		/// </summary>
		public long MainPhotoId { get; set; }

		/// <summary>
		/// Идентификаторы дополнительных фотографий товара. список положительных чисел,
		/// разделенных запятыми, количество
		/// элементов должно составлять не более 4 (список положительных чисел, разделенных
		/// запятыми, количество элементов
		/// должно составлять не более 4).
		/// </summary>
		public IEnumerable<long> PhotoIds { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(MarketProductParams p)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", p.OwnerId }
					, { "item_id", p.ItemId }
					, { "name", p.Name }
					, { "description", p.Description }
					, { "category_id", p.CategoryId }
					, { "price", p.Price }
					, { "deleted", p.Deleted }
					, { "main_photo_id", p.MainPhotoId }
					, { "photo_ids", p.PhotoIds }
			};

			return parameters;
		}
	}
}