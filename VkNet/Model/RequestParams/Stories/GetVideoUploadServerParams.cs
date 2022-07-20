using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Stories
{
	/// <summary>
	/// Список параметров для метода stories.getVideoUploadServer
	/// </summary>
	[Serializable]
	public class GetVideoUploadServerParams
	{
		/// <summary>
		/// Идентификатор истории, в ответ на которую создается новая. строка
		/// </summary>
		[JsonProperty("reply_to_story")]
		public string ReplyToStory { get; set; }

		/// <summary>
		/// Текст ссылки для перехода из истории. строка
		/// </summary>
		[JsonProperty("link_text")]
		public string LinkText { get; set; }

		/// <summary>
		/// Адрес ссылки для перехода из истории. строка, максимальная длина 2048
		/// </summary>
		[JsonProperty("link_url")]
		public string LinkUrl { get; set; }

		/// <summary>
		/// 1 — разместить историю в новостях. флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("add_to_news")]
		public bool AddToNews { get; set; }

		/// <summary>
		/// Идентификаторы пользователей, которые будут видеть историю (для отправки в личном сообщении). список положительных чисел, разделенных запятыми
		/// </summary>
		[JsonProperty("user_ids")]
		public IEnumerable<ulong> UserIds { get; set; }

		/// <summary>
		/// Идентификатор сообщества, в которое должна быть загружена история (при работе с ключом доступа пользователя).
		/// Обратите внимание — загрузка историй доступна только для верифицированных сообществ и для сообществ, отмеченных «огоньком». положительное число
		/// </summary>
		[JsonProperty("group_id")]
		public ulong GroupId { get; set; }

		/// <summary>
		/// Объект кликабельного стикера.
		/// </summary>
		[JsonProperty("clickable_stickers")]
		public ClickableStickersObject ClickableStickers { get; set; }
	}
}