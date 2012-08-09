using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    public class MessagesCategory
    {
        private readonly VkApi _vk;
        public MessagesCategory(VkApi vk)
        {
            _vk = vk;
        }

        public IEnumerable<Message> Get(MessageType type, out int totalCount, int? count = null, int? offset = null, MessagesFilter? filter = null, int? previewLength = null, DateTime? startDate = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("out", (int) type + "");

            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset + "");

            if (count.HasValue && count.Value > 0)
                values.Add("count", count + "");

            if (filter.HasValue)
                values.Add("filters", (int)filter + "");

            if (previewLength.HasValue && previewLength.Value > 0)
                values.Add("preview_length", previewLength + "");

            if (startDate.HasValue)
                values.Add("time_offset", Utilities.DateTimeToUnixTimeStamp(startDate.Value) + "");


            string url = _vk.GetApiUrl("messages.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            totalCount = (int) response[0];

            var lst = new List<Message>();
            for (int i = 1; i < response.Count; i++)
            {
                var msg = Utilities.GetMessage((JObject) response[i]);
                lst.Add(msg);
            }

            return lst;
        }
        
        public IEnumerable<Message> GetHistory(long id, bool isChat, out int totalCount, int? offset = null, int? count = null, bool? inReverse = null, long? startMessageId = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add(isChat ? "chat_id" : "uid", id + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset + "");

            if (count.HasValue && count.Value > 0)
                values.Add("count", count + "");
            if (startMessageId.HasValue && startMessageId > 0)
                values.Add("start_mid", startMessageId + "");
            if (inReverse.HasValue && inReverse.Value)
                values.Add("rev", "1");

            string url = _vk.GetApiUrl("messages.getHistory", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            totalCount = (int)response[0];

            var lst = new List<Message>();
            for (int i = 1; i < response.Count; i++)
            {
                var msg = Utilities.GetMessage((JObject)response[i]);
                lst.Add(msg);
            }

            return lst;
        }
        
        public Message GetById(long messageId, int? previewLength = null)
        {
            int totalCount;

            return GetById(new [] {messageId}, out totalCount, previewLength).FirstOrDefault();
        }

        public IEnumerable<Message> GetById(IEnumerable<long> messageIds, out int totalCount, int? previewLength = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("mids", Utilities.GetEnumerationAsString(messageIds));
            if (previewLength.HasValue && previewLength.Value > 0)
                values.Add("preview_length", previewLength + "");

            string url = _vk.GetApiUrl("messages.getById", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            totalCount = (int)response[0];

            var lst = new List<Message>();
            for (int i = 1; i < response.Count; i++)
            {
                var msg = Utilities.GetMessage((JObject)response[i]);
                lst.Add(msg);
            }

            return lst;
        }
        
        public IEnumerable<Message> GetDialogs(long userId, out int totalCount, long? chatId = null, int? count = null, int? offset = null, int? previewLength = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();
         
            var values = new Dictionary<string, string>();
            values.Add("uid", userId + "");
            if (chatId.HasValue && chatId.Value > 0)
                values.Add("chat_id", chatId + "");
            if (count.HasValue && count > 0)
                values.Add("count", count + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset + "");
            if (previewLength.HasValue && previewLength.Value > 0)
                values.Add("preview_length", previewLength + "");

            string url = _vk.GetApiUrl("messages.getDialogs", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            totalCount = (int)response[0];

            var lst = new List<Message>();
            for (int i = 1; i < response.Count; i++)
            {
                var msg = Utilities.GetMessage((JObject)response[i]);
                lst.Add(msg);
            }

            return lst;
        }

        public MessagesSearchResponse SearchDialogs(string query, ProfileFields fields = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (string.IsNullOrEmpty(query))
                throw new InvalidParamException("Query can not be null or empty.");

            var values = new Dictionary<string, string>();
            values.Add("q", query);
            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("messages.searchDialogs", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            var result = new MessagesSearchResponse();
            if (response.Count == 0) return result;

            foreach (JObject el in response)
            {
                var type = (string) el["type"];
                if (type == "profile")
                {
                    User user = Utilities.GetProfileFromJObject(el);
                    result.Users.Add(user);
                    continue;
                }

                if (type == "chat")
                {
                    Chat chat = Utilities.GetChat(el);
                    result.Chats.Add(chat);
                    continue;
                }
            }
            return result;
        }

        public IEnumerable<Message> Search(string query, out int totalCount, int? count = null, int? offset = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (string.IsNullOrEmpty(query))
                throw new InvalidParamException("Query can not be null or empty.");

            var values = new Dictionary<string, string>();
            values.Add("q", query);
            if (count.HasValue && count.Value > 0)
                values.Add("count", count + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset.Value + "");

            string url = _vk.GetApiUrl("messages.search", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            totalCount = (int)response[0];

            var lst = new List<Message>();
            for (int i = 1; i < response.Count; i++)
            {
                var msg = Utilities.GetMessage((JObject)response[i]);
                lst.Add(msg);
            }

            return lst;
        }
        
        public long Send(long id, bool isChat, string message, string title = "", Attachment attch = null, IEnumerable<long> forwardMessagedIds = null, bool fromChat = false, double? latitude = null, double? longitude = null, string guid = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (string.IsNullOrEmpty(message))
                throw new InvalidParamException("Message can not be null.");

            var values = new Dictionary<string, string>();
            values.Add(isChat ? "chat_id" : "uid", id + "");
            values.Add("message", HttpUtility.UrlEncode(message));

            // UNDONE Yet not work with attachments. Fix it later.

            if (forwardMessagedIds != null)
            {
                var ids = forwardMessagedIds.ToList();
                if (ids.Any())
                {
                    values.Add("forward_messages", Utilities.GetEnumerationAsString(ids));
                }
            }

            if (!string.IsNullOrEmpty(title))
                values.Add("title", HttpUtility.UrlEncode(title));

            if (fromChat)
                values.Add("type", "1");

            if (latitude.HasValue && latitude.Value > 0)
                values.Add("lat", latitude.ToString());

            if (longitude.HasValue && longitude.Value > 0)
                values.Add("long", longitude.ToString());
            
            //values.Add("guid", guid ?? Guid.NewGuid().ToString());
            if (!string.IsNullOrEmpty(guid))
                values.Add("guid", HttpUtility.UrlEncode(guid));

            string url = _vk.GetApiUrl("messages.send", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (long)obj["response"];

            return response;
        }

        public bool Delete(long messageId)
        {
            var result =  Delete(new [] {messageId});
            return result[messageId];
        }

        public IDictionary<long, bool> Delete(IEnumerable<long> messageIds)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (messageIds == null)
                throw new InvalidParamException("Param messageIds can not be null.");
            var ids = messageIds.ToList();
            if (ids.Count == 0)
                throw new InvalidParamException("Param messageIds has no one element.");

            var values = new Dictionary<string, string>();
            values.Add("mids", Utilities.GetEnumerationAsString(ids));

            string url = _vk.GetApiUrl("messages.delete", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JObject)obj["response"];

            var dict = new Dictionary<long, bool>();
            foreach (long id in messageIds)
            {
                bool result = (int) response[id.ToString(CultureInfo.InvariantCulture)] == 1;
                dict.Add(id, result);
            }
            
            return dict;
        }

        public void DeleteDialog()
        {
            throw new NotImplementedException();
        }

        public void Restore()
        {
            throw new NotImplementedException();
        }

        public void MarkAsNew()
        {
            throw new NotImplementedException();
        }

        public void MarkAsRead()
        {
            throw new NotImplementedException();
        }

        public void SetActivity()
        {
            throw new NotImplementedException();
        }

        public LastActivity GetLastActivity(long userId)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", userId + "");

            string url = _vk.GetApiUrl("messages.getLastActivity", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JObject)obj["response"];

            var activity = Utilities.GetLastActivity(response);
            activity.UserId = userId;

            return activity;
        }

        public void GetChat()
        {
            throw new NotImplementedException();
        }

        public void CreateChat()
        {
            throw new NotImplementedException();
        }

        public void EditChat()
        {
            throw new NotImplementedException();
        }

        public void GetChatUsers()
        {
            throw new NotImplementedException();
        }

        public void AddChatUser()
        {
            throw new NotImplementedException();
        }

        public void RemoveChatUser()
        {
            throw new NotImplementedException();
        }

        public LongPollServerResponse GetLongPollServer()
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            string url = _vk.GetApiUrl("messages.getLongPollServer", new Dictionary<string, string>());
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = obj["response"];

            var result = new LongPollServerResponse
            {
                Key = (string) response["key"],
                Server = (string) response["server"],
                Ts = (long) response["ts"]
            };

            return result;
        }

        public void GetLongPollHistory()
        {
            throw new NotImplementedException();


        }
    }
}