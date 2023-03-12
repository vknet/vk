using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Объект-запроса на поиск похожей аудитории.
/// </summary>
[Serializable]
public class LookalikeRequestItem
{
	/// <summary>
	/// Идентификатор запроса на поиск похожей аудитории.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Тип источника исходной аудитории для поиска похожей аудитории.
	/// </summary>
	[JsonProperty("source_type")]
	public SourceType SourceType { get; set; }

	/// <summary>
	/// Время создания объявления
	/// </summary>
	[JsonProperty(propertyName: "create_time")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? CreateTime { get; set; }

	/// <summary>
	/// Время последнего изменения объявления
	/// </summary>
	[JsonProperty(propertyName: "update_time")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? UpdateTime { get; set; }

	/// <summary>
	/// Cтатус объявления.
	/// </summary>
	[JsonProperty(propertyName: "status")]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public AdRequestStatus Status { get; set; }

	/// <summary>
	/// Дата запланированного удаления запроса.
	/// </summary>
	[JsonProperty(propertyName: "scheduled_delete_time")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? ScheduledDeleteTime { get; set; }

	/// <summary>
	/// Идентификатор аудитории ретаргетинга с исходной аудиторией.
	/// </summary>
	[JsonProperty(propertyName: "source_retargeting_group_id")]
	public long? SourceRetargetingGroupId { get; set; }

	/// <summary>
	/// Имя источника исходной аудитории.
	/// </summary>
	[JsonProperty(propertyName: "source_name")]
	public string SourceName { get; set; }

	/// <summary>
	/// Размер исходной аудитории.
	/// </summary>
	[JsonProperty(propertyName: "audience_count")]
	public long AudienceCount { get; set; }

	/// <summary>
	/// Список доступных размеров аудитории для сохранения.
	/// </summary>
	[JsonProperty(propertyName: "save_audience_levels")]
	public ReadOnlyCollection<SaveAudienceLevels> SaveAudienceLevels { get; set; }
}