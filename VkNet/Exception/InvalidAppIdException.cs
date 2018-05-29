using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при неверном API ID приложения.
	/// Найдите приложение в списке администрируемых на странице
	/// http://vk.com/apps?act=settings и укажите в запросе верный
	/// API_ID (идентификатор приложения).
	/// Либо используйте стандартный APP_ID для Android: 2890984
	/// Код ошибки - 101
	/// </summary>
	[Serializable]
	public class InvalidAppIdException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidAppIdException
		/// </summary>
		public InvalidAppIdException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidAppIdException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public InvalidAppIdException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidAppIdException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public InvalidAppIdException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidAppIdException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public InvalidAppIdException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public InvalidAppIdException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}