﻿using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.post
	/// </summary>
	public struct WallPostParams
	{
		/// <summary>
		/// Параметры метода wall.post
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public WallPostParams(bool gag = true)
		{
			OwnerId = null;
			FriendsOnly = null;
			FromGroup = null;
			Message = null;
			Attachments = null;
			Services = null;
			Signed = null;
			PublishDate = null;
			Lat = null;
			Long = null;
			PlaceId = null;
			PostId = null;
			CaptchaSid = null;
			CaptchaKey = null;
		}

		/// <summary>
		/// Идентификатор пользователя или сообщества, на стене которого должна быть опубликована запись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// 1 — запись будет доступна только друзьям, 0 — всем пользователям. По умолчанию публикуемые записи доступны всем пользователям. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? FriendsOnly { get; set; }

		/// <summary>
		/// Данный параметр учитывается, если owner_id &lt; 0 (запись публикуется на стене группы). 1 — запись будет опубликована от имени группы, 0 — запись будет опубликована от имени пользователя (по умолчанию). флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? FromGroup { get; set; }

		/// <summary>
		/// Текст сообщения (является обязательным, если не задан параметр attachments) строка.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Список объектов, приложенных к записи и разделённых символом ",". Поле attachments представляется в формате:
		/// &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;
		///
		/// &lt;type&gt; — тип медиа-приложения:
		///
		/// photo — фотография;
		/// video — видеозапись ;
		/// audio — аудиозапись;
		/// doc — документ;
		/// page — wiki-страница;
		/// note — заметка;
		/// poll — опрос.
		/// album — альбом.
		///
		/// &lt;owner_id&gt; — идентификатор владельца медиа-приложения (обратите внимание, если объект находится в сообществе, этот параметр должен быть отрицательным).
		/// &lt;media_id&gt; — идентификатор медиа-приложения.
		///
		/// Например:
		/// photo100172_166443618,photo66748_265827614
		///
		/// Также в поле attachments может быть указана ссылка на внешнюю страницу, которую Вы хотите разместить в записи, например:
		/// photo66748_265827614,http://habrahabr.ru
		///
		/// При попытке приложить больше одной ссылки будет возвращена ошибка.
		///
		/// Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Список сервисов или сайтов, на которые необходимо экспортировать запись, в случае если пользователь настроил соответствующую опцию. Например, twitter, facebook. строка.
		/// </summary>
		public IEnumerable<Services> Services { get; set; }

		/// <summary>
		/// 1 — у записи, размещенной от имени сообщества, будет добавлена подпись (имя пользователя, разместившего запись), 0 — подписи добавлено не будет. Параметр учитывается только при публикации на стене сообщества и указании параметра from_group. По умолчанию подпись не добавляется. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Signed { get; set; }

		/// <summary>
		/// Дата публикации записи в формате unixtime. Если параметр указан, публикация записи будет отложена до указанного времени. положительное число.
		/// </summary>
		public DateTime? PublishDate { get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах (от -90 до 90). дробное число.
		/// </summary>
		public double? Lat { get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах (от -180 до 180). дробное число.
		/// </summary>
		public double? Long { get; set; }

		/// <summary>
		/// Идентификатор места, в котором отмечен пользователь. положительное число.
		/// </summary>
		public long? PlaceId { get; set; }

		/// <summary>
		/// Идентификатор записи, которую необходимо опубликовать. Данный параметр используется для публикации отложенных записей и предложенных новостей. положительное число.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// Текст капчи, который ввел пользователь
		/// </summary>
		public string CaptchaKey { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(WallPostParams p)
		{
			var result = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "friends_only", p.FriendsOnly },
				{ "from_group", p.FromGroup },
				{ "message", p.Message },
				{ "attachments", p.Attachments },
				{ "services", p.Services },
				{ "signed", p.Signed },
				{ "publish_date", p.PublishDate },
				{ "lat", p.Lat },
				{ "long", p.Long },
				{ "place_id", p.PlaceId },
				{ "post_id", p.PostId },
				{ "captcha_sid", p.CaptchaSid },
				{ "captcha_key", p.CaptchaKey }
			};

			return result;
		}
	}
}