namespace VkToolkit.Model
{
    using System;
    using System.Collections.Generic;

    using VkToolkit.Enums;
    using VkToolkit.Utils;

    /// <summary>
    /// Личное сообщение пользователя.
    /// См. описание <see cref="http://vk.com/dev/message"/>.
    /// </summary>
    public class Message
    {
        #region Стандартные поля

        /// <summary>
        /// Идентификатор сообщения (не возвращается для пересланных сообщений).
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор автора сообщения (для исходящего сообщения — идентификатор получателя).
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Дата отправки сообщения.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Статус сообщения (не возвращается для пересланных сообщений).
        /// </summary>
        public MessageReadState? ReadState { get; set; }

        /// <summary>
        /// Тип сообщения (не возвращается для пересланных сообщений).
        /// </summary>
        public MessageType? Type { get; set; }

        /// <summary>
        /// Заголовок сообщения или беседы.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Массив медиа-вложений (прикреплений).
        /// </summary>
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Массив пересланных сообщений (если есть).
        /// </summary>
        public List<Message> ForwardedMessages { get; set; }

        /// <summary>
        /// Содержатся ли в сообщении emoji-смайлы.
        /// </summary>
        public bool ContainsEmojiSmiles { get; set; }

        /// <summary>
        /// Является ли сообщение важным.
        /// </summary>
        public bool IsImportant { get; set; }

        /// <summary>
        /// Удалено ли сообщение.
        /// </summary>
        public bool? IsDeleted { get; set; }

        #endregion

        #region Дополнительные поля в сообщениях бесед (мультидиалогов)

        /// <summary>
        /// Идентификатор беседы.
        /// </summary>
        public long? ChatId { get; set; }

        /// <summary>
        /// Идентификаторы участников беседы.
        /// </summary>
        public List<long> ChatActiveIds { get; set; }

        /// <summary>
        /// Количество участников беседы.
        /// </summary>
        public int? UsersCount { get; set; }

        /// <summary>
        /// Идентификатор создателя беседы.
        /// </summary>
        public long? AdminId { get; set; }

        /// <summary>
        /// Информация о ссылках на предпросмотр фотографий беседы.
        /// </summary>
        public Previews PhotoPreviews { get; set; }

        #endregion

        #region Методы

        internal static Message FromJson(VkResponse response)
        {
            var message = new Message();

            message.Id = response["id"];
            message.UserId = response["user_id"];
            message.Date = response["date"];
            message.ReadState = response["read_state"];
            message.Type = response["out"];
            message.Title = response["title"];
            message.Body = response["body"];
            message.Attachments = response["attachments"];
            message.ForwardedMessages = response["fwd_messages"];
            message.ContainsEmojiSmiles = response["emoji"];
            message.IsImportant = response["important"];
            message.IsDeleted = response["deleted"];

            // дополнительные поля бесед

            message.ChatId = response["chat_id"];
            message.ChatActiveIds = response["chat_active"];
            message.UsersCount = response["users_count"];
            message.AdminId = response["admin_id"];
            message.PhotoPreviews = response;

            return message;
        }

        #endregion
    }
}