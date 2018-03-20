using VkNet.Utils;

namespace VkNet.Exception
{
    using System;
    

    /// <summary>
    /// Исключение, которое выбрасывается в случае, если параметр принимал недействительное значение.
	/// Код ошибки - 120
    /// </summary>
    [Serializable]
    public class InvalidParameterException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        public InvalidParameterException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public InvalidParameterException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public InvalidParameterException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidParameterException(string message, int code, Exception innerException) : base(message, code, innerException)
        {
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response">Ответ от сервера vk</param>
		public InvalidParameterException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
		}
	}
}