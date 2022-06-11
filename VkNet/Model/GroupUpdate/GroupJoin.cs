using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Infrastructure;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление участника или заявки на вступление в сообщество
	/// </summary>
	[Serializable]
	public class GroupJoin : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Указывает, как именно был добавлен участник.
		/// </summary>
		[JsonProperty("join_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public GroupJoinType? JoinType { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static GroupJoin FromJson(VkResponse response)
		{
			var groupJoin = JsonConvert.DeserializeObject<GroupJoin>(response.ToString(), JsonConfigure.JsonSerializerSettings);
			groupJoin.UserId = response["user_id"];

			return groupJoin;
		}

		/// <summary>
		/// Преобразование класса <see cref="GroupJoin" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="GroupJoin" /> </returns>
		public static implicit operator GroupJoin(VkResponse response)
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