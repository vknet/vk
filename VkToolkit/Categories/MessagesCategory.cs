using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

#if WINDOWS_PHONE
using System.Net;
#else
using System.Web;
#endif

namespace VkToolkit.Categories
{
    public class MessagesCategory
    {
        private readonly VkApi _vk;

        public MessagesCategory(VkApi vk)
        {
            _vk = vk;
        }

        public List<Message> Get(MessageType type, out int totalCount, int? count = null, int? offset = null, MessagesFilter? filter = null, int? previewLength = null, DateTime? startDate = null)
        {
            var parameters = new VkParameters
                {
                    { "out", type },
                    { "offset", offset },
                    { "count", count },
                    { "filters", filter },
                    { "preview_length", previewLength },
                    { "time_offset", startDate }
                };

            VkResponseArray response = _vk.Call("messages.get", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (Message)r);
        }
        
        public List<Message> GetHistory(long id, bool isChat, out int totalCount, int? offset = null, int? count = null, bool? inReverse = null, long? startMessageId = null)
        {
            var parameters = new VkParameters
                {
                    { isChat ? "chat_id" : "uid", id },
                    { "offset", offset },
                    { "count", count },
                    { "start_mid", startMessageId },
                    { "rev", "1" }
                };

            VkResponseArray response = _vk.Call("messages.getHistory", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (Message)r);
        }
        
        public Message GetById(long messageId, int? previewLength = null)
        {
            int totalCount;

            return GetById(new [] {messageId}, out totalCount, previewLength).FirstOrDefault();
        }

        public List<Message> GetById(IEnumerable<long> messageIds, out int totalCount, int? previewLength = null)
        {
            var parameters = new VkParameters { { "mids", messageIds }, { "preview_length", previewLength } };

            VkResponseArray response = _vk.Call("messages.getById", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (Message)r);
        }
        
        public List<Message> GetDialogs(long userId, out int totalCount, long? chatId = null, int? count = null, int? offset = null, int? previewLength = null)
        {
            var parameters = new VkParameters
                {
                    { "uid", userId }, 
                    { "chat_id", chatId }, 
                    { "count", count }, 
                    { "offset", offset }, 
                    { "preview_length", previewLength }
                };

            VkResponseArray response = _vk.Call("messages.getDialogs", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (Message)r);
        }

        public MessagesSearchResponse SearchDialogs(string query, ProfileFields fields = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new InvalidParamException("Query can not be null or empty.");

            var parameters = new VkParameters { { "q", query }, { "fields", fields } };

            VkResponseArray response = _vk.Call("messages.searchDialogs", parameters);

            var result = new MessagesSearchResponse();
            foreach (var record in response)
            {
                string type = record["type"];
                if (type == "profile")
                    result.Users.Add(record);
                else if (type == "chat")
                    result.Chats.Add(record);
            }
            return result;
        }

        public List<Message> Search(string query, out int totalCount, int? count = null, int? offset = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new InvalidParamException("Query can not be null or empty.");

            var parameters = new VkParameters { { "q", query }, { "count", count + "" }, { "offset", offset } };

            VkResponseArray response = _vk.Call("messages.search", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (Message)r);
        }
        
        public long Send(long id, bool isChat, string message, string title = "", Attachment attch = null, IEnumerable<long> forwardMessagedIds = null, bool fromChat = false, double? latitude = null, double? longitude = null, string guid = null)
        {
            if (string.IsNullOrEmpty(message))
                throw new InvalidParamException("Message can not be null.");

            var parameters = new VkParameters
                {
                    { isChat ? "chat_id" : "uid", id },
                    { "message", HttpUtility.UrlEncode(message) },
                    { "forward_messages", forwardMessagedIds },
                    { "title", HttpUtility.UrlEncode(title) },
                    { "type", fromChat },
                    { "lat", latitude },
                    { "long", longitude },
                    { "guid", HttpUtility.UrlEncode(guid) }
                };

            // TODO: Yet not work with attachments. Fix it later.

            return _vk.Call("messages.send", parameters);
        }

        public bool DeleteDialog(long id, bool isChat, int? offset = null, int? limit = null)
        {
            var parameters = new VkParameters { { isChat ? "chat_id" : "uid", id }, { "offset", offset }, { "limit", limit } };

            return _vk.Call("messages.deleteDialog", parameters);
        }

        public bool Delete(long messageId)
        {
            var result = Delete(new [] {messageId});
            return result[messageId];
        }

        public IDictionary<long, bool> Delete(IEnumerable<long> messageIds)
        {
            if (messageIds == null)
                throw new InvalidParamException("Param messageIds can not be null.");
            
            var ids = messageIds.ToList();
            if (ids.Count == 0)
                throw new InvalidParamException("Param messageIds has no one element.");

            var parameters = new VkParameters { { "mids", ids } };

            var response = _vk.Call("messages.delete", parameters);

            var result = new Dictionary<long, bool>();
            foreach (var id in ids)
            {
                bool isDeleted = response[id.ToString(CultureInfo.InvariantCulture)];
                result.Add(id, isDeleted);
            }
            
            return result;
        }

        public bool Restore(long messageId)
        {
            var parameters = new VkParameters { { "mid", messageId } };

            return _vk.Call("messages.restore", parameters);
        }

        public bool MarkAsNew(long messageId)
        {
            return MarkAsNew(new [] {messageId});
        }

        public bool MarkAsNew(IEnumerable<long> messageIds)
        {
            var parameters = new VkParameters { { "mids", messageIds } };

            return _vk.Call("messages.markAsNew", parameters);
        }

        public bool MarkAsRead(long messageId)
        {
            return MarkAsRead(new [] {messageId});
        }

        public bool MarkAsRead(IEnumerable<long> messageIds)
        {
            var parameters = new VkParameters { { "mids", messageIds } };

            return _vk.Call("messages.markAsRead", parameters);
        }

        public bool SetActivity(long id, bool isChat)
        {
            var parameters = new VkParameters { { isChat ? "chat_id" : "uid", id }, { "type", "typing" } };

            return _vk.Call("messages.setActivity", parameters);
        }

        public LastActivity GetLastActivity(long userId)
        {
            var parameters = new VkParameters { { "uid", userId } };

            var response = _vk.Call("messages.getLastActivity", parameters);

            LastActivity activity = response;
            activity.UserId = userId;

            return activity;
        }

        public Chat GetChat(long chatId)
        {
            var parameters = new VkParameters { { "chat_id", chatId } };

            var response = _vk.Call("messages.getChat", parameters);

            return response;
        }
        
        public long CreateChat(IEnumerable<long> userIds, string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new InvalidParamException("Title can not be empty or null.");

            var parameters = new VkParameters { { "uids", userIds }, { "title", HttpUtility.UrlEncode(title) } };

            return _vk.Call("messages.createChat", parameters);
        }

        public bool EditChat(long chatId, string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new InvalidParamException("Title can not be empty or null.");

            var parameters = new VkParameters { { "chat_id", chatId }, { "title", HttpUtility.UrlEncode(title) } };

            return _vk.Call("messages.editChat", parameters);
        }

        public List<long> GetChatUsers(long chatId)
        {
            var users = GetChatUsers(chatId, null);
            return users.Select(x => x.Id).ToList();
        }

        public List<User> GetChatUsers(long chatId, ProfileFields fields)
        {
            var parameters = new VkParameters { { "chat_id", chatId }, { "fields", fields } };

            var response = _vk.Call("messages.getChatUsers", parameters);

            if (fields != null)
                return response;

            return response.ToListOf(x => new User { Id = (long)x });
        }

        public bool AddChatUser(long chatId, long userId)
        {
            var parameters = new VkParameters { { "chat_id", chatId }, { "uid", userId } };

            return _vk.Call("messages.addChatUser", parameters);
        }

        public bool RemoveChatUser(long chatId, long userId)
        {
            var parameters = new VkParameters { { "chat_id", chatId }, { "uid", userId } };

            return _vk.Call("messages.removeChatUser", parameters);
        }

        public LongPollServerResponse GetLongPollServer()
        {
            return _vk.Call("messages.getLongPollServer", VkParameters.Empty);
        }

        internal void GetLongPollHistory()
        {
            // TODO: Implement later
            throw new NotImplementedException();
        }
    }
}