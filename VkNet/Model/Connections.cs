namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Информация о социальных контактах пользователя.
    /// См. описание <see cref="http://vk.com/pages?oid=-1&p=%D0%9E%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5_%D0%BF%D0%BE%D0%BB%D0%B5%D0%B9_%D0%BF%D0%B0%D1%80%D0%B0%D0%BC%D0%B5%D1%82%D1%80%D0%B0_fields"/> 
    /// и <see cref="http://vk.com/dev/fields"/>. Последняя страница обманывает насчет поля 'connections'. 
    /// Экспериментально установлено, что поля находятся непосредственно в полях объекта User.
    /// </summary>
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
        /// Акаунт в twitter.
        /// </summary>
        public string Twitter { get; set; }

        /// <summary>
        /// Акаунт в Instagram.
        /// </summary>
        public string Instagram { get; set; }

        #region Методы

        internal static Connections FromJson(VkResponse response)
        {
            var connections = new Connections();

            connections.Skype = response["skype"];
            connections.FacebookId = Utilities.GetNullableLongId(response["facebook"]);
            connections.FacebookName = response["facebook_name"];
            connections.Twitter = response["twitter"];
            connections.Instagram = response["instagram"];

            return connections;
        }

        #endregion
    }
}