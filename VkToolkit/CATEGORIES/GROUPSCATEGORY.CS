using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VkToolkit.Categories
{
    public class GroupsCategory
    {
        private readonly VkApi _vk;

        public GroupsCategory(VkApi vk)
        {
            _vk = vk;
        }

        public bool Join(long gid, bool notSure = false)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("gid", gid + "");
            values.Add("not_sure", notSure ? "1" : "0");

            string url = _vk.GetApiUrl("groups.join", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }

        public bool Leave(long gid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("gid", gid + "");

            string url = _vk.GetApiUrl("groups.leave", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void GetById()
        {
            throw new NotImplementedException();
        }

        public void IsMember()
        {
            throw new NotImplementedException();
        }

        public void GetMembers()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}