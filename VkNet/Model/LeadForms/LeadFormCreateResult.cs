using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода LeadForm.Create
	/// </summary>
	[Serializable]
	public class LeadFormCreateResult
	{
		/// <summary>
		/// Идентификатор формы
		/// </summary>
		[JsonProperty("form_id")]
		public long? FormId { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("confirmation")]
		public string Confirmation { get; set; }

		[JsonProperty("site_link_url")]
		public string SiteLinkUrl { get; set; }

		[JsonProperty("policy_link_url")]
		public string PolicyLinkUrl { get; set; }

		/// <summary>
		/// Вопросы.
		/// </summary>
		[JsonProperty("questions")]
		public LeadFormQuestion[] Questions { get; set; }

		[JsonProperty("active")]
		public long Active { get; set; }

		/// <summary>
		/// Количество заявок
		/// </summary>
		[JsonProperty("leads_count")]
		public long LeadsCount { get; set; }

		[JsonProperty("pixel_code")]
		public string PixelCode { get; set; }

		[JsonProperty("once_per_user")]
		public long OncePerUser { get; set; }

		[JsonProperty("notify_admins")]
		public string NotifyAdmins { get; set; }

		[JsonProperty("notify_emails")]
		public string NotifyEmails { get; set; }

		/// <summary>
		/// Ссылка на форму
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }
	}
}