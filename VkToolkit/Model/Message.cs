using System;
using System.Collections.Generic;

using VkToolkit.Enums;
using VkToolkit.Utils;

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
        public List<Attachment> Attachments { get; set; }
        public List<Message> ForwardedMessages { get; set; }
        public long? ChatId { get; set; }
        public List<long> ChatActiveIds { get; set; }
        public int? UsersCount { get; set; }
        public long? AdminId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? FromUserId { get; set; }

        internal static Message FromJson(VkResponse message)
        {
            var result = new Message();

            result.Id = message["mid"];
            result.UserId = message["uid"];
            result.Title = message["title"];
            result.Body = message["body"];
            result.ChatId = message["chat_id"];
            result.UsersCount = message["users_count"];
            result.AdminId = message["admin_id"];
            result.FromUserId = message["from_id"];
            result.IsDeleted = message["deleted"];
            result.Date = message["date"];
            result.ReadState = message["read_state"];
            result.Type = message["out"];
            result.Attachments = message["attachments"];

            if (message["fwd_messages"] != null)
                throw new NotImplementedException();

            if (message["chat_active"] != null)
                throw new NotImplementedException();

            return result;
        }
    }
}