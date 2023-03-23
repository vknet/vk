using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Тэг группы
	/// </summary>
	[Serializable]
	public class GroupTag
	{
		/// <summary>
		/// Идентификатор тэга
		/// </summary>
		[JsonProperty("id")]
		public ulong Id { get; set; }

		/// <summary>
		/// Название тэга
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Цвет тэга в формате #ffffff
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupTag FromJson(VkResponse response)
		{
			var result = new GroupTag
			{
				Id = response["id"],
				Name = response["name"],
				Color = response["color"]
			};

			return result;
		}

		/// <summary>
		/// Преобразование класса <see cref="GroupTag" /> из <see cref="VkResponse" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="GroupTag" /> </returns>
		public static implicit operator GroupTag(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}