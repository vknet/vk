using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit
{
    public class Friends
    {
        private readonly VkApi _vk;

        public Friends(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Returns a list of identifiers of the current user's friends or advanced information about the user's friends (when using the fields parameter).
        /// </summary>
        /// <param name="uid">User id</param>
        /// <param name="fields">Profile fields that are necessary to obtain</param>
        /// <param name="count">Count of records to fetch</param>
        /// <param name="offset">Recors offset</param>
        /// <param name="order">Friends order(only for standalone desktop applications) </param>
        /// <returns>List of users</returns>
        public IEnumerable<Profile> Get(int uid, ProfileFields fields = null, int? count = null, int? offset = null, Order order = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");
            if (fields != null)
                values.Add("fields", fields.ToString());
            if (count.HasValue && count.Value > 0)
                values.Add("count", count.Value + "");
            if (offset.HasValue && offset.Value > 0)
                values.Add("offset", offset.Value + "");
            if (order != null)
                values.Add("order", order.ToString());

            string url = _vk.GetApiUrl("friends.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            if (response.Count > 0 && response[0] is JValue)
            {
                return response.Select(id => new Profile {Uid = (long) id}).ToList();
            }

            return response.Select(p => Utilities.GetProfileFromJObject((JObject) p)).ToList();
        }

        /// <summary>
        /// Returns a list of identifiers of the current user's friends that have installed the given application.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<long> GetAppUsers()
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            string url = _vk.GetApiUrl("friends.getAppUsers", new Dictionary<string, string>());
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var ids = (JArray)obj["response"];

            return ids.Select(id => (long) id).ToList();
        }

        /// <summary>
        /// Get list of ids of the user.
        /// </summary>
        /// <param name="uid">User id</param>
        /// <returns>List of ids.</returns>
        public IEnumerable<long> GetOnline(long uid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("friends.getOnline", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var ids = (JArray)obj["response"];

            return ids.Select(id => (long)id).ToList();

        }

        /// <summary>
        /// Get list of ids of mutual friends for both users.
        /// </summary>
        /// <param name="targetUid">Target user id</param>
        /// <param name="sourceUid">Source user id</param>
        /// <returns></returns>
        public IEnumerable<long> GetMutual(long targetUid, long sourceUid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("target_uid", targetUid + "");
            values.Add("source_uid", sourceUid + "");

            string url = _vk.GetApiUrl("friends.getMutual", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var ids = (JArray)obj["response"];

            return ids.Select(id => (long) id).ToList();
        }

        /// <summary>
        /// Get info about friends status between current user and another users.
        /// </summary>
        /// <param name="uids">List of ids of another users</param>
        /// <returns>Dictionary, key is user id and value is friend status.</returns>
        public IDictionary<long, FriendStatus> AreFriends(IEnumerable<long> uids)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (uids == null)
                throw new ArgumentNullException("uids");

            var values = new Dictionary<string, string>();
            values.Add("uids", Utilities.GetEnumerationAsString(uids));

            string url = _vk.GetApiUrl("friends.areFriends", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var ids = (JArray)obj["response"];

            var output = new Dictionary<long, FriendStatus>();
            foreach (var id in ids)
            {
                FriendStatus status = Utilities.GetFriendStatus((int) id["friend_status"]);
                long userId = (long) id["uid"];

                output.Add(userId, status);
            }

            return output;
        }
    }
}