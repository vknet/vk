using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	[Serializable]
	public class BoardEditTopicParams
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
		/// Новое название обсуждения. Обязательный параметр.
		/// </summary>
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[JsonProperty(propertyName: "captcha_sid")]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// Текст, который ввел пользователь
		/// </summary>
		[JsonProperty(propertyName: "captcha_key")]
		public string CaptchaKey { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(BoardEditTopicParams p)
		{
			var parameters = new VkParameters
			{
					{ "group_id", p.GroupId }
					, { "topic_id", p.TopicId }
					, { "title", p.Title }
					, { "captcha_sid", p.CaptchaSid }
					, { "captcha_key", p.CaptchaKey }
			};

			return parameters;
		}
	}
}