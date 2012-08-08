using System.Collections.Generic;

namespace VkToolkit.Model
{
    public class Chat
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<long> UserIds { get; set; }
    }
}