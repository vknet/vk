namespace VkToolkit.Enums
{
    using System;

    /// <summary>
    /// Фильтр для отбора сообщений.
    /// </summary>
    [Flags]
    public enum MessagesFilter
    {
        /// <summary>
        /// Непрочитанные сообщения.
        /// </summary>
        Unread = 1,
        /// <summary>
        /// Сообщения не из чата.
        /// </summary>
        NotFromChat = 2,
        /// <summary>
        /// Сообщения от друзей. 
        /// </summary>
        FromFriends = 4
    }
}