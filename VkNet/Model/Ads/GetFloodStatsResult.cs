using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Описание рекламного аккаунта.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getAccounts
	/// </remarks>
	[Serializable]
	public class GetFloodStatsResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("left")]
		public long Left { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("refresh")]
		public long Refresh { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetFloodStatsResult FromJson(VkResponse response)
		{
			return new GetFloodStatsResult
			{
				Left = response["left"],
				Refresh = response["refresh"]
			};
		}
	}
}