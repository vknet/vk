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
	/// Массив объектов UserSpecification
	/// </summary>
	[Serializable]
	public class AdSpecification
	{
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
		/// Автоматическое управление ценой
		/// </summary>
		[JsonProperty("autobidding")]
		public AutoBidding AutoBidding { get; set; }

		/// <summary>
		/// Тип оплаты
		/// </summary>
		[JsonProperty("cost_type")]
		public CostType CostType { get; set; }

		/// <summary>
		/// Цена за переход в копейках. (если cost_type = 0)
		/// </summary>
		[JsonProperty("cpc")]
		public double Cpc { get; set; }

		/// <summary>
		/// Цена за 1000 показов в копейках. (если cost_type = 1)
		/// </summary>
		[JsonProperty("cpm")]
		public double Cpm { get; set; }

		/// <summary>
		/// Цена указывается в рублях с копейками в дробной части. (если cost_type = 1)
		/// </summary>
		[JsonProperty("ocpm")]
		public double OCpm { get; set; }

		/// <summary>
		/// Тип цели.
		/// </summary>
		[JsonProperty("goal_type")]
		public GoalType GoalType { get; set; }

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
		/// Заголовок объявления.
		/// </summary>
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }

		/// <summary>
		/// Описание объявления.
		/// </summary>
		[JsonProperty(propertyName: "description")]
		public string Description { get; set; }

		/// <summary>
		/// Cсылка на рекламируемый объект в формате.
		/// http://yoursite.cоm, или
		/// https://vk.com/wall-22822305_383737, или
		/// http://vk.cоm/club1
		/// </summary>
		[JsonProperty(propertyName: "link_url")]
		public Uri LinkUrl { get; set; }

		/// <summary>
		/// домен рекламируемого объекта в формате
		/// yoursite.cоm
		/// </summary>
		[JsonProperty(propertyName: "link_domain")]
		public Uri LinkDomain { get; set; }

		/// <summary>
		/// Заголовок рядом с кнопкой.
		/// </summary>
		[JsonProperty(propertyName: "link_title")]
		public Uri LinkTitle { get; set; }

		/// <summary>
		/// Идентификатор кнопки объявления.
		/// </summary>
		[JsonProperty(propertyName: "link_button")]
		public Uri LinkButton { get; set; }

		/// <summary>
		/// Основное изображение.
		/// </summary>
		[JsonProperty(propertyName: "photo")]
		public UploadUrlResult Photo { get; set; }

		/// <summary>
		/// Основное видео.
		/// </summary>
		[JsonProperty(propertyName: "video")]
		public UploadUrlResult Video { get; set; }

		/// <summary>
		/// Зацикливание видео.
		/// </summary>
		[JsonProperty(propertyName: "repeat_video")]
		public RepeatVideo RepeatVideo { get; set; }

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
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AdSpecification FromJson(VkResponse response)
		{
			return new AdSpecification
			{
				CampaignId = response["campaign_id"],
				AdFormat = response["ad_format"],
				AutoBidding=response["autobidding"],
				CostType =  response["cost_type"],
				Cpc = response["cpc"],
				Cpm= response["cpm"],
				OCpm = response["ocpm"],
				GoalType = response["goal_type"],
				ImpressionsLimit = response["impressions_limit"],
				ImpressionsLimited = response["impressions_limited"],
				AdPlatform = response["ad_platform"],
				AdPlatformNoAdNetwork = response["ad_platform_no_ad_network"],
				AllLimit = response["all_limit"],
				DayLimit = response["day_limit"],
				AgeRestriction = response["age_restriction"],
				CreateTime = response["create_time"],
				UpdateTime = response["update_time"],
				Category1Id = response["category1_id"],
				Category2Id = response["category2_id"],
				Status = response["status"],
				Name = response["name"],
				Title = response["title"],
				Description = response["description"],
				LinkButton = response["link_button"],
				LinkDomain = response["link_domain"],
				LinkTitle = response["link_title"],
				LinkUrl = response["link_url"],
				Photo = response["photo"],
				Video = response["video"],
				RepeatVideo = response["repeat_video"],
				DisclaimerMedical = response["disclaimer_medical"],
				DisclaimerSpecialist = response["disclaimer_specialist"],
				DisclaimerSupplements = response["disclaimer_supplements"]
			};
		}
	}
}