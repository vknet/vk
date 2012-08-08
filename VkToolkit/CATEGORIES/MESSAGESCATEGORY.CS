using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enums;
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

            return GetById(new long[] {messageId}, out totalCount, previewLength).FirstOrDefault();
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

        public void GetDialogs()
        {
            throw new NotImplementedException();
        }

        public void SearchDialogs()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        public void Send()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
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

        public void GetLastActivity()
        {
            throw new NotImplementedException();
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