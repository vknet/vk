﻿using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Информация об рекламе в аудиозаписи каталога.
	/// </summary>
	[Serializable]
	public class AudioCatalogAudioAds
	{
		/// <summary>
		/// Идентификатор контента.
		/// </summary>
		[JsonProperty("content_id")]
		public string СontentId { get; set; }

		/// <summary>
		/// Длительность.
		/// </summary>
		[JsonProperty("duration")]
		public string Duration { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("account_age_type")]
		public string AccountAgeType { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("puid1")]
		public int Puid1 { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("puid22")]
		public long Puid22 { get; set; }
	}
}