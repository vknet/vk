using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода UpdateAds
	/// </summary>
	[Serializable]
	public class UpdateAdsResult
	{
		/// <summary>
		/// Идентификатор обновленного объявления.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Код ошибки
		/// </summary>
		[JsonProperty("error_code")]
		public long ErrorCode { get; set; }

		/// <summary>
		/// Описание ошибки
		/// </summary>
		[JsonProperty("error_desc")]
		public string ErrorDesc { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static UpdateAdsResult FromJson(VkResponse response)
		{
			return new UpdateAdsResult
			{
				Id = response["id"],
				ErrorCode = response["error_code"],
				ErrorDesc = response["error_desc"]
			};
		}
	}
}