using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса SaveLookalikeRequestResult
	/// </summary>
	[Serializable]
	public class SaveLookALikeRequestResultResult
	{
		/// <summary>
		/// Идентификатор группы ретаргетинга, в которую будет сохранена запрошенная похожая аудитория.
		/// </summary>
		[JsonProperty("retargeting_group_id")]
		public long RetargetingGroupId { get; set; }

		/// <summary>
		/// Размер запрошенной похожей аудитории.
		/// </summary>
		[JsonProperty("audience_count")]
		public long AudienceCount { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static SaveLookALikeRequestResultResult FromJson(VkResponse response)
		{
			return new SaveLookALikeRequestResultResult
			{
				RetargetingGroupId = response["retargeting_group_id"],
				AudienceCount = response["audience_count"]
			};
		}
	}
}