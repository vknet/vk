using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса LookALikeRequest
	/// </summary>
	[Serializable]
	public class CreateLookALikeRequestResult
	{
		/// <summary>
		/// Идентификатор созданного запроса на поиск похожей аудитории
		/// </summary>
		[JsonProperty("request_id")]
		public long RequestId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CreateLookALikeRequestResult FromJson(VkResponse response)
		{
			return new CreateLookALikeRequestResult
			{
				RequestId = response["request_id"]
			};
		}
	}
}