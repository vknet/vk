using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при попытке выполнить запрос с частотой,
	/// превышающей максимально допустимую
	/// ВКонтакте.
	/// В настоящее время действует ограничение (один раз в три секунды) на количество
	/// однотипных запросов (вызовов методов
	/// с одним и тем же именем). Если это ограничение превышается, то сервер ВКонтакте
	/// возвращает ошибку с кодом 6 -
	/// Too many requests per second.
	/// Код ошибки - 6
	/// </summary>
	[Serializable]
	public class TooManyRequestsException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyRequestsException
		/// </summary>
		public TooManyRequestsException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyRequestsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public TooManyRequestsException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyRequestsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public TooManyRequestsException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyRequestsException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public TooManyRequestsException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooManyRequestsException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public TooManyRequestsException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}