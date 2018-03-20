using System;

using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которые выбрасывается при попытке добавить в друзья пользователя, который занесен в Ваш черный список. 
	/// Код ошибки - 176
    /// </summary>
    [Serializable]
    public class CannotAddUserBlacklistedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddUserBlacklistedException
        /// </summary>
        public CannotAddUserBlacklistedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddUserBlacklistedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public CannotAddUserBlacklistedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddUserBlacklistedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public CannotAddUserBlacklistedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddUserBlacklistedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public CannotAddUserBlacklistedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public CannotAddUserBlacklistedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}