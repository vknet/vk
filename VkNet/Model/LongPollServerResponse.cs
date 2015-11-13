namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Объект, с помощью которого можно подключиться к серверу быстрых сообщений для мгновенного 
    /// получения приходящих сообщений и других событий.  
    /// См. описание <see href="http://vk.com/dev/messages.getLongPollServer"/>.
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
        public ulong Ts { get; set; }

        /// <summary>
        /// Постоянное событие для работы с методом getLongPoolHistory
        /// </summary>
        public ulong? Pts { get; set; }

        #region Методы

        internal static LongPollServerResponse FromJson(VkResponse response)
        {
            var longPollServerResponse = new LongPollServerResponse();

            longPollServerResponse.Key = response["key"];
            longPollServerResponse.Server = response["server"];
            longPollServerResponse.Ts = response["ts"];
            longPollServerResponse.Pts = response["pts"];  

            return longPollServerResponse;
        }

        #endregion
    }
}