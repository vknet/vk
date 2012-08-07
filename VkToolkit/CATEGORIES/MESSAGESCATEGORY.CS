using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkToolkit.Model;

namespace VkToolkit.Categories
{
    public class MessagesCategory
    {
        private readonly VkApi _vk;
        public MessagesCategory(VkApi vk)
        {
            _vk = vk;
        }

        public void Get()
        {
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
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