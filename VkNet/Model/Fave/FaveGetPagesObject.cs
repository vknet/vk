using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ метода fave.getPages
	/// </summary>
	[Serializable]
	public class FaveGetPagesObject
	{
		/// <summary>
		/// Описание страницы.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Тип страницы.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public UserOrGroupType Type { get; set; }

		/// <summary>
		/// Метки страницы.
		/// </summary>
		[JsonProperty("tags")]
		public IEnumerable<FaveTag> Tags { get; set; }

		/// <summary>
		/// Дата обновления.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("updated_date")]
		public DateTime UpdatedDate { get; set; }

		/// <inheritdoc cref="Model.User"/>
		[JsonProperty("user")]
		public User User { get; set; }

		/// <inheritdoc cref="Model.Group"/>
		[JsonProperty("group")]
		public Group Group { get; set; }
	}
}