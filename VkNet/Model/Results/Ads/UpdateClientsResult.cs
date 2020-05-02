using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода UpdateCampaigns
	/// </summary>
	[Serializable]
	public class UpdateClientsResult
	{
		/// <summary>
		/// Идентификатор обновляемой кампании.
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
		public static UpdateClientsResult FromJson(VkResponse response)
		{
			return new UpdateClientsResult
			{
				Id = response["id"],
				ErrorCode = response["error_code"],
				ErrorDesc = response["error_desc"]
			};
		}
	}
}