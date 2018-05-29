using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если количество списков максимально.
	/// Код ошибки - 173
	/// </summary>
	[Serializable]
	public class ListAmountMaximumException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса ListAmountMaximumException
		/// </summary>
		public ListAmountMaximumException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ListAmountMaximumException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public ListAmountMaximumException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ListAmountMaximumException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public ListAmountMaximumException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ListAmountMaximumException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public ListAmountMaximumException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public ListAmountMaximumException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}