using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Описание рекламного аккаунта.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getAccounts
	/// </remarks>
	[Serializable]
	public class GetClientsResult
	{
		/// <summary>
		/// Идентификатор рекламного объявления.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Общий лимит объявления в рублях. 0 — лимит не задан.
		/// </summary>
		[JsonProperty("all_limit")]
		public long AllLimit { get; set; }

		/// <summary>
		/// Дневной лимит объявления в рублях. 0 — лимит не задан.
		/// </summary>
		[JsonProperty("day_limit")]
		public long DayLimit { get; set; }

		/// <summary>
		/// Название объявления.
		/// </summary>
		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetClientsResult FromJson(VkResponse response)
		{
			return new GetClientsResult
			{
				Id = response["id"],
				AllLimit = response["all_limit"],
				DayLimit = response["day_limit"],
				Name = response["name"]
			};
		}
	}
}