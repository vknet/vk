using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model.RequestParams.Polls
{
	/// <summary>
	/// Список параметров для метода polls.create
	/// </summary>
	[Serializable]
	public class PollsCreateParams
	{
		/// <summary>
		/// Текст опроса.
		/// </summary>
		[JsonProperty("question")]
		public string Question { get; set; }

		/// <summary>
		/// Идентификатор владельца опроса.
		/// True – анонимный опрос, список проголосовавших недоступен;
		/// False – опрос публичный, список проголосовавших доступен;
		/// По умолчанию – False.
		/// </summary>
		[JsonProperty("is_anonymous")]
		public bool? IsAnonymous { get; set; }

		/// <summary>
		/// <c>true</c> — для создания опроса с мультивыбором. флаг, может принимать значения <c>true</c> или <c>false</c>
		/// </summary>
		[JsonProperty("is_multiple")]
		public bool? IsMultiple { get; set; }

		/// <summary>
		/// Дата завершения опроса в Unixtime. положительное число, минимальное значение 1536692688
		/// </summary>
		[JsonProperty("end_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Если опрос будет добавлен в группу, необходимо передать отрицательный идентификатор группы.
		/// По умолчанию текущий пользователь.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Список вариантов ответов.
		/// </summary>
		[JsonProperty("add_answers")]
		public IEnumerable<string> AddAnswers { get; set; }

		/// <summary>
		/// Идентификатор фотографии для использования в качестве фона сниппета. положительное число
		/// </summary>
		[JsonProperty("photo_id")]
		public ulong? PhotoId { get; set; }

		/// <summary>
		/// Идентификатор стандартного фона для сниппета.
		/// </summary>
		[JsonProperty("background_id")]
		public long? BackgroundId { get; set; }
	}
}