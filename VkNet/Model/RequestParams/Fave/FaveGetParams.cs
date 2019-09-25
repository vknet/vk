using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams.Fave
{
	/// <summary>
	/// Параметры запроса метода fave.get
	/// </summary>
	[Serializable]
	public class FaveGetParams
	{
		/// <summary>
		/// Типы объектов, которые необходимо вернуть.
		/// </summary>
		[JsonProperty("item_type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public FaveType ItemType { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть.
		/// </summary>
		[JsonProperty("fields")]
		public string Fields { get; set; }

		/// <summary>
		/// <c>true</c>, если необходимо получить информацию о пользователе.
		/// </summary>
		/// <remarks>
		/// По умолчанию: <c>false</c>.
		/// </remarks>
		[JsonProperty("extended")]
		public bool? Extended { get; set; }

		/// <summary>
		/// Идентификатор метки, закладки отмеченные которой требуется вернуть.
		/// </summary>
		[JsonProperty("tag_id")]
		public long? TagId { get; set; }

		/// <summary>
		/// Смещение относительно первого объекта в закладках пользователя для выборки определенного подмножества.
		/// </summary>
		[JsonProperty("offset")]
		public ulong? Offset { get; set; }

		/// <summary>
		/// Количество возвращаемых закладок. 
		/// </summary>
		/// <remarks>
		/// По умолчанию 50, минимальное значение 1, максимальное значение 100.
		/// </remarks>
		[JsonProperty("count")]
		public long? Count { get; set; }

		/// <summary>
		/// Флаг, может принимать значения <c>true</c> или <c>false</c>
		/// </summary>
		[JsonProperty("is_from_snackbar")]
		public bool? IsFromSnackbar { get; set; }
	}
}