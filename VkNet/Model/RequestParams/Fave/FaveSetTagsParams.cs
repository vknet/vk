using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams.Fave
{
	/// <summary>
	/// Параметры запроса метода fave.setTags
	/// </summary>
	[Serializable]
	public class FaveSetTagsParams
	{
		/// <summary>
		/// Тип объекта, которому необходимо присвоить метку.
		/// </summary>
		/// <remarks>
		/// Для работы с объектами пользователя или сообщества используйте метод fave.setPageTags
		/// </remarks>
		[JsonProperty("item_type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]

		public FaveType ItemType { get; set; }

		/// <summary>
		/// Идентификатор ссылки, которой требуется присвоить метку.
		/// </summary>
		[JsonProperty("link_id")]
		public string LinkId { get; set; }

		/// <summary/>
		[JsonProperty("link_url")]
		public string LinkUrl { get; set; }

		/// <summary>
		/// Идентификатор владельца объекта, которому требуется присвоить метку.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
		/// </summary>
		[JsonProperty("item_owner_id")]
		public long? ItemOwnerId { get; set; }

		/// <summary>
		/// Идентификатор объекта.
		/// </summary>
		[JsonProperty("item_id")]
		public long? ItemId { get; set; }

		/// <summary>
		/// Идентификатор метки, которую требуется присвоить объекту.
		/// </summary>
		[JsonProperty("tag_ids")]
		public IEnumerable<long> TagIds { get; set; }
	}
}