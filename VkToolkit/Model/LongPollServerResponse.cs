using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Объект, с помощью которого можно подключиться к серверу быстрых сообщений для мгновенного 
    /// получения приходящих сообщений и других событий.  
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