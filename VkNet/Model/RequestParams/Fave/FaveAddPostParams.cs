using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Fave
{
	/// <summary>
	/// Параметры запроса метода fave.addPost
	/// </summary>
	[Serializable]
	public class FaveAddPostParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, чью запись со стены требуется добавить в закладки.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
		/// </summary>
		/// <remarks>
		/// Обязательный параметр.
		/// </remarks>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор записи, которую необходимо добавить в закладки. 
		/// </summary>
		/// <remarks>
		/// Обязательный параметр.
		/// </remarks>
		[JsonProperty("id")]
		public long? Id { get; set; }

		/// <summary>
		/// Специальный код доступа для приватных постов.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary/>
		[JsonProperty("ref")]
		public string Ref { get; set; }

		/// <summary/>
		[JsonProperty("track_code")]
		public string TrackCode { get; set; }

		/// <summary/>
		[JsonProperty("source")]
		public string Source { get; set; }
	}
}