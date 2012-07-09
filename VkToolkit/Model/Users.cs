using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Exception;

namespace VkToolkit.Model
{
    public class Users
    {
        private readonly VkApi _vk;

        public Users(VkApi vk)
        {
            _vk = vk;
        }
        
        public Profile GetProfiles(int uid, ProfileFields fields = null)
        {
            if (string.IsNullOrEmpty(_vk.AccessToken))
                throw new AccessTokenNotSetException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");
            
            //if (fields != PersonalFields.None)
            //{
            //    values.Add("fields", fields.ToString().Replace(" ", ""));
            //}

            string url = _vk.GetApiUrl("getProfiles", values);

            string json = _vk.Browser.GetRawHtml(url);
            
            // todo parse to json
            // and assign a values

            JObject obj = JObject.Parse(json);
            var response = (JArray) obj["response"];

            // todo check if response is null
            // and later throw new exception

            var profile = new Profile();
            profile.Uid         = (int)    response[0]["uid"];
            profile.FirstName   = (string) response[0]["first_name"];
            profile.LastName    = (string) response[0]["last_name"];

            // todo complete this in next commit
            
            //profile.Nickname = (string) response[0]["nis"];



            return profile;
        }
         
    }
}