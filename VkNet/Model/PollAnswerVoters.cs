using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Объект для перечисления пользователей, которые выбрали определенные варианты ответа в опросе.
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
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static PollAnswerVoters FromJson(VkResponse response)
        {
            var isLongMode = false;
            if (response.ContainsKey("users")
                && response["users"].ContainsKey("items"))
            {
                var array = (VkResponseArray) response["users"]["items"];
                if (array.Count > 0 && !array[0].ContainsKey("id"))
                {
                    isLongMode = true;
                }
            }

            var answer = new PollAnswerVoters
            {
                AnswerId = response["answer_id"],
            };

            if (isLongMode)
                answer.UsersIds = response["users"].ToVkCollectionOf<long>(x => x);
            else
                answer.Users = response["users"].ToVkCollectionOf<User>(x => x);

            return answer;
        }
    }
}