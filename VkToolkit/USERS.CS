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

        public IEnumerable<Profile> GetProfiles(IEnumerable<int> uids, ProfileFields fields = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetGroups(int uid)
        {
            if (string.IsNullOrEmpty(_vk.AccessToken))
                throw new AccessTokenNotSetException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("getGroups", values);
            string json = _vk.Browser.GetRawHtml(url);

            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray)obj["response"];

            return response.Select(i => new Group {Id = (int) i}).ToList();
        }
        
        public Profile GetProfiles(int uid, ProfileFields fields = null)
        {
            if (string.IsNullOrEmpty(_vk.AccessToken))
                throw new AccessTokenNotSetException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");
           
            if (fields != null)
                values.Add("fields", fields.ToString());

            string url = _vk.GetApiUrl("getProfiles", values);

            string json = _vk.Browser.GetRawHtml(url);
            
            _vk.IfErrorThrowException(json);
            
            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            var profile = new Profile();
            profile.Uid         = (int) response[0]["uid"];
            profile.FirstName   = (string) response[0]["first_name"];
            profile.LastName    = (string) response[0]["last_name"];
            profile.Nickname    = (string) response[0]["nickname"];
            profile.ScreenName  = (string) response[0]["screen_name"];
            profile.Sex         = (int?) response[0]["sex"];
            profile.BirthDate   = (string) response[0]["bdate"];
            profile.City        = (string) response[0]["city"];
            profile.Country     = (string) response[0]["country"];
            profile.Timezone    = (int?) response[0]["timezone"];
            profile.Photo       = (string) response[0]["photo"];
            profile.PhotoMedium = (string) response[0]["photo_medium"];
            profile.PhotoBig    = (string) response[0]["photo_big"];
            profile.HasMobile   = (int?) response[0]["has_mobile"];
            profile.Rate        = (string) response[0]["rate"];
            profile.MobilePhone = (string) response[0]["mobile_phone"];
            profile.HomePhone   = (string) response[0]["home_phone"];
            profile.Online      = (int?) response[0]["online"];

            if (response[0]["university"] != null)
            {
                profile.Education = new Education
                {
                    UniversityId = (string)response[0]["university"],
                    UniversityName = (string)response[0]["university_name"],
                    FacultyId = (string)response[0]["faculty"],
                    FacultyName = (string)response[0]["faculty_name"],
                    Graduation = (string)response[0]["graduation"]
                };
            }

            if (response[0]["counters"] != null)
            {
                var counters = (JObject) response[0]["counters"];

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
    }
}