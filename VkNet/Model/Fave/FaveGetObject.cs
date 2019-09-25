using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;
using VkNet.Model.Attachments;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода fave.get
	/// </summary>
	[Serializable]
	public class FaveGetObject
	{
		/// <summary>
		/// Дата добавления объекта в закладки.
		/// </summary>
		[JsonProperty("added_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime AddedDate { get; set; }

		/// <summary>
		/// Является ли закладка просмотренной.
		/// </summary>
		[JsonProperty("seen")]
		public bool Seen { get; set; }

		/// <summary>
		/// Тип объекта, добавленного в закладки.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public FaveType Type { get; set; }

		/// <summary>
		/// Массив меток объекта в списке закладок.
		/// </summary>
		[JsonProperty("tags")]
		public IEnumerable<FaveTag> Tags { get; set; }

		/// <inheritdoc cref="Attachments.Post" />
		[JsonProperty("post")]
		public Post Post { get; set; }

		/// <inheritdoc cref="Attachments.Video" />
		[JsonProperty("video")]
		public Video Video { get; set; }

		/// <inheritdoc cref="Market" />
		[JsonProperty("product")]
		public Market Product { get; set; }

		/// <inheritdoc cref="Attachments.Article" />
		[JsonProperty("Article")]
		public Article Article { get; set; }

		/// <inheritdoc cref="Attachments.Podcast" />
		[JsonProperty("podcast")]
		public Podcast Podcast { get; set; }

		/// <inheritdoc cref="Attachments.Link" />
		[JsonProperty("link")]
		public Link Link { get; set; }
	}
}