namespace VkToolkit.Enum
{
    public enum FriendStatus
    {
        NotFriend,      // пользователь не является другом
        InputRequest,   // имеется входящая заявка/подписка от пользователя
        OutputRequest,  // отправлена заявка/подписка пользователю 
        Friend,         // пользователь является другом
    }
}