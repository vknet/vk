using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке добавить себя в черный список и
	/// других типичных запросах.
	/// Убедитесь, что Вы используете верные идентификаторы, и доступ к контенту для
	/// текущего пользователя есть в полной
	/// версии сайта.
	/// Код ошибки - 15
	/// </summary>
	[Serializable]
	public class CannotBlacklistYourselfException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса CannotBlacklistYourselfException
		/// </summary>
		public CannotBlacklistYourselfException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotBlacklistYourselfException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public CannotBlacklistYourselfException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotBlacklistYourselfException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public CannotBlacklistYourselfException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotBlacklistYourselfException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public CannotBlacklistYourselfException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public CannotBlacklistYourselfException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}