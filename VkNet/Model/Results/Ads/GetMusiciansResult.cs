using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class GetMusiciansResult
	{
		/// <summary>
		/// Идентификатор музыканта.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Полный псевдоним музыканта.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Аватарка музыканта.
		/// </summary>
		[JsonProperty("avatar")]
		public string Avatar { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns></returns>
		public static GetMusiciansResult FromJson(VkResponse response)
		{
			return new GetMusiciansResult
			{
				Id = response["id"],
				Name = response["name"],
				Avatar = response["avatar"]
			};
		}
	}
}