using System;
using System.Collections.Generic;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Параметры получения списка продуктов
/// </summary>
[Serializable]
public class StoreGetProductsParams
{
	/// <summary>
	/// Тип продуктов
	/// </summary>
	/// <remarks> Обязательный параметр, если не используется параметр ProductIds.</remarks>
	public ProductType Type { get; set; }

	/// <summary>
	/// Магазин
	/// </summary>
	public Merchant? Merchant { get; set; }

	/// <summary>
	/// Идентификаторы продуктов, информацию о которых необходимо получить.
	/// </summary>
	/// <remarks> Если используется этот параметр, параметр Type является обязательным.</remarks>
	public List<string> ProductIds { get; set; }

	/// <summary>
	/// Определяет статусы, по которым необходимо отфильтровать продукты
	/// </summary>
	/// <remarks> Является обязательным, если не используется параметр ProductIds.</remarks>
	public List<ProductStatusFilter> Filters { get; set; }

	/// <summary>
	/// Нужна ли расширенная информация о продуктах
	/// </summary>
	public bool Extended { get; set; }
}