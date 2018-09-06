using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.getTargetingStats
	/// </summary>
	[Serializable]
	public class GetTargetingStatsParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Сериализованный JSON-объект, описывающий параметры таргетинга. Описание объекта criteria см. ниже. Игнорируется, если задан параметр ad_id. строка
		/// </summary>
		[JsonProperty("criteria")]
		public string Criteria { get; set; }

		/// <summary>
		/// Рекламные площадки, на которых будет показываться объявление:
		/// (если ad_format равен 1)
		/// 0 — ВКонтакте и сайты-партнёры;
		/// 1 — только ВКонтакте.
		/// (если ad_format равен 9)
		/// all — все площадки;
		/// desktop — полная версия сайта;
		/// mobile — мобильный сайт и приложения.
		/// строка
		/// </summary>
		[JsonProperty("ad_platform")]
		public string AdPlatform { get; set; }

		/// <summary>
		/// Для ad_format = 9.
		/// 1 — не показывать объявление на стенах сообществ. По умолчанию: 0. строка
		/// </summary>
		[JsonProperty("ad_platform_no_wall")]
		public string AdPlatformNoWall { get; set; }

		/// <summary>
		/// Ссылка на рекламируемый объект. обязательный параметр, строка
		/// </summary>
		[JsonProperty("link_url")]
		public string LinkUrl { get; set; }

		/// <summary>
		/// Домен рекламируемого объекта. строка
		/// </summary>
		[JsonProperty("link_domain")]
		public string LinkDomain { get; set; }

		/// <summary>
		/// Обязательный параметр для агентских кабинетов целое число
		/// </summary>
		[JsonProperty("client_id")]
		public long ClientId { get; set; }

		/// <summary>
		/// Идентификатор рекламного объявления, чьи параметры таргетинга требуется анализировать. Если задан этот параметр, criteria игнорируется. целое число
		/// </summary>
		[JsonProperty("ad_id")]
		public long AdId { get; set; }

		/// <summary>
		/// Формат объявления:
		/// 1 — изображение и текст;
		/// 2 — большое изображение;
		/// 3 — эксклюзивный формат;
		/// 4 — продвижение сообществ или приложений, квадратное изображение;
		/// 7 — специальный формат приложений;
		/// 8 — специальный формат сообществ;
		/// 9 — запись в сообществе;
		/// 10 — витрина приложений.
		/// целое число
		/// </summary>
		[JsonProperty("ad_format")]
		public long AdFormat { get; set; }
	}
}