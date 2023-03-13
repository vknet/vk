using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Объект, содержащий информацию о заказе.
/// </summary>
[Serializable]
public class MarketOrder : IGroupUpdate
{
	/// <summary>
	/// Идентификатор заказа.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Идентификатор сообщества.
	/// </summary>
	[JsonProperty("group_id")]
	public long? GroupId { get; set; }

	/// <summary>
	/// Идентификатор покупателя.
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор группы вариантов.
	/// </summary>
	[JsonProperty("variants_grouping_id")]
	public long? VariantsGroupingId { get; set; }

	/// <summary>
	/// Массив объектов, каждый из которых может содержать поля:
	/// variant_id (integer) — идентификатор варианта;
	/// variant_name (string) — название варианта;
	/// property_name (string) — название свойства.
	/// </summary>
	[JsonProperty("property_values")]
	public List<string> PropertyValues { get; set; }

	/// <summary>
	/// Количество товаров в заказе.
	/// </summary>
	[JsonProperty("items_count")]
	public long? ItemsCount { get; set; }

	/// <summary>
	/// Количество товара в корзине.
	/// </summary>
	[JsonProperty("cart_quantity")]
	public long? CartQuantity { get; set; }

	/// <summary>
	/// Общая стоимость заказа
	/// </summary>
	[JsonProperty("total_price")]
	public Price TotalPrice { get; set; }

	/// <summary>
	/// Информация о доставке
	/// </summary>
	[JsonProperty("delivery")]
	public Delivery Delivery { get; set; }

	/// <summary>
	/// Информация о покупателе
	/// </summary>
	[JsonProperty("recipient")]
	public Recipient Recipient { get; set; }

	/// <summary>
	/// Массив объектов, описывающих товары.
	/// Возвращается не больше 5 случайных товаров заказа.
	/// </summary>
	[JsonProperty("preview_order_items")]
	public ReadOnlyCollection<Market> PreviewOrderItems { get; set; }

	/// <summary>
	/// Дата создания заказа в формате Unixtime.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }


	/// <summary>
	/// Номер заказа, состоящий из идентификатора покупателя и идентификатора заказа.
	/// </summary>
	[JsonProperty("display_order_id")]
	public string DisplayOrderId { get; set; }

	/// <summary>
	/// Комментарий к заказу.
	/// </summary>
	[JsonProperty("comment")]
	public string Comment { get; set; }

	/// <summary>
	/// Является ли вариант основным.
	/// </summary>
	[JsonProperty("is_main_variant")]
	public bool IsMainVariant { get; set; }

	/// <summary>
	/// Идентификатор пользователя, который удалил комментарий
	/// </summary>
	[JsonProperty("status")]
	public MarketOrderState Status { get; set; }
}