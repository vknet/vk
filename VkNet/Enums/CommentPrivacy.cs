namespace VkNet.Enums
{
    using Utils;

    /// <summary>
    /// Уровень доступа к комментированию альбома
    /// </summary>
    public enum CommentPrivacy
    {
        /// <summary>
        /// Все пользователи
        /// </summary>
        [DefaultValue]
        AllUsers = 0,

        /// <summary>
        /// Только друзья
        /// </summary>
        OnlyFriends = 1,

        /// <summary>
        /// Друзья и друзья друзей
        /// </summary>
        FriendsAndTheirFriends = 2,

        /// <summary>
        /// Только я
        /// </summary>
        OnlyMe = 3

    }
}