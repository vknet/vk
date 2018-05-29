using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при работе с неверным ID.
	/// Убедитесь, что Вы используете верный идентификатор. Получить ID по короткому
	/// имени можно методом
	/// utils.resolveScreenName.
	/// Код ошибки - 113
	/// </summary>
	[Serializable]
	public class InvalidUserIdException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidUserIdException
		/// </summary>
		public InvalidUserIdException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidUserIdException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public InvalidUserIdException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidUserIdException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public InvalidUserIdException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidUserIdException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public InvalidUserIdException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public InvalidUserIdException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}