using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class LeadFormsQuestionInfo
	{
		/// <summary>
		/// Тип вопроса
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Заголовок вопроса (только для нестандартных вопросов)
		/// </summary>
		[JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
		public string Label { get; set; }

		/// <summary>
		/// Уникальный ключ вопроса (необязательно; только для нестандартных вопросов)
		/// </summary>
		[JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
		public string Key { get; set; }

		/// <summary>
		/// Массив возможных ответов на вопрос (только для нестандартных вопросов типа radio, select, checkbox)
		/// </summary>
		[JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
		public QuestionOption[] Options { get; set; }
	}
}