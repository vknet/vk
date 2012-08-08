using System;
using System.Collections.Generic;
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

        public void GetDialogs()
        {
            throw new NotImplementedException();
        }

        public void GetHistory()
        {
            throw new NotImplementedException();
        }

        public void GetById()
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