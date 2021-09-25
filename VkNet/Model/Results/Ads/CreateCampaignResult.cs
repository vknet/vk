using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения метода ads.createCampaigns
	/// </summary>
	[Serializable]
	public class CreateCampaignResult
	{
		/// <summary>
		/// Идентификатор созданного объявления.
		/// </summary>
		/// <remarks>Выполнение этого метода может вернуть id = null в случае ошибки</remarks>
		[JsonProperty("id")]
		public long? Id { get; set; }

		/// <summary>
		/// Массив объектов UserSpecification
		/// </summary>
		[JsonProperty("error_code")]
		public long ErrorCode { get; set; }

		/// <summary>
		/// Массив объектов UserSpecification
		/// </summary>
		[JsonProperty("error_desc")]
		public string ErrorDesc { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CreateCampaignResult FromJson(VkResponse response)
		{
			return new CreateCampaignResult
			{
				Id = response["id"],
				ErrorCode = response["error_code"],
				ErrorDesc = response["error_desc"]
			};
		}
	}
}