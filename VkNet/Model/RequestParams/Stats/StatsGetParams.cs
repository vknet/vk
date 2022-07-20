using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Параметры метода Stats.Get
	/// </summary>
	[Serializable]
	public class StatsGetParams
	{
		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		[JsonProperty("group_id")]
		public ulong GroupId { get; set; }

		/// <summary>
		/// Идентификатор приложения.
		/// </summary>
		[JsonProperty("app_id")]
		public ulong AppId { get; set; }

		/// <summary>
		/// Начало периода статистики в Unixtime.
		/// </summary>
		/// <remarks>
		/// Положительное число, доступен начиная с версии 5.86
		/// </remarks>
		[JsonProperty("timestamp_from")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? TimestampFrom { get; set; }

		/// <summary>
		/// Окончание периода статистики в Unixtime.
		/// </summary>
		/// <remarks>
		/// Положительное число, доступен начиная с версии 5.86
		/// </remarks>
		[JsonProperty("timestamp_to")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? TimestampTo { get; set; }

		/// <summary>
		/// Временные интервалы.
		/// </summary>
		[JsonProperty("interval")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public StateInterval Interval { get; set; }

		/// <summary>
		/// Количество интервалов времени.
		/// </summary>
		[JsonProperty("intervals_count")]
		public ulong IntervalsCount { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("filters")]
		public ReadOnlyCollection<string> Filters { get; set; }

		/// <summary>
		/// Фильтр для получения данных по конкретному блоку статистики сообщества.
		/// </summary>
		[JsonProperty("stats_groups")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public StatsGroups StatsGroups { get; set; }

		/// <summary>
		/// 1 — возвращать дополнительно агрегированные данные в результатах.
		/// </summary>
		[JsonProperty("extended")]
		public bool? Extended { get; set; }

		/// <summary>
		/// Начальная дата выводимой статистики в формате YYYY-MM-DD.
		/// </summary>
		[JsonProperty("date_from")]
		[JsonConverter(typeof(DateTimeToStringFormatConverter), "yyyy-MM-dd")]
		[Obsolete(ObsoleteText.StatsGet)]
		public DateTime DateFrom { get; set; }

		/// <summary>
		/// Конечная дата выводимой статистики в формате YYYY-MM-DD.
		/// </summary>
		[JsonProperty("date_to")]
		[JsonConverter(typeof(DateTimeToStringFormatConverter), "yyyy-MM-dd")]
		[Obsolete(ObsoleteText.StatsGet)]
		public DateTime DateTo { get; set; }
	}
}