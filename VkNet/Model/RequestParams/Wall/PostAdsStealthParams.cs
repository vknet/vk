using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// параметры запроса wall.PostAdsStealth
	/// </summary>
	[Serializable]
	public class PostAdsStealthParams
	{
		/// <summary>
		/// идентификатор владельца стены (идентификатор сообщества нужно указывать со
		/// знаком «минус»).
		/// </summary>
		[JsonProperty(propertyName: "owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// текст записи
		/// </summary>
		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }

		/// <summary>
		/// список объектов, приложенных к записи и разделённых символом ",".
		/// </summary>
		[JsonProperty(propertyName: "attachments")]
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// 1 — у записи, размещенной от имени сообщества, будет добавлена подпись (имя
		/// пользователя, разместившего запись),
		/// 0 — без подписи.
		/// </summary>
		[JsonProperty(propertyName: "signed")]
		public bool? Signed { get; set; }

		/// <summary>
		/// географическая широта отметки, заданная в градусах (от -90 до 90)
		/// </summary>
		[JsonProperty(propertyName: "lat")]
		public double Lat { get; set; }

		/// <summary>
		/// географическая долгота отметки, заданная в градусах (от -180 до 180).
		/// </summary>
		[JsonProperty(propertyName: "long")]
		public double Long { get; set; }

		/// <summary>
		/// идентификатор места.
		/// </summary>
		[JsonProperty(propertyName: "place_id")]
		public ulong PlaceId { get; set; }

		/// <summary>
		/// уникальный идентификатор, предназначенный для предотвращения повторной отправки
		/// одинаковой записи.
		/// </summary>
		[JsonProperty(propertyName: "guid")]
		public string Guid { get; set; }

		/// <summary>
		/// идентификатор кнопки, которую необходимо добавить к сниппету для ссылки.
		/// </summary>
		[JsonProperty(propertyName: "link_button")]
		public LinkButton LinkButton { get; set; }

		/// <summary>
		/// заголовок, который должен быть использован для сниппета.
		/// Если не указан, будет автоматически получен с целевой ссылки.
		/// Обязательно указывать в случае, если ссылка является номером телефона.
		/// </summary>
		[JsonProperty(propertyName: "link_title")]
		public string LinkTitle { get; set; }

		/// <summary>
		/// ссылка на изображение, которое должно быть использовано для сниппета.
		/// Минимальное разрешение: 537x240.
		/// Если не указана, будет автоматически загружена с целевой ссылки.
		/// Обязательно указывать в случае, если ссылка является номером телефона.
		/// </summary>
		[JsonProperty(propertyName: "link_image")]
		public string LinkImage { get; set; }
	}
}