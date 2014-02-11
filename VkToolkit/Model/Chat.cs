namespace VkToolkit.Model
{
    using System;
    using System.Collections.Generic;

    using VkToolkit.Utils;

    /// <summary>
    /// Информация о беседе (мультидиалоге, чате).
    /// См. описание <see cref="http://vk.com/dev/chat_object"/>.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Идентификатор беседы.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Тип диалога.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Название беседы.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который является создателем беседы.
        /// </summary>
        public long? AdminId { get; set; }

        /// <summary>
        /// Список идентификаторов участников беседы.
        /// </summary>
        public List<long> Users { get; set; }

        #region Методы

        internal static Chat FromJson(VkResponse response)
        {
            var chat = new Chat();

            chat.Id = response["id"];
            chat.Type = response["type"];
            chat.Title = response["title"];
            chat.AdminId = Utilities.GetNullableLongId(response["admin_id"]);
            chat.Users = response["users"];

            return chat;
        }

        #endregion
    }
}