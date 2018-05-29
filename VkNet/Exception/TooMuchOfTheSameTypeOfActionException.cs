using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при превышении лимита однотипных действий
	/// Нужно сократить число однотипных обращений. Для более эффективной работы Вы
	/// можете использовать execute или JSONP.
	/// Код ошибки - 9
	/// </summary>
	[Serializable]
	public class TooMuchOfTheSameTypeOfActionException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса TooMuchOfTheSameTypeOfActionException
		/// </summary>
		public TooMuchOfTheSameTypeOfActionException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooMuchOfTheSameTypeOfActionException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public TooMuchOfTheSameTypeOfActionException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooMuchOfTheSameTypeOfActionException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public TooMuchOfTheSameTypeOfActionException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса TooMuchOfTheSameTypeOfActionException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public TooMuchOfTheSameTypeOfActionException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public TooMuchOfTheSameTypeOfActionException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}