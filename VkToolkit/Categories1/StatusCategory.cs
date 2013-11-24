using System;
using VkToolkit.Model;

namespace VkToolkit.Categories
{
    using VkToolkit.Utils;

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
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("status.get", parameters);
        }

        /// <summary>
        /// Sets a new status to the current user. 
        /// </summary>
        /// <param name="text">Text status</param>
        /// <param name="audio">Audio status</param>
        /// <returns>True if status has been installed, false otherwise.</returns>
        public bool Set(string text, Audio audio = null)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            var parameters = new VkParameters();
            if (audio != null)
                parameters.Add("audio", string.Format("{0}_{1}", audio.OwnerId, audio.Id));
            else
                parameters.Add("text", text);

            return _vk.Call("status.set", parameters);
        }
    }
}