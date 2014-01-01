namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Объект, с помощью которого можно подключиться к серверу быстрых сообщений для мгновенного 
    /// получения приходящих сообщений и других событий.  
    /// См. описание <see cref="http://vk.com/dev/messages.getLongPollServer"/>.
    /// </summary>
    public class LongPollServerResponse
    {
        /// <summary>
        /// Ключ для подключения.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Имя сервера быстрых сообщений.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Отметка времени.
        /// </summary>
        public long Ts { get; set; }

        #region Методы

        internal static LongPollServerResponse FromJson(VkResponse response)
        {
            var longPollServerResponse = new LongPollServerResponse();

            longPollServerResponse.Key = response["key"];
            longPollServerResponse.Server = response["server"];
            longPollServerResponse.Ts = response["ts"];

            return longPollServerResponse;
        }

        #endregion
    }
}