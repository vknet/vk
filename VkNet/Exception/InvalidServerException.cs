using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если сервер загрузки неверен.
	/// Код ошибки - 118
	/// </summary>
	[Serializable]
	public class InvalidServerException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidServerException
		/// </summary>
		public InvalidServerException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidServerException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public InvalidServerException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidServerException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public InvalidServerException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidServerException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public InvalidServerException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public InvalidServerException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}