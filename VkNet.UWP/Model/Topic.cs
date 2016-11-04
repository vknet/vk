using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Элемент коллекции тем.
	/// </summary>
	public class Topic
    {
        /// <summary>
        /// Идентификатор темы.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Дата создания (в формате unixtime).
        /// </summary>
        public DateTime? Сreated { get; set; }

        /// <summary>
        /// Идентификатор пользователя, создавшего тему.
        /// </summary>
        public long СreatedBy { get; set; }

        /// <summary>
        /// Дата последнего сообщения (в формате unixtime).
        /// </summary>
        public DateTime? Updated { get; set; }

	    /// <summary>
         /// Идентификатор автора последнего комментария в обсуждении (может содержать id сообщества со знаком минус).
         /// </summary>
        public long UpdatedBy { get; set; }

        /// <summary>
        /// Eсли тема является закрытой (в ней нельзя оставлять сообщения).
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Если тема является закрепленной (находится в начале списка тем).
        /// </summary>
        public bool IsFixed { get; set; }

        /// <summary>
        /// Число сообщений в теме.
        /// </summary>
        public long CommentsСount { get; set; }

        /// <summary>
        /// (только если в поле preview указан флаг 1) — текст первого сообщения.
        /// </summary>
        public string FirstComment { get; set; }

        /// <summary>
        /// (только если в поле preview указан флаг 2) — текст последнего сообщения.
        /// </summary>
        public string LastComment { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        internal static Topic FromJson(VkResponse response)
		{
			var topicItem = new Topic
            {
				Id = response["id"],
                Title = response["title"],
                Сreated = response["created"],
                СreatedBy = response["created_by"],
                Updated = response["updated"],
                UpdatedBy = response["updated_by"],
                IsClosed = response["is_closed"],
                IsFixed = response["is_fixed"],
                CommentsСount = response["comments"],
                FirstComment = response["first_comment"],
                LastComment = response["last_comment"],
			};

			return topicItem;
		}
	}
}
