using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class GetTargetGroupsResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("last_updated")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime LastUpdated { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("pixel")]
		public string Pixel { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("is_audience")]
		public bool IsAudience { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("is_shared")]
		public bool IsShared { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("audience_count")]
		public long AudienceCount { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("lifetime")]
		public long Lifetime { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("file_source")]
		public long FileSource { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("api_source")]
		public long ApiSource { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("lookalike_source")]
		public long LookalikeSource { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetTargetGroupsResult FromJson(VkResponse response)
		{
			return new GetTargetGroupsResult
			{
				Id = response["id"],
				Name = response["name"],
				LastUpdated = response["last_updated"],
				Domain = response["domain"],
				Pixel = response["pixel"],
				IsAudience = response["is_audience"],
				IsShared = response["is_shared"],
				ApiSource = response["api_source"],
				Lifetime = response["lifetime"],
				AudienceCount = response["audience_count"],
				LookalikeSource = response["lookalike_source"],
				FileSource = response["file_source"]
			};
		}
	}
}