namespace VkToolkit.Enums
{
    /// <summary>
    /// Административные полномочия пользователя в сообществе.
    /// </summary>
    public enum AdminLevel
    {
        /// <summary>
        /// Пользователь является модератором собщества.
        /// </summary>
        Moderator = 0,

        /// <summary>
        /// Пользователь является редактором сообщества.
        /// </summary>
        Editor = 1,

        /// <summary>
        /// Пользователь является администратором сообщества.
        /// </summary>
        Administrator = 2
    }
}