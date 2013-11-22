using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class LongPollServerResponse
    {
        public string Key { get; set; }
        public string Server { get; set; }
        public long Ts { get; set; }

        internal static LongPollServerResponse FromJson(VkResponse response)
        {
            var result = new LongPollServerResponse();

            result.Key = response["key"];
            result.Server = response["server"];
            result.Ts = response["ts"];

            return result;
        }
    }
}