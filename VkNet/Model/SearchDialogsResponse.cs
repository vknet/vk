namespace VkNet.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Ответ при поиске диалогов по строке поиска.
    /// См. описание <see href="http://vk.com/dev/messages.searchDialogs"/>.
    /// </summary>
    public class SearchDialogsResponse
    {
        /// <summary>
        /// Список найденных пользователей.
        /// </summary>
        public IList<User> Users { get; private set; }

        /// <summary>
        /// Список найденных бесед.
        /// </summary>
        public IList<Chat> Chats { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SearchDialogsResponse"/>.
        /// </summary>
        public SearchDialogsResponse()
        {
            Users = new List<User>();
            Chats = new List<Chat>();
        }
    }
}