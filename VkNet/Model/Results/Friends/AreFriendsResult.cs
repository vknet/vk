using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса Friends.AreFriends
	/// </summary>
	[Serializable]
	public class AreFriendsResult
	{
		/// <summary>
		/// Идентификатор пользователя (из числа переданных в параметре user_ids);
		/// </summary>
		[JsonProperty(propertyName: "user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// Статус дружбы с пользователем
		/// </summary>
		/// <remarks>
		/// 0 – пользователь не является другом,
		/// 1 – отправлена заявка/подписка пользователю,
		/// 2 – имеется входящая заявка/подписка от пользователя,
		/// 3 – пользователь является другом;
		/// </remarks>
		[JsonProperty(propertyName: "friend_status")]
		public FriendStatus FriendStatus { get; set; }

		/// <summary>
		/// Текст сообщения, прикрепленного к заявке в друзья (если есть)
		/// </summary>
		[JsonProperty(propertyName: "request_message")]
		public string RequestMessage { get; set; }

		/// <summary>
		/// Статус заявки (0 — не просмотрена, 1 — просмотрена), возвращается только если
		/// friend_status = 2;
		/// </summary>
		[JsonProperty(propertyName: "read_state")]
		public bool? ReadState { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AreFriendsResult FromJson(VkResponse response)
		{
			return new AreFriendsResult
			{
					UserId = response[key: "user_id"]
					, FriendStatus = response[key: "friend_status"]
					, RequestMessage = response[key: "request_message"]
					, ReadState = response[key: "read_state"]
			};
		}

	#endregion
	}
}