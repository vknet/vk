using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit
{
    public class Users
    {
        private readonly VkApi _vk;

        public Users(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Search users by query.
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="itemsCount">Count of users by query.</param>
        /// <param name="fields">Additional fields for retrieving.</param>
        /// <param name="count">Count of records in fetch.</param>
        /// <param name="offset">Offset of records in fetch.</param>
        /// <returns></returns>
        public IEnumerable<Profile> Search(string query, out int itemsCount, ProfileFields fields = null, int count = 20, int offset = 0)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query can not be null or empty.");

            var values = new Dictionary<string, string>();
            values.Add("q", query);
            if (fields != null)
                values.Add("fields", fields.ToString());
            if (offset > 0)
                values.Add("offset", offset + "");
            values.Add("count", count + "");

            string url = _vk.GetApiUrl("users.search", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var array = (JArray)obj["response"];

            itemsCount = (int) array[0];

            var output = new List<Profile>();
            for (int i = 1; i < array.Count; i++)
            {
                Profile p = Utilities.GetProfileFromJObject((JObject)array[i]);
                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Returns the application settings of the current user.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <returns>Returns bitmask settings of the current user in the given application.
        /// 
        /// For example, if the method returns 3, it means that the user allows the application to send them notifications and have access to their list of friends.
        /// </returns>
        public int GetUserSettings(long uid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("getUserSettings", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"];
        }

        /// <summary>
        /// Returns the balance of the current user in the given application in one hundredths of a vote.
        /// </summary>
        /// <returns>Returns the number of votes (in one hundredths) that are on the balance of the current user in an application. </returns>
        public int GetUserBalance()
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            string url = _vk.GetApiUrl("getUserBalance", new Dictionary<string, string>());
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int) obj["response"];
        }

        /// <summary>
        /// Get users' groups.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <returns>List of group Ids</returns>
        public IEnumerable<Group> GetGroups(int uid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("getGroups", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(i => new Group {Id = (int) i}).ToList();
        }

        /// <summary>
        /// Returns information on whether a user has installed an application or not.
        /// </summary>
        /// <param name="uid">User ID</param>
        /// <returns>Returns true if the user has installed the given application, otherwise – false.</returns>
        public bool IsAppUser(long uid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("isAppUser", values);
            string json = _vk.Browser.GetJson(url);

            JObject obj = JObject.Parse(json);
            var res = (string)obj["response"];

            return res == "1";
        }
        
        /// <summary>
        /// Returns standard information about groups of which the current user is a member
        /// </summary>
        /// <returns>Returns standard information about groups of which the current user is a member. </returns>
        public IEnumerable<Group> GetGroupsFull()
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            string url = _vk.GetApiUrl("getGroupsFull", new Dictionary<string, string>());
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(g => Utilities.GetGroupFromJObject((JObject) g)).ToList();
        }

        /// <summary>
        /// Returns standard information about groups from the "gids" list.
        /// </summary>
        /// <param name="gids">List of group IDs</param>
        /// <returns></returns>
        public IEnumerable<Group> GetGroupsFull(IEnumerable<long> gids)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (gids == null)
                throw new ArgumentNullException("gids");
            
            var values = new Dictionary<string, string>();
            values.Add("gids", Utilities.GetEnumerationAsString(gids));

            string url = _vk.GetApiUrl("getGroupsFull", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(g => Utilities.GetGroupFromJObject((JObject)g)).ToList();
        }

        /// <summary>
        /// Get info about user.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <param name="fields">Fields of the profile (can be combined).</param>
        /// <returns>Profile object.</returns>
        public Profile Get(int uid, ProfileFields fields = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");
           
            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("getProfiles", values);

            string json = _vk.Browser.GetJson(url);
            
            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            return Utilities.GetProfileFromJObject((JObject)response[0]);
        }

        /// <summary>
        /// Get info about users.
        /// </summary>
        /// <param name="uids">List of users' Ids.</param>
        /// <param name="fields">Fields of the profile (can be combined).</param>
        /// <returns>List of Profile objects.</returns>
        public IEnumerable<Profile> Get(IEnumerable<long> uids, ProfileFields fields = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (uids == null)
                throw new ArgumentNullException("uids");
            
            var values = new Dictionary<string, string>();
            values.Add("uids", Utilities.GetEnumerationAsString(uids));

            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("getProfiles", values);

            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(p => Utilities.GetProfileFromJObject((JObject) p)).ToList();
        }
    }
}