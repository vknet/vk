using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Объект для перечисления пользователей, которые выбрали определенные варианты
	/// ответа в опросе.
	/// </summary>
	[Serializable]
	public class PollAnswerVoters
	{
		/// <summary>
		/// Идентификатор варианта ответа
		/// </summary>
		public long? AnswerId { get; set; }

		/// <summary>
		/// Коллекция пользователей, только если Fields != null
		/// </summary>
		public VkCollection<User> Users { get; set; }

		/// <summary>
		/// Коллекция идентификаторов пользователей, только если Fields = null
		/// </summary>
		public VkCollection<long> UsersIds { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PollAnswerVoters FromJson(VkResponse response)
		{
			var isLongMode = false;

			if (response.ContainsKey(key: "users")
				&& response[key: "users"].ContainsKey(key: "items"))
			{
				var array = (VkResponseArray) response[key: "users"][key: "items"];

				if (array.Count > 0 && !array[key: 0].ContainsKey(key: "id"))
				{
					isLongMode = true;
				}
			}

			var answer = new PollAnswerVoters
			{
					AnswerId = response[key: "answer_id"]
			};

			if (isLongMode)
			{
				answer.UsersIds = response[key: "users"].ToVkCollectionOf<long>(selector: x => x);
			} else
			{
				answer.Users = response[key: "users"].ToVkCollectionOf<User>(selector: x => x);
			}

			return answer;
		}
	}
}