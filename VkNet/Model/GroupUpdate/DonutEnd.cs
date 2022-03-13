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
	public class DonutEnd
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static DonutEnd FromJson(VkResponse response)
		{
			var groupJoin = JsonConvert.DeserializeObject<DonutEnd>(response.ToString(), JsonConfigure.JsonSerializerSettings);
			groupJoin.UserId = response["user_id"];

			return groupJoin;
		}
	}
}
