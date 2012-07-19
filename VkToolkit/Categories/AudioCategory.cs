using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    public class AudioCategory
    {
        private readonly VkApi _vk;
        public AudioCategory(VkApi vk)
        {
            _vk = vk;
        }

        public IEnumerable<Audio> GetFromGroup(long gid, long? albumId = null, IEnumerable<long> aids = null,  int? count = null, int? offset = null)
        {
            Profile user;
            return InternalGet("gid", gid, out user, albumId, aids, false, count, offset);
        }

        public IEnumerable<Audio> Get(long uid, out Profile user, long? albumId = null, IEnumerable<long> aids = null,  int? count = null, int? offset = null)
        {
            return InternalGet("uid", uid, out user, albumId, aids, true, count, offset);
        }

        public IEnumerable<Audio> Get(long uid, long? albumId = null, IEnumerable<long> aids = null, int? count = null, int? offset = null)
        {
            Profile user;
            return InternalGet("uid", uid, out user, albumId, aids, false, count, offset);
        }

        private IEnumerable<Audio> InternalGet(string paramId, long id, out Profile user, long? albumId = null, IEnumerable<long> aids = null, bool? needUser = null, int? count = null, int? offset = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add(paramId, id + "");
            if (albumId.HasValue && albumId.Value > 0)
                values.Add("album_id", albumId + "");
            if (aids != null)
                values.Add("aids", Utilities.GetEnumerationAsString(aids));
            if (needUser.HasValue && needUser.Value)
                values.Add("need_user", "1");
            else
                user = null;
            if (count.HasValue && count.Value > 0)
                values.Add("count", count.Value + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset.Value + "");

            string url = _vk.GetApiUrl("audio.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            user = null;
            var output = new List<Audio>();
            foreach (var t in response)
            {
                if (user == null && needUser.HasValue && needUser.Value)
                {
                    user = Utilities.GetProfileFromJObject((JObject) t);
                    continue;
                }
                Audio audio = Utilities.GetAudioFromJObject((JObject) t);
                output.Add(audio);
            }
            return output;
        }

        public IEnumerable<Audio> GetById(IEnumerable<string> audios)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (audios == null)
                throw new InvalidParamException("audios param is null.");

            var values = new Dictionary<string, string>();
            values.Add("audios", Utilities.GetEnumerationAsString(audios));

            string url = _vk.GetApiUrl("audio.getById", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(it => Utilities.GetAudioFromJObject((JObject) it)).ToList();
        }

        public int GetCount(long oid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("oid", oid + "");

            string url = _vk.GetApiUrl("audio.getCount", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (string) obj["response"];

            int count;
            return int.TryParse(response, out count) ? count : 0;
        }

        public Lyrics GetLyrics(long id)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("lyrics_id", id + "");

            string url = _vk.GetApiUrl("audio.getLyrics", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JObject)obj["response"];

            return Utilities.GetLyrics(response);
        }

        public string GetUploadServer()
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            string url = _vk.GetApiUrl("audio.getUploadServer", new Dictionary<string, string>());
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (string)obj["response"]["upload_url"];
        }

        public IEnumerable<Audio> Search(string query, out int totalCount, bool? autoComplete = null, AudioSort? sort = null, bool? findLyrics = null, int? count = null, int? offset = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (string.IsNullOrEmpty(query))
                throw new InvalidParamException("Query is null or empty.");

            var values = new Dictionary<string, string>();
            values.Add("q", query);
            if (autoComplete.HasValue && autoComplete.Value)
                values.Add("auto_complete", "1");
            if (sort.HasValue)
                values.Add("sort", (int)sort + "");
            if (findLyrics.HasValue && findLyrics.Value)
                values.Add("lyrics", "1");
            if (count.HasValue && count.Value > 0)
                values.Add("count", count + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset + "");

            string url = _vk.GetApiUrl("audio.search", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var array = (JArray)obj["response"];

            totalCount = (int) array[0];

            var output = new List<Audio>();
            for (int i = 1; i < array.Count; i++)
            {
                Audio audio = Utilities.GetAudioFromJObject((JObject) array[i]);
                output.Add(audio);

            }
            return output;
        }

        public long Add(long aid, long oid, long? gid = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", aid + "");
            values.Add("oid", oid + "");
            if (gid.HasValue)
                values.Add("gid", gid + "");

            string url = _vk.GetApiUrl("audio.add", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (long)obj["response"];
        }

        public bool Delete(long aid, long oid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", aid + "");
            values.Add("oid", oid + "");

            string url = _vk.GetApiUrl("audio.delete", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }

        public long Edit(long aid, long oid, string artist, string title, string text, bool noSearch = false)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (artist == null)
                throw new InvalidParamException("artist parameter is null.");

            if (title == null)
                throw new InvalidParamException("title parameter is null.");

            if (text == null)
                throw new InvalidParamException("text parameter is null.");

            var values = new Dictionary<string, string>();
            values.Add("aid", aid + "");
            values.Add("oid", oid + "");
            values.Add("artist", artist);
            values.Add("title", title);
            values.Add("text", text);
            values.Add("no_search", noSearch ? "1" : "0");

            string url = _vk.GetApiUrl("audio.edit", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (long) obj["response"];
        }

        public Audio Restore(long audioId, long? ownerId = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", audioId + "");
            if (ownerId.HasValue)
                values.Add("oid",ownerId + "");

            string url = _vk.GetApiUrl("audio.restore", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JObject) obj["response"];

            return Utilities.GetAudioFromJObject(response);
        }

        public bool Reorder(long audioId, long ownerId, long after, long before)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("aid", audioId + "");
            values.Add("oid", ownerId + "");
            values.Add("after", after + "");
            values.Add("before", before + "");

            string url = _vk.GetApiUrl("audio.reorder", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }
    }
}