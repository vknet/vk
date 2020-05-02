using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Abstractions.Utils;

namespace VkNet.Model.LeadForms
{
	/// <summary>
	/// Параметры запроса <c>leadForms.updateParams</c>
	/// </summary>
	[Serializable]
	public class LeadFormsUpdateParams
	{
		/// <summary>
		/// Идентификатор группы, в которой надо обновить форму.
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// Идентификатор формы, которую надо обновить.
		/// </summary>
		[JsonProperty("form_id")]
		public long FormId { get; set; }

		/// <summary>
		/// Новое название формы (видно только администратору).
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Новый заголовок формы (видят пользователи).
		/// Максимальная длина 60
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Новое описание формы.
		/// Максимальная длина 600
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Новые вопросы формы. Подробнее см. метод <c>leadForms.create</c>. данные в формате JSON
		/// </summary>
		/// <remarks>
		/// Для построения рекомендуется использовать <see cref="ILeadFormsQuestionBuilder"/>
		/// </remarks>
		[JsonProperty("questions")]
		public string Questions { get; set; }

		/// <summary>
		/// Новая ссылка на политику конфиденциальности.
		/// Максимальная длина 200
		/// </summary>
		[JsonProperty("policy_link_url")]
		public string PolicyLinkUrl { get; set; }

		/// <summary>
		/// Новая обложка формы.
		/// </summary>
		[JsonProperty("photo")]
		public string Photo { get; set; }

		/// <summary>
		/// Новый текст подтверждения, который увидит пользователь после отправки формы.
		/// Максимальная длина 300
		/// </summary>
		[JsonProperty("confirmation")]
		public string Confirmation { get; set; }

		/// <summary>
		/// Новая ссылка на сайт или сообщество автора формы.
		/// Максимальная длина 200
		/// </summary>
		[JsonProperty("site_link_url")]
		public string SiteLinkUrl { get; set; }

		/// <summary>
		/// Новый код пикселя ретаргетинга ВКонтакте.
		/// </summary>
		[JsonProperty("pixel_code")]
		public string PixelCode { get; set; }

		/// <summary>
		/// Новый список email-адресов, разделённых запятой, на которые
		/// будут отправлены оповещения о заполнении пользователями формы.
		/// Можно указать до 10 адресов.
		/// </summary>
		[JsonProperty("notify_emails")]
		public IEnumerable<string> NotifyEmails { get; set; }

		/// <summary>
		/// Передайте <c>true</c>, чтобы активировать форму.
		/// Пользователи могут оставлять заявки только в активных формах.
		/// </summary>
		[JsonProperty("active")]
		public bool Active { get; set; }

		/// <summary>
		/// Передайте <c>true</c>, чтобы разрешить каждому пользователю заполнять форму только один раз.
		/// </summary>
		[JsonProperty("once_per_user")]
		public bool OncePerUser { get; set; }

		/// <summary>
		/// Новый список идентификаторов пользователей, которым будут отправлены оповещения о заполнении пользователями формы.
		/// Оповещения могут быть отправлены только администраторам сообщества.
		/// </summary>
		[JsonProperty("notify_admins")]
		public IEnumerable<ulong> NotifyAdmins { get; set; }
	}
}