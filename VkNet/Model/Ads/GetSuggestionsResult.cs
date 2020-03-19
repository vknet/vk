using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class GetSuggestionsResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("desc")]
		public string Desc { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("parent")]
		public string Parent { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetSuggestionsResult FromJson(VkResponse response)
		{
			return new GetSuggestionsResult
			{
				Id = response["id"],
				Name = response["name"],
				Desc = response["desc"],
				Type = response["type"],
				Parent = response["parent"]
			};
		}
	}
}