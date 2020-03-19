using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	[Serializable]
	public class BoardTopicParams
	{
		/// <summary>
		/// Идентификатор сообщества, в котором находится обсуждение.положительное число,
		/// обязательный параметр
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// Идентификатор сообщества, в котором находится обсуждение.положительное число,
		/// обязательный параметр
		/// </summary>
		[JsonProperty(propertyName: "topic_id")]
		public long TopicId { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[JsonProperty(propertyName: "captcha_sid")]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// Текст, который ввел пользователь
		/// </summary>
		[JsonProperty(propertyName: "captcha_key")]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }
	}
}