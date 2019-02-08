using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Общий друг
	/// </summary>
	[Serializable]
	public class MutualFriend
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[JsonProperty("id")]
		public ulong Id { get; set; }

		/// <summary>
		/// Идентификаторы общих друзей
		/// </summary>
		[JsonProperty("common_friends")]
		public ReadOnlyCollection<ulong> CommonFriends { get; set; }

		/// <summary>
		/// Количество общих друзей
		/// </summary>
		[JsonProperty("common_count")]
		public ulong CommonCount { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MutualFriend FromJson(VkResponse response)
		{
			return new MutualFriend
			{
				Id = response["id"],
				CommonFriends = response["common_friends"].ToReadOnlyCollectionOf<ulong>(x => x),
				CommonCount = response["common_count"]
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MutualFriend(VkResponse response)
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