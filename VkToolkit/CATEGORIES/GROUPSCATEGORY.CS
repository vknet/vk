using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Exception;
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

        public IEnumerable<Group> Get(long uid, bool extended = false, GroupsFilters filters = null, GroupsFields fields = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");
            values.Add("extended", extended ? "1" : "0");
            if (filters != null)
                values.Add("filter", filters.ToString());
            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("groups.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            if (!extended)
                return response.Select(t => new Group {Id = (int) t}).ToList();

            
            var output = new List<Group>();
            for (int i = 1; i < response.Count; i++)
            {
                Group g = Utilities.GetGroupFromJObject((JObject)response[i]);
                output.Add(g);
            }

            return output;
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

        public bool IsMember(long gid, long uid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("gid", gid + "");
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("groups.isMember", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }

        public IEnumerable<Group> Search(string query, out int totalCount, int? offset = null, int? count = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (string.IsNullOrWhiteSpace(query))
                throw new InvalidParamException("Query can not be null or empty!");

            var values = new Dictionary<string, string>();
            values.Add("q", query);
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset.Value + "");
            if (count.HasValue && count.Value > 0)
                values.Add("count", count.Value + "");

            string url = _vk.GetApiUrl("groups.search", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);

            var array = (JArray) obj["response"];

            totalCount = (int) array[0];

            var output = new List<Group>();
            for (int i = 1; i < array.Count; i++)
            {
                Group g = Utilities.GetGroupFromJObject((JObject) array[i]);
                output.Add(g);
            }
            return output;
                throw new NotImplementedException();
        }

    }
}