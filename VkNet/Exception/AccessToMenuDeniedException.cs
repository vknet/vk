using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к меню запрещен.
	/// Код ошибки - 148
	/// </summary>
	[Serializable]
	public class AccessToMenuDeniedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса AccessToMenuDeniedException
		/// </summary>
		public AccessToMenuDeniedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessToMenuDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public AccessToMenuDeniedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessToMenuDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public AccessToMenuDeniedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessToMenuDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public AccessToMenuDeniedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public AccessToMenuDeniedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}