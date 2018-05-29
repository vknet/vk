using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при отказе в доступе на выполнение операции
	/// сервером ВКонтакте.
	/// Код ошибки - 500
	/// </summary>
	[Serializable]
	public class AccessDeniedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса AccessDeniedException
		/// </summary>
		public AccessDeniedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public AccessDeniedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public AccessDeniedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public AccessDeniedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public AccessDeniedException(string message, int code, System.Exception innerException) : base(message: message
				, code: code
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessDeniedException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public AccessDeniedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}