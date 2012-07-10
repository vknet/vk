using System;
using System.Collections.Generic;
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
            
            if (string.CompareOrdinal(json.Substring(2, 5), "error") == 0)
            {
                _vk.ThrowExceptionOnServerError(json);
            }

            // todo parse to json
            // and assign a values

            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            var profile = new Profile();
            profile.Uid         = (int)    response[0]["uid"];
            profile.FirstName   = (string) response[0]["first_name"];
            profile.LastName    = (string) response[0]["last_name"];

            if (response[0]["university"] != null)
            {
                profile.Education = new Education
                {
                    Id = (string)response[0]["university"],
                    Name = (string)response[0]["university_name"],
                    FacultyId = (string)response[0]["faculty"],
                    FacultyName = (string)response[0]["faculty_name"],
                    Graduation = (string)response[0]["graduation"]
                };
            }
            
            //profile.Nickname = (string) response[0]["nis"];



            return profile;
        }
         
    }
}