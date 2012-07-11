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

        public IEnumerable<Group> GetGroupsFull()
        {
            IfAccessTokenNotDefinedThrowException();
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetGroupsFull(IEnumerable<int> gids)
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
            string json = _vk.Browser.GetRawHtml(url);

            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(i => new Group {Id = (int) i}).ToList();
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

            string json = _vk.Browser.GetRawHtml(url);
            
            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            return GetProfileFromJObject((JObject)response[0]);
        }

        public IEnumerable<Profile> GetProfiles(IEnumerable<int> uids, ProfileFields fields = null)
        {
            IfAccessTokenNotDefinedThrowException();

            if (uids == null)
                throw new ArgumentNullException("uids");

            var uidsLst = uids.ToList();

            string ids = "";
            for (int i = 0; i < uidsLst.Count; i++)
            {
                ids += uidsLst[i];
                if (i != uidsLst.Count - 1)
                    ids += ",";
            }

            var values = new Dictionary<string, string>();
            values.Add("uids", ids);

            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("getProfiles", values);

            string json = _vk.Browser.GetRawHtml(url);

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

        private Profile GetProfileFromJObject(JObject current)
        {
            var profile = new Profile();
            profile.Uid = (int)current["uid"];
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
        #endregion
    }
}