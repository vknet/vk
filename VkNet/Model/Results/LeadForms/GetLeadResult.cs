using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Lead.
	/// </summary>
	[Serializable]
	public class GetLeadResult
	{
		/// <summary>
		/// идентификатор заявки
		/// </summary>
		[JsonProperty("lead_id")]
		public long LeadId { get; set; }

		/// <summary>
		/// идентификатор пользователя, оставившего заявку
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// дата и время оставления заявки в формате unix timestamp
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// информация об ответах на вопросы — массив структур со следующими полями
		/// </summary>
		[JsonProperty("answers")]
		public ReadOnlyCollection<LeadAnswerInfo> Answers { get; set; }

		/// <summary>
		/// идентификатор рекламного объявления, с которого пришла заявка (поле отсутствует в случае, если заявка пришла не из рекламного объявления).
		/// </summary>
		[JsonProperty("ad_id")]
		public long? AdId { get; set; }
	}
}