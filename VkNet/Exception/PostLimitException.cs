using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при исчерпании лимита публикации постов в день (не
	/// более 50 в день)
	/// Код ошибки - 214
	/// </summary>
	[Serializable]
	public class PostLimitException : VkApiMethodInvokeException
	{
		/// <summary>
		/// </summary>
		/// <param name="message"> </param>
		public PostLimitException(string message)
				: base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса PostAccessDeniedException
		/// </summary>
		public PostLimitException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса PostAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public PostLimitException(string message, System.Exception innerException) : base(message: message, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса PostAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public PostLimitException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса NeedValidationException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public PostLimitException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}