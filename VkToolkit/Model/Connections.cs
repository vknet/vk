namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    public class Connections
    {
        /// <summary>
        /// Логин в Skype.
        /// </summary>
        public string Skype { get; set; }
        /// <summary>
        /// Идентификатор акаунта в Facebook.
        /// </summary>
        public long? FacebookId { get; set; }
        /// <summary>
        /// Имя и фамилия в facebook.
        /// </summary>
        public string FacebookName { get; set; }
        /// <summary>
        /// Фкаунт в twitter.
        /// </summary>
        public string Twitter { get; set; }
        /// <summary>
        /// Акаунт в Instagram.
        /// </summary>
        public string Instagram { get; set; }

        internal static Connections FromJson(VkResponse connections)
        {
            var result = new Connections();

            result.Skype = connections["skype"];
            result.FacebookId = connections["facebook"];
            result.FacebookName = connections["facebook_name"];
            result.Twitter = connections["twitter"];
            result.Instagram = connections["instagram"];

            return result;
        }
    }
}