namespace VkNet.Model.Attachments
{
    public class StringLink: MediaAttachment
    {
        static StringLink()
        {
            RegisterType(typeof(string), "string");
        }

        public string Link { get; set; }

        public override string ToString()
        {
            return Link;
        }
    }
}