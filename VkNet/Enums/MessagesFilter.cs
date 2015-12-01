namespace VkNet.Enums
{
    using System;

    /// <summary>
    /// Фильтр для отбора сообщений.
    /// </summary>
    [Flags]
    public enum MessagesFilter
    {
        /// <summary>
        /// Все сообщения
        /// </summary>
        All = 0,

		/// <summary>
        /// Важные сообщения
        /// </summary>
        Important = 8
    }
}