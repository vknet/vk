using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// </summary>
	public class MessageIsTooLongException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса MessageIsTooLongException
		/// </summary>
		public MessageIsTooLongException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса MessageIsTooLongException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public MessageIsTooLongException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса MessageIsTooLongException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public MessageIsTooLongException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса MessageIsTooLongException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public MessageIsTooLongException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public MessageIsTooLongException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}