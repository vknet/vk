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
	public class GetTargetPixelsResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("target_pixel_id")]
		public long TargetPixelId { get; set; }

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
		[JsonProperty("category_id")]
		public long CategoryId { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("pixel")]
		public string Pixel { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetTargetPixelsResult FromJson(VkResponse response)
		{
			return new GetTargetPixelsResult
			{
				TargetPixelId = response["target_pixel_id"],
				Name = response["name"],
				LastUpdated = response["last_updated"],
				Domain = response["domain"],
				CategoryId = response["category_id"],
				Pixel = response["pixel"]
			};
		}
	}
}