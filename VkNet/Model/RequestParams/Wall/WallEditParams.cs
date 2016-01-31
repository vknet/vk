﻿using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.edit
	/// </summary>
	public struct WallEditParams
	{
		/// <summary>
		/// Параметры метода wall.edit
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public WallEditParams(bool gag = true)
		{
			OwnerId = null;
			PostId = 0;
			FriendsOnly = null;
			Message = null;
			Attachments = null;
			Services = null;
			Signed = null;
			PublishDate = null;
			Lat = null;
			Long = null;
			PlaceId = null;
		}


		/// <summary>
		/// Идентификатор пользователя или сообщества, на стене которого находится запись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор записи на стене. положительное число, обязательный параметр.
		/// </summary>
		public long PostId { get; set; }

		/// <summary>
		/// 1 — запись будет доступна только друзьям, 0 — всем пользователям. 
		/// Параметр учитывается только при редактировании отложенной записи. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? FriendsOnly { get; set; }

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
		/// 
		/// photo — фотография 
		/// video — видеозапись 
		/// audio — аудиозапись 
		/// doc — документ 
		/// graffiti — граффити 
		/// page — wiki-страница 
		/// note — заметка 
		/// poll — опрос 
		/// album — альбом. 
		/// 
		/// &lt;owner_id&gt; — идентификатор владельца медиа-приложения;
		/// &lt;media_id&gt; — идентификатор медиа-приложения.
		/// 
		/// Например:
		/// photo100172_166443618,photo66748_265827614
		/// 
		/// Также в поле attachments может быть указана ссылка на внешнюю страницу, которую Вы хотите разместить в статусе, например:
		/// photo66748_265827614,http://habrahabr.ru
		/// 
		/// При попытке приложить больше одной ссылки будет возвращена ошибка. 
		/// 
		/// Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Список сервисов или сайтов, на которые необходимо экспортировать запись, в случае если пользователь настроил соответствующую опцию. Например, twitter, facebook. 
		/// Параметр учитывается только при редактировании отложенной записи. строка.
		/// </summary>
		public IEnumerable<Services> Services { get; set; }

		/// <summary>
		/// 1 — у записи, размещенной от имени сообщества будет добавлена подпись (имя пользователя, разместившего запись), 0 — подписи добавлено не будет. 
		/// Параметр учитывается только при редактировании записи на стене сообщества, опубликованной от имени группы. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Signed { get; set; }

		/// <summary>
		/// Дата публикации записи в формате unixtime. Если параметр не указан, отложенная запись будет опубликована. 
		/// Параметр учитывается только при редактировании отложенной записи. положительное число.
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
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(WallEditParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "post_id", p.PostId },
				{ "friends_only", p.FriendsOnly },
				{ "message", p.Message },
				{ "attachments", p.Attachments },
				{ "services", p.Services },
				{ "signed", p.Signed },
				{ "publish_date", p.PublishDate },
				{ "lat", p.Lat },
				{ "long", p.Long },
				{ "place_id", p.PlaceId }
			};

			return parameters;
		}
	}
}