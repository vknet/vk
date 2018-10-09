using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.LeadForms
{
	/// <summary>
	/// Параметры запроса leadForms.updateParams
	/// </summary>
	[Serializable]
	public class LeadFormsUpdateParams
	{
		/// <summary>
		/// Идентификатор группы, в которой надо обновить форму. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// Идентификатор формы, которую надо обновить. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("form_id")]
		public long FormId { get; set; }

		/// <summary>
		/// Новое название формы (видно только администратору). обязательный параметр, строка, максимальная длина 100
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Новый заголовок формы (видят пользователи). обязательный параметр, строка, максимальная длина 60
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Новое описание формы. обязательный параметр, строка, максимальная длина 600
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Новые вопросы формы. Подробнее см. метод leadForms.create. данные в формате JSON, обязательный параметр
		/// </summary>
		[JsonProperty("questions")]
		public object Questions { get; set; }

		/// <summary>
		/// Новая ссылка на политику конфиденциальности. строка, обязательный параметр, максимальная длина 200
		/// </summary>
		[JsonProperty("policy_link_url")]
		public string PolicyLinkUrl { get; set; }

		/// <summary>
		/// Новая обложка формы. строка
		/// </summary>
		[JsonProperty("photo")]
		public string Photo { get; set; }

		/// <summary>
		/// Новый текст подтверждения, который увидит пользователь после отправки формы. строка, максимальная длина 300
		/// </summary>
		[JsonProperty("confirmation")]
		public string Confirmation { get; set; }

		/// <summary>
		/// Новая ссылка на сайт или сообщество автора формы. строка, максимальная длина 200
		/// </summary>
		[JsonProperty("site_link_url")]
		public string SiteLinkUrl { get; set; }

		/// <summary>
		/// Новый код пикселя ретаргетинга ВКонтакте. строка
		/// </summary>
		[JsonProperty("pixel_code")]
		public string PixelCode { get; set; }

		/// <summary>
		/// Новый список email-адресов, разделённых запятой, на которые будут отправлены оповещения о заполнении пользователями формы. Можно указать до 10 адресов. список слов, разделенных через запятую
		/// </summary>
		[JsonProperty("notify_emails")]
		public IEnumerable<string> NotifyEmails { get; set; }

		/// <summary>
		/// Передайте 1, чтобы активировать форму. Пользователи могут оставлять заявки только в активных формах. флаг, может принимать значения 1 или 0, по умолчанию 0
		/// </summary>
		[JsonProperty("active")]
		public bool Active { get; set; }

		/// <summary>
		/// Передайте 1, чтобы разрешить каждому пользователю заполнять форму только один раз. флаг, может принимать значения 1 или 0, по умолчанию 0
		/// </summary>
		[JsonProperty("once_per_user")]
		public bool OncePerUser { get; set; }

		/// <summary>
		/// Новый список идентификаторов пользователей, которым будут отправлены оповещения о заполнении пользователями формы. Оповещения могут быть отправлены только администраторам сообщества. список положительных чисел, разделенных запятыми
		/// </summary>
		[JsonProperty("notify_admins")]
		public IEnumerable<ulong> NotifyAdmins { get; set; }
	}
}