using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkToolkit.Model;

namespace VkToolkit.Categories
{
    public class StatusCategory
    {
        private readonly VkApi _vk;

        public StatusCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Obtains the status of a user. 
        /// </summary>
        /// <param name="uid">User id</param>
        /// <returns></returns>
        public Status Get(long uid)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            var values = new Dictionary<string, string>();
            values.Add("uid", uid + "");

            string url = _vk.GetApiUrl("status.get", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            var response = obj["response"];

            var status = new Status();
            
            status.Text = (string)response["text"];
            if (response["audio"] != null)
            {
                status.Audio = Utils.Utilities.GetAudioFromJObject((JObject) response["audio"]);
            }
            
            return status;
        }

        /// <summary>
        /// Sets a new status to the current user. 
        /// </summary>
        /// <param name="text">Text status</param>
        /// <param name="audio">Audio status</param>
        /// <returns>True if status has been installed, false otherwise.</returns>
        public bool Set(string text, Audio audio = null)
        {
            _vk.IfAccessTokenNotDefinedThrowException();

            if (text == null)
                throw new ArgumentNullException("text");

            var values = new Dictionary<string, string>();
            if (audio != null)
            {   
                values.Add("audio", string.Format("{0}_{1}", audio.OwnerId, audio.Id));
            }
            else
            {
                values.Add("text", text);
            }

            string url = _vk.GetApiUrl("status.set", values);
            string json = _vk.Browser.GetJson(url);

            _vk.IfErrorThrowException(json);

            JObject obj = JObject.Parse(json);
            return (int)obj["response"] == 1;
        }
    }
}