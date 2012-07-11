using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Exception;
using VkToolkit.Model;

namespace VkToolkit
{
    public class Users
    {
        private readonly VkApi _vk;

        public Users(VkApi vk)
        {
            _vk = vk;
        }

        public bool IsAppUser(string uid)
        {
            IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }
        
        public IEnumerable<Profile> Search(string query, int count = 20, ProfileFields fields = null)
        {
            IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the application settings of the current user.
        /// </summary>
        /// <returns>Returns bitmask settings of the current user in the given application.
        /// 
        /// For example, if the method returns 3, it means that the user allows the application to send them notifications and have access to their list of friends.
        /// </returns>
        public int GetUserSettings()
        {
            IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the balance of the current user in the given application in one hundredths of a vote.
        /// </summary>
        /// <returns>Returns the number of votes (in one hundredths) that are on the balance of the current user in an application. </returns>
        public int GetUserBalance()
        {
            IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get users' groups.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <returns>List of group Ids</returns>
        public IEnumerable<Group> GetGroups(int uid)
        {
            IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("getGroups", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(i => new Group {Id = (int) i}).ToList();
        }

        public IEnumerable<Group> GetGroupsFull()
        {
            IfAccessTokenNotDefinedThrowException();

            string url = _vk.GetApiUrl("getGroupsFull", new Dictionary<string, string>());
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(g => GetGroupFromJObject((JObject) g)).ToList();
        }

        public IEnumerable<Group> GetGroupsFull(IEnumerable<long> gids)
        {
            IfAccessTokenNotDefinedThrowException();

            if (gids == null)
                throw new ArgumentNullException("gids");
            
            var values = new Dictionary<string, string>();
            values.Add("gids", GetEnumerationAsString(gids));

            string url = _vk.GetApiUrl("getGroupsFull", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(g => GetGroupFromJObject((JObject)g)).ToList();
        }

        /// <summary>
        /// Get info about user.
        /// </summary>
        /// <param name="uid">User Id</param>
        /// <param name="fields">Fields of the profile (can be combined).</param>
        /// <returns>Profile object.</returns>
        public Profile GetProfiles(int uid, ProfileFields fields = null)
        {
            IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");
           
            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("getProfiles", values);

            string json = _vk.Browser.GetJson(url);
            
            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            return GetProfileFromJObject((JObject)response[0]);
        }

        /// <summary>
        /// Get info about users.
        /// </summary>
        /// <param name="uids">List of users' Ids.</param>
        /// <param name="fields">Fields of the profile (can be combined).</param>
        /// <returns>List of Profile objects.</returns>
        public IEnumerable<Profile> GetProfiles(IEnumerable<long> uids, ProfileFields fields = null)
        {
            IfAccessTokenNotDefinedThrowException();

            if (uids == null)
                throw new ArgumentNullException("uids");
            
            var values = new Dictionary<string, string>();
            values.Add("uids", GetEnumerationAsString(uids));

            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("getProfiles", values);

            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            var output = new List<Profile>();

            foreach (var p in response)
            {
                var pro = GetProfileFromJObject((JObject) p);
                output.Add(pro);
            }
            return output;
        }

        #region Private Methods

        private string GetEnumerationAsString(IEnumerable<long> uids)
        {
            var uidsLst = uids.ToList();
            string ids = "";
            for (int i = 0; i < uidsLst.Count; i++)
            {
                ids += uidsLst[i];
                if (i != uidsLst.Count - 1)
                    ids += ",";
            }

            return ids;
        }

        private Group GetGroupFromJObject(JObject group)
        {
            var output = new Group
            {
                Id = (long) group["gid"],
                Name = (string)group["name"],
                Link = (string)group["link"],
                Photo = (string)group["photo"],
                PhotoMedium = (string)group["photo_medium"],
                PhotoBig = (string)group["photo_big"],
                ScreenName = (string)group["screen_name"],
            };

            var isClosed = (int?)group["is_closed"];
            var isAdmin = (int?)group["is_admin"];

            if (isClosed.HasValue)
            {
                output.IsClosed = isClosed.Value == 1;
            }

            if (isAdmin.HasValue)
            {
                output.IsAdmin = isAdmin.Value == 1;
            }
            else
                output.IsAdmin = false;

            output.Type = GetGroupType((string)group["type"]);

            return output;
        }

        private Profile GetProfileFromJObject(JObject current)
        {
            var profile = new Profile();
            profile.Uid = (long)current["uid"];
            profile.FirstName = (string)current["first_name"];
            profile.LastName = (string)current["last_name"];
            profile.Nickname = (string)current["nickname"];
            profile.ScreenName = (string)current["screen_name"];
            profile.Sex = (int?)current["sex"];
            profile.BirthDate = (string)current["bdate"];
            profile.City = (string)current["city"];
            profile.Country = (string)current["country"];
            profile.Timezone = (int?)current["timezone"];
            profile.Photo = (string)current["photo"];
            profile.PhotoMedium = (string)current["photo_medium"];
            profile.PhotoBig = (string)current["photo_big"];
            profile.HasMobile = (int?)current["has_mobile"];
            profile.Rate = (string)current["rate"];
            profile.MobilePhone = (string)current["mobile_phone"];
            profile.HomePhone = (string)current["home_phone"];
            profile.Online = (int?)current["online"];

            if (current["university"] != null)
            {
                profile.Education = new Education
                {
                    UniversityId = (string)current["university"],
                    UniversityName = (string)current["university_name"],
                    FacultyId = (string)current["faculty"],
                    FacultyName = (string)current["faculty_name"],
                    Graduation = (string)current["graduation"]
                };
            }

            if (current["counters"] != null)
            {
                var counters = (JObject)current["counters"];

                profile.Counters = new Counters
                {
                    Albums = (int)counters["albums"],
                    Videos = (int)counters["videos"],
                    Audios = (int)counters["audios"],
                    Notes = (int)counters["notes"],
                    Photos = (int)counters["photos"],
                    Groups = (int)counters["groups"],
                    Friends = (int)counters["friends"],
                    OnlineFriends = (int)counters["online_friends"],
                    UserPhotos = (int)counters["user_photos"],
                    UserVideos = (int)counters["user_videos"],
                    Followers = (int)counters["followers"],
                    Subscriptions = (int)counters["subscriptions"]
                };
            }

            return profile;
        }

        private void IfAccessTokenNotDefinedThrowException()
        {
            if (string.IsNullOrEmpty(_vk.AccessToken))
                throw new AccessTokenNotSetException();
        }

        internal GroupType GetGroupType(string type)
        {
            switch (type)
            {
                case "page":
                    return GroupType.Page;

                case "event":
                    return GroupType.Event;

                case "group":
                    return GroupType.Group;

                default:
                    return GroupType.Undefined;
            }
        }
        #endregion
    }
}