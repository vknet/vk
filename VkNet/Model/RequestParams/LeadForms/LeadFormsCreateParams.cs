using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Abstractions.Utils;

namespace VkNet.Model.LeadForms
{
	/// <summary>
	/// Параметры запроса <c>leadForms.createParams</c>
	/// </summary>
	[Serializable]
	public class LeadFormsCreateParams
	{
		/// <summary>
		/// Идентификатор группы, в которой надо создать форму. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// Название формы (видно только администратору). обязательный параметр, строка, максимальная длина 100
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Заголовок формы (видят пользователи). обязательный параметр, строка, максимальная длина 60
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Описание формы. обязательный параметр, строка, максимальная длина 600
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Информация о вопросах формы.
		/// </summary>
		/// <remarks>
		/// Для построения рекомендуется использовать <see cref="ILeadFormsQuestionBuilder"/>
		/// </remarks>
		[JsonProperty("questions")]
		public string Questions { get; set; }

		/// <summary>
		/// Ссылка на политику конфиденциальности. строка, обязательный параметр, максимальная длина 200
		/// </summary>
		[JsonProperty("policy_link_url")]
		public string PolicyLinkUrl { get; set; }

		/// <summary>
		/// Обложка формы.
		/// Используйте значение, полученное после загрузки фотографии на сервер.
		/// См. метод <c>leadForms.getUploadURL</c>.
		/// Также можно переиспользовать существующую фотографию из другой формы.
		/// Используйте значение поля <c>photo</c>, которое возвращает метод <c>leadForms.get</c> или <c>leadForms.list</c>. строка
		/// </summary>
		[JsonProperty("photo")]
		public string Photo { get; set; }

		/// <summary>
		/// Текст подтверждения, который увидит пользователь после отправки формы. строка, максимальная длина 300
		/// </summary>
		[JsonProperty("confirmation")]
		public string Confirmation { get; set; }

		/// <summary>
		/// Ссылка на сайт или сообщество автора формы. строка, максимальная длина 200
		/// </summary>
		[JsonProperty("site_link_url")]
		public string SiteLinkUrl { get; set; }

		/// <summary>
		/// Передайте код пикселя ретаргетинга ВКонтакте в виде <c>VK-RTRG-000000-XXXXX</c>.
		/// По этому пикселю будет собираться аудитория пользователей, открывших форму.
		/// </summary>
		[JsonProperty("pixel_code")]
		public string PixelCode { get; set; }

		/// <summary>
		/// Передайте список email-адресов, разделённых запятой, на которые будут отправлены оповещения о заполнении пользователями формы.
		/// Можно указать до 10 адресов. список слов, разделенных через запятую
		/// </summary>
		[JsonProperty("notify_emails")]
		public IEnumerable<string> NotifyEmails { get; set; }

		/// <summary>
		/// Передайте 1, чтобы активировать форму сразу после создания.
		/// Пользователи могут оставлять заявки только в активных формах.
		/// </summary>
		[JsonProperty("active")]
		public bool Active { get; set; }

		/// <summary>
		/// Передайте 1, чтобы разрешить каждому пользователю заполнять форму только один раз.
		/// </summary>
		[JsonProperty("once_per_user")]
		public bool OncePerUser { get; set; }

		/// <summary>
		/// Передайте список идентификаторов пользователей, которым будут отправлены оповещения о заполнении пользователями формы.
		/// Оповещения могут быть отправлены только администраторам сообщества.
		/// </summary>
		[JsonProperty("notify_admins")]
		public IEnumerable<ulong> NotifyAdmins { get; set; }
	}
}