using System.Collections.Generic;

namespace VkToolkit.Model
{
    public class MessagesSearchResponse
    {
        public IList<User> Users { get; private set; }
        public IList<Chat> Chats { get; private set; } 

        public MessagesSearchResponse()
        {
            Users = new List<User>();
            Chats = new List<Chat>();
        }
    }
}