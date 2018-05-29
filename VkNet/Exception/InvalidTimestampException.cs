using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неверном timestamp
	/// Получить актуальное значение Вы можете методом utils.getServerTime.
	/// Код ошибки - 150
	/// </summary>
	[Serializable]
	public class InvalidTimestampException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidTimestampException
		/// </summary>
		public InvalidTimestampException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidTimestampException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public InvalidTimestampException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidTimestampException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public InvalidTimestampException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidTimestampException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public InvalidTimestampException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public InvalidTimestampException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}