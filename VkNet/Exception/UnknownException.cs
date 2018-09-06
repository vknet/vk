using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неизвестной ошибке
	/// Попробуйте повторить запрос позже.
	/// Код ошибки - 1
	/// </summary>
	[Serializable]
	public class UnknownException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса UnknownException
		/// </summary>
		public UnknownException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UnknownException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public UnknownException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UnknownException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public UnknownException(string message, System.Exception innerException) : base(message: message, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UnknownException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public UnknownException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public UnknownException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}