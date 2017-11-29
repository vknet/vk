using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, выбрасываемое при исчерпании лимита публикации постов в день (не более 50 в день)
	/// Код ошибки - 214
    /// </summary>
    [Serializable]
    public class PostLimitException : VkApiException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public PostLimitException(string message)
            : base(message)
        {
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса NeedValidationException
		/// </summary>
		/// <param name="response">Ответ от сервера vk</param>
		public PostLimitException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
		}
	}
}