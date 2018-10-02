using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление пользователя в чёрный список
	/// </summary>
	[Serializable]
	public class UserBlock
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор администратора, который внёс пользователя в чёрный список
		/// </summary>
		[JsonProperty("admin_id")]
		public long? AdminId { get; set; }

		/// <summary>
		/// Дата разблокировки
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? UnblockDate { get; set; }

		/// <summary>
		/// Причины блокировки пользователя
		/// </summary>
		[JsonProperty("reason")]
		public GroupUserBlockReason? Reason { get; set; }

		/// <summary>
		/// Комментарий администратора к блокировке
		/// </summary>
		[JsonProperty("comment")]
		public string Comment { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static UserBlock FromJson(VkResponse response)
		{
			var userBlock = JsonConvert.DeserializeObject<UserBlock>(response.ToString());

			userBlock.UnblockDate = response["unblock_date"];

			return userBlock;
		}
	}
}