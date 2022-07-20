using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Описание рекламного аккаунта.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getAccounts
	/// </remarks>
	[Serializable]
	public class Ad
	{
		/// <summary>
		/// Идентификатор рекламного объявления.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор кампании.
		/// </summary>
		[JsonProperty("campaign_id")]
		public long CampaignId { get; set; }

		/// <summary>
		/// Формат объявления
		/// </summary>
		[JsonProperty("ad_format")]
		public AdFormat AdFormat { get; set; }

		/// <summary>
		/// Тип оплаты
		/// </summary>
		[JsonProperty("cost_type")]
		public CostType CostType { get; set; }

		/// <summary>
		/// Цена за переход в копейках. (если cost_type = 0)
		/// </summary>
		[JsonProperty("cpc")]
		public long Cpc { get; set; }

		/// <summary>
		/// Цена за 1000 показов в копейках. (если cost_type = 1)
		/// </summary>
		[JsonProperty("cpm")]
		public long Cpm { get; set; }

		/// <summary>
		/// Цена за 1000 показов в копейках. (если cost_type = 1)
		/// </summary>
		[JsonProperty("ocpm")]
		public long OCpm { get; set; }

		/// <summary>
		/// (если задано) Ограничение количества показов данного объявления на одного пользователя.
		/// Может присутствовать для некоторых форматов объявлений, для которых разрешена установка точного значения.
		/// </summary>
		[JsonProperty("impressions_limit")]
		public long ImpressionsLimit { get; set; }

		/// <summary>
		/// (если задано) Признак того, что количество показов объявления на одного пользователя ограничено.
		/// Может присутствовать для некоторых объявлений, для которых разрешена установка ограничения, но не разрешена установка точного значения.
		/// 1 — не более 100 показов на одного пользователя.
		/// </summary>
		[JsonProperty("impressions_limited")]
		public long ImpressionsLimited { get; set; }

		/// <summary>
		/// Рекламные площадки, на которых будет показываться объявление. (если значение применимо к данному формату объявления)
		/// </summary>
		[JsonProperty("ad_platform")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AdPlatform AdPlatform { get; set; }

		/// <summary>
		/// 1 — для объявления задано ограничение «Не показывать на стенах сообществ».
		/// </summary>
		[JsonProperty("ad_platform_no_wall")]
		public bool AdPPlatformNoWall { get; set; }

		/// <summary>
		/// 1 — для объявления задано ограничение «Показывать в рекламной сети».
		/// </summary>
		[JsonProperty("ad_platform_no_ad_network")]
		public bool AdPlatformNoAdNetwork { get; set; }

		/// <summary>
		/// Общий лимит объявления в рублях. 0 — лимит не задан.
		/// </summary>
		[JsonProperty("all_limit")]
		public long AllLimit { get; set; }

		/// <summary>
		/// Дневной лимит объявления в рублях. 0 — лимит не задан.
		/// </summary>
		[JsonProperty("day_limit")]
		public long DayLimit { get; set; }

		/// <summary>
		/// Ограничение по возрасту
		/// </summary>
		[JsonProperty("age_restriction")]
		public AdAgeRestriction AgeRestriction { get; set; }

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
		/// ID тематики или подраздела тематики объявления.
		/// </summary>
		[JsonProperty(propertyName: "category1_id")]
		public long Category1Id { get; set; }

		/// <summary>
		/// ID тематики или подраздела тематики объявления. Дополнительная тематика.
		/// </summary>
		[JsonProperty(propertyName: "category2_id")]
		public long Category2Id { get; set; }

		/// <summary>
		/// Cтатус объявления.
		/// </summary>
		[JsonProperty(propertyName: "status")]
		public AdStatus Status { get; set; }

		/// <summary>
		/// Название объявления.
		/// </summary>
		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }

		/// <summary>
		/// Cтатус модерации объявления
		/// </summary>
		[JsonProperty(propertyName: "approved")]
		public ModerationStatus ModerationStatus { get; set; }

		/// <summary>
		/// Объявление является видеорекламой
		/// </summary>
		[JsonProperty(propertyName: "video")]
		public long Video { get; set; }

		/// <summary>
		/// Включено отображение предупреждения: «Есть противопоказания.Требуется консультация специалиста.»
		/// </summary>
		[JsonProperty(propertyName: "disclaimer_medical")]
		public long DisclaimerMedical { get; set; }

		/// <summary>
		/// Включено отображение предупреждения: «Необходима консультация специалистов.»
		/// </summary>
		[JsonProperty(propertyName: "disclaimer_specialist")]
		public long DisclaimerSpecialist { get; set; }

		/// <summary>
		/// Включено отображение предупреждения: «БАД.Не является лекарственным препаратом.»
		/// </summary>
		[JsonProperty(propertyName: "disclaimer_supplements")]
		public long DisclaimerSupplements { get; set; }

		/// <summary>
		/// Только для ad_format = 9 (Public). Описание событий, собираемых в группы ретаргетинга. Массив объектов, где ключом является id группы ретаргетинга, а значением - массив событий.
		/// </summary>
		/// <remarks>
		/// TODO: выпилить ToNullIfArrayConverter
		/// </remarks>
		[JsonProperty("events_retargeting_groups")]
		[JsonConverter(typeof(ToNullIfArrayConverter<Dictionary<long, List<EventsRetargetingGroup>>>))]
		public Dictionary<long, List<EventsRetargetingGroup>> EventsRetargetingGroups { get; set; }
	}
}