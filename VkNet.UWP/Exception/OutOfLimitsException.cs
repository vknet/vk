using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// 103 - Выход за пределы
	/// </summary>
	/// <seealso cref="VkNet.Exception.VkApiException" />
	[DataContract]
    public class OutOfLimitsException : VkApiException
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public OutOfLimitsException(string message) : base(message)
        {
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса NeedValidationException
		/// </summary>
		/// <param name="response">Ответ от сервера vk</param>
		public OutOfLimitsException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
		}
	}
}