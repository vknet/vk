namespace VkToolkit.Enums
{
    /// <summary>
    /// Состояние дружбы с пользователями.
    /// </summary>
    public enum FriendStatus
    {
        /// <summary>
        /// Пользователь не является другом.
        /// </summary>
        NotFriend = 0,

        /// <summary>
        /// Пользователю отправлена заявка/подписка.
        /// </summary>
        OutputRequest = 1,

        /// <summary>
        /// Имеется входящая заявка/подписка от пользователя.
        /// </summary>
        InputRequest = 2,

        /// <summary>
        /// Пользователь является другом.
        /// </summary>
        Friend = 3
    }
}