using System;
using System.Collections.Generic;
using VkToolkit.Enums;

namespace VkToolkit.Model
{
    public class Message
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public DateTime? Date { get; set; }
        public MessageReadState? ReadState { get; set; }
        public MessageType? Type { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
        public IEnumerable<Message> ForwardedMessages { get; set; }
        public long? ChatId { get; set; }
        public IEnumerable<long> ChatActiveIds { get; set; }
        public int? UsersCount { get; set; }
        public long? AdminId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? FromUserId { get; set; }
    }
}