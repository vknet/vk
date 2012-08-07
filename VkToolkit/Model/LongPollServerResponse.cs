namespace VkToolkit.Model
{
    public class LongPollServerResponse
    {
        public string Key { get; set; }
        public string Server { get; set; }
        public long Ts { get; set; }
    }
}