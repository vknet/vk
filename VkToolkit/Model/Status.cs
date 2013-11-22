using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Status
    {
        public string Text { get; set; }
        public Audio Audio { get; set; }

        internal static Status FromJson(VkResponse status)
        {
            var result = new Status();

            result.Text = status["text"];
            result.Audio = status["audio"];

            return result;
        }
    }
}