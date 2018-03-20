using System;
using VkNet.Utils;

namespace VkNet.Exception
{
    

    /// <summary>
    /// Исключение, которое выбрасывается при отсутствии авторизации на выполнение запрошенной операции.
	/// Код ошибки - 5
    /// </summary>
    [Serializable]
    public class UserAuthorizationFailException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса UserAuthorizationFailException
        /// </summary>
        public UserAuthorizationFailException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UserAuthorizationFailException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public UserAuthorizationFailException(string message, int code) : base(message, code)
        {
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UserAuthorizationFailException
		/// </summary>
		/// <param name="response">Ответ от сервера vk</param>
		public UserAuthorizationFailException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
		}
	}
}