using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.edit
	/// </summary>
	[Serializable]
	public class WallEditParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, на стене которого находится запись.
		/// Обратите внимание, идентификатор
		/// сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию
		/// идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор записи на стене. положительное число, обязательный параметр.
		/// </summary>
		public long PostId { get; set; }

		/// <summary>
		/// 1 — запись будет доступна только друзьям, 0 — всем пользователям.
		/// Параметр учитывается только при редактировании отложенной записи. флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? FriendsOnly { get; set; }

		/// <summary>
		/// Текст сообщения (является обязательным, если не задан параметр attachments)
		/// строка.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Список объектов, приложенных к записи и разделённых символом ",". Поле
		/// attachments представляется в формате:
		/// &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;
		/// media_id&gt;
		/// &lt;type&gt; — тип медиа-приложения:
		/// photo — фотография
		/// video — видеозапись
		/// audio — аудиозапись
		/// doc — документ
		/// graffiti — граффити
		/// page — wiki-страница
		/// note — заметка
		/// poll — опрос
		/// album — альбом.
		/// &lt;owner_id&gt; — идентификатор владельца медиа-приложения;
		/// &lt;media_id&gt; — идентификатор медиа-приложения.
		/// Например:
		/// photo100172_166443618,photo66748_265827614
		/// Также в поле attachments может быть указана ссылка на внешнюю страницу, которую
		/// Вы хотите разместить в статусе,
		/// например:
		/// photo66748_265827614,http://habrahabr.ru
		/// При попытке приложить больше одной ссылки будет возвращена ошибка.
		/// Параметр является обязательным, если не задан параметр message. список строк,
		/// разделенных через запятую.
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Список сервисов или сайтов, на которые необходимо экспортировать запись, в
		/// случае если пользователь настроил
		/// соответствующую опцию. Например, twitter, facebook.
		/// Параметр учитывается только при редактировании отложенной записи. строка.
		/// </summary>
		public IEnumerable<Services> Services { get; set; }

		/// <summary>
		/// 1 — у записи, размещенной от имени сообщества будет добавлена подпись (имя
		/// пользователя, разместившего запись), 0 —
		/// подписи добавлено не будет.
		/// Параметр учитывается только при редактировании записи на стене сообщества,
		/// опубликованной от имени группы. флаг,
		/// может принимать значения 1 или 0.
		/// </summary>
		public bool? Signed { get; set; }

		/// <summary>
		/// Дата публикации записи в формате unixtime. Если параметр не указан, отложенная
		/// запись будет опубликована.
		/// Параметр учитывается только при редактировании отложенной записи. положительное
		/// число.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? PublishDate { get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах (от -90 до 90). дробное
		/// число.
		/// </summary>
		public double? Lat { get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах (от -180 до 180). дробное
		/// число.
		/// </summary>
		public double? Long { get; set; }

		/// <summary>
		/// Идентификатор места, в котором отмечен пользователь. положительное число.
		/// </summary>
		public long? PlaceId { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }

		/// <summary>
		/// 1 — у записи, размещенной от имени сообщества, будет добавлена метка "это
		/// реклама",
		/// 0 — метки добавлено не будет/снять установленную метку.
		/// Метка может быть снята в течение пяти минут после её установки.
		/// В сутки может быть опубликовано не более пяти рекламных записей, из которых не
		/// более трёх — вне Биржи ВКонтакте.
		/// </summary>
		[JsonProperty(propertyName: "mark_as_ads")]
		public bool? MarkAsAds { get; set; }

		/// <summary>
		/// Флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty(propertyName: "close_comments")]
		public bool? CloseComments { get; set; }

		/// <summary>
		/// No description.
		/// Положительное число
		/// </summary>
		[JsonProperty(propertyName: "poster_bkg_id")]
		public long? PosterBackgroundId { get; set; }

		/// <summary>
		/// Целое число
		/// </summary>
		[JsonProperty("poster_bkg_owner_id")]
		public long PosterBackgroundOwnerId { get; set; }

		/// <summary>
		/// Строка
		/// </summary>
		[JsonProperty("poster_bkg_access_hash")]
		public string PosterBackgroundAccessHash { get; set; }

		/// <summary>
		/// Источник материала. Поддерживаются внешние и внутренние ссылки. строка
		/// </summary>
		[JsonProperty("copyright")]
		public string Copyright { get; set; }
	}
}