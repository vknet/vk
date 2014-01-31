using System;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    // TODO: Комментарии
    public class UtilsCategory
    {
        private readonly VkApi _vk;

        public UtilsCategory(VkApi vk)
        {
            _vk = vk;
        }

        public LinkAccessType CheckLink(string url)
        {
            VkErrors.ThrowIfNullOrEmpty(url);

            var parameters = new VkParameters { {"url", url} };

            VkResponse response = _vk.Call("utils.checkLink", parameters, true);
            return response;
        }

        public VkObject ResolveScreenName(string screenName)
        {
            VkErrors.ThrowIfNullOrEmpty(screenName);

            var parameters = new VkParameters {{"screen_name", screenName}};

            VkResponse response = _vk.Call("utils.resolveScreenName", parameters, true);

            if (response == null) return null;
            return response;
        }
        
        public DateTime GetServerTime()
        {
            int ticks = _vk.Call("utils.getServerTime", VkParameters.Empty, true);

            var startUnixTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            startUnixTime = startUnixTime.AddSeconds(ticks).ToLocalTime();
            return startUnixTime;
        }
    }
}