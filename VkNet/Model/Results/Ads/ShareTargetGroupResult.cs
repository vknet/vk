using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода ShareTargetGroup
	/// </summary>
	[Serializable]
	public class ShareTargetGroupResult
	{
		/// <summary>
		/// Идентификатор аудитории.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static ShareTargetGroupResult FromJson(VkResponse response)
		{
			return new ShareTargetGroupResult
			{
				Id = response["id"]
			};
		}
	}
}