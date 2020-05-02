using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса Friends.Delete
	/// </summary>
	[Serializable]
	public class FriendsDeleteResult
	{
		/// <summary>
		/// Удалось успешно удалить друга
		/// </summary>
		[JsonProperty(propertyName: "success")]
		public bool? Success { get; set; }

		/// <summary>
		/// Был удален друг
		/// </summary>
		[JsonProperty(propertyName: "friend_deleted")]
		public bool? FriendDeleted { get; set; }

		/// <summary>
		/// Отменена исходящая заявка
		/// </summary>
		[JsonProperty(propertyName: "out_request_deleted")]
		public bool? OutRequestDeleted { get; set; }

		/// <summary>
		/// Отклонена входящая заявка
		/// </summary>
		[JsonProperty(propertyName: "in_request_deleted")]
		public bool? InRequestDeleted { get; set; }

		/// <summary>
		/// Отклонена рекомендация друга
		/// </summary>
		[JsonProperty(propertyName: "suggestion_deleted")]
		public bool? SuggestionDeleted { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static FriendsDeleteResult FromJson(VkResponse response)
		{
			return new FriendsDeleteResult
			{
					Success = response[key: "success"]
					, FriendDeleted = response[key: "friend_deleted"]
					, OutRequestDeleted = response[key: "out_request_deleted"]
					, InRequestDeleted = response[key: "in_request_deleted"]
					, SuggestionDeleted = response[key: "suggestion_deleted"]
			};
		}

	#endregion
	}
}