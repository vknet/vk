using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Возвращает список кампаний рекламного кабинета.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getCampaigns
	/// </remarks>
	[Serializable]
	public class AdsCampaign
	{
		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public long Id { get; set; }

		/// <summary>
		/// Тип кампании
		/// </summary>
		[JsonProperty(propertyName: "type")]
		[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
		public CampaignType Type { get; set; }

		/// <summary>
		/// Название кампании
		/// </summary>
		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }

		/// <summary>
		/// Статус кампании
		/// </summary>
		[JsonProperty(propertyName: "status")]
		[JsonConverter(converterType: typeof(StringEnumConverter))]
		public CampaignStatus Status { get; set; }

		/// <summary>
		/// Дневной лимит кампании в рублях
		/// </summary>
		[JsonProperty(propertyName: "day_limit")]
		public int DayLimit { get; set; }

		/// <summary>
		/// Общий лимит кампании в рублях
		/// </summary>
		[JsonProperty(propertyName: "all_limit")]
		public int AllLimit { get; set; }

		/// <summary>
		/// Время запуска кампании в формате unixtime
		/// </summary>
		[JsonProperty(propertyName: "start_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Время запуска кампании в формате unixtime
		/// </summary>
		[JsonProperty(propertyName: "stop_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? StopTime { get; set; }

		/// <summary>
		/// Время создания кампании в формате unixtime
		/// </summary>
		[JsonProperty(propertyName: "create_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// Время последнего изменения кампании в формате unixtime
		/// </summary>
		[JsonProperty(propertyName: "update_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? UpdateTime { get; set; }

	#region Методы

		/// <summary>
		/// Информация о рекламном аккаунте
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static AdsCampaign FromJson(VkResponse response)
		{
			if (response[key: "id"] == null)
			{
				return null;
			}

			var campaign = new AdsCampaign
			{
					Id = response[key: "id"]
					, Type = response[key: "type"]
					, Name = response[key: "name"]
					, Status = response[key: "status"]
					, DayLimit = response[key: "day_limit"]
					, AllLimit = response[key: "all_limit"]
					, StartTime = response[key: "start_time"]
					, StopTime = response[key: "stop_time"]
			};

			return campaign;
		}

	#endregion
	}
}