using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения метода ads.createClients
	/// </summary>
	[Serializable]
	public class CreateClientResult
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
		public static CreateClientResult FromJson(VkResponse response)
		{
			return new CreateClientResult
			{
				Id = response["id"],
				ErrorCode = response["error_code"],
				ErrorDesc = response["error_desc"]
			};
		}
	}
}