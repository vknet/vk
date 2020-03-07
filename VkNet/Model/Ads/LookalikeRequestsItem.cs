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
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
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
		public DateTime? ScheduledDeleteTime  { get; set; }

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

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static LookalikeRequestItem FromJson(VkResponse response)
		{
			return new LookalikeRequestItem
			{
				Id = response["id"],
				CreateTime = response["create_time"],
				UpdateTime = response["update_time"],
				Status = response["status"],
				SourceType = response["source_type"],
				SourceName = response["source_name"],
				ScheduledDeleteTime = response["scheduled_delete_time"],
				SourceRetargetingGroupId = response["source_retargeting_group_id"],
				AudienceCount = response["audience_count"],
				SaveAudienceLevels = response["save_audience_levels"].ToReadOnlyCollectionOf<SaveAudienceLevels>(x=>x)
			};
		}
	}
}