using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Model;
using VkToolkit.Utils;

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
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetById(IEnumerable<long> gids, GroupsFields fields = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("gids", Utilities.GetEnumerationAsString(gids));

            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("groups.getById", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(g => Utilities.GetGroupFromJObject((JObject)g)).ToList();
        }

        public Group GetById(long gid, GroupsFields fields = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("gid", gid + "");

            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("groups.getById", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            return Utilities.GetGroupFromJObject((JObject)obj["response"][0]);
        }

        public IEnumerable<long> GetMembers(long gid, out int itemsCount, int? count = null, int? offset = null, GroupsSort sort = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();


            var values = new Dictionary<string, string>();
            values.Add("gid", gid + "");

            if (count.HasValue && count.Value > 0 && count.Value < 1000)
                values.Add("count", count.Value + "");

            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset + "");

            if (sort != null)
                values.Add("sort", sort.ToString());

            string url = _vk.GetApiUrl("groups.getMembers", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = obj["response"];

            itemsCount = (int)response["count"];

            var ids = (JArray)response["users"];

            return ids.Select(id => (long)id).ToList();
        }

        public void IsMember()
        {
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        public void Search()
        {
            _vk.IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }
    }
}