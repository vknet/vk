using System.Collections.Generic;

using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Chat
    {
        public long? Id { get; set; }
        public long? AdminId { get; set; }
        public string Title { get; set; }
        public List<long> UserIds { get; set; }

        internal static Chat FromJson(VkResponse chat)
        {
            var result = new Chat();

            result.Id = chat["chat_id"];
            result.Title = chat["title"];
            result.UserIds = chat["users"];
            result.AdminId = chat["admin_id"];

            return result;            
        }
    }
}