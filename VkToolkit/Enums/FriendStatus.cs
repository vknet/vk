namespace VkToolkit.Enums
{
    public enum FriendStatus
    {
        NotFriend = 0,      // пользователь не является другом
        OutputRequest = 1,  // отправлена заявка/подписка пользователю 
        InputRequest = 2,   // имеется входящая заявка/подписка от пользователя
        Friend = 3          // пользователь является другом
    }
}