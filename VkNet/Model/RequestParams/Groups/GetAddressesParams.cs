using System;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.Filters;

namespace VkNet.Model.RequestParams.Groups
{
	/// <summary>
	/// Параметры метода <see cref="IGroupsCategory"/>.<see cref="IGroupsCategory.GetAddressesAsync"/>
	/// </summary>
	[Serializable]
	public class GetAddressesParams
	{
		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		/// <remarks>
		/// Положительное число, обязательный параметр
		/// </remarks>
		[JsonProperty("group_id")]
		public ulong GroupId { get; set; }

		/// <summary>
		/// Список дополнительных полей сообществ, которые необходимо вернуть.
		/// </summary>
		[JsonProperty("fields")]
		public GroupsFields Fields { get; set; }

		/// <summary>
		/// Перечисленные через запятую идентификаторы адресов, информацию о которых необходимо вернуть.
		/// </summary>
		/// <remarks>
		/// Список положительных чисел, разделенных запятыми
		/// </remarks>
		[JsonProperty("address_ids")]
		public ulong[] AddressIds { get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах (от -90 до 90).
		/// </summary>
		/// <remarks>
		/// Дробное число, минимальное значение -90, максимальное значение 90
		/// </remarks>
		[JsonProperty("latitude")]
		public decimal? Latitude { get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах (от -180 до 180).
		/// </summary>
		/// <remarks>
		/// Дробное число, минимальное значение -180, максимальное значение 180
		/// </remarks>
		[JsonProperty("longitude")]
		public decimal? Longitude { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества черного списка.
		/// </summary>
		/// <remarks>
		/// Положительное число
		/// </remarks>
		[JsonProperty("offset")]
		public ulong? Offset { get; set; }

		/// <summary>
		/// Количество адресов, которое необходимо вернуть.
		/// </summary>
		/// <remarks>
		/// Положительное число, по умолчанию 10
		/// </remarks>
		[JsonProperty("count")]
		public ulong? Count { get; set; }
	}
}