using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Model
{
	/// <summary>
	/// Friends Get Requests Result
	/// </summary>
	[Serializable]
	public class FriendsGetRequestsResult
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		[JsonProperty(propertyName: "user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "mutual")]
		[JsonConverter(typeof(VkCollectionJsonConverter), "users")]
		public VkCollection<long> Mutual { get; set; }

		/// <summary>
		/// Текст сообщения
		/// </summary>

		//[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static FriendsGetRequestsResult FromJson(VkResponse response)
		{
			return new FriendsGetRequestsResult
			{
				UserId = response[key: "user_id"],
				Mutual = response[key: "mutual"].ToVkCollectionOf<long>(selector: x => x, arrayName: "users"),
				Message = response[key: "message"]
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator FriendsGetRequestsResult(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response: response) : null;
		}
	}
}