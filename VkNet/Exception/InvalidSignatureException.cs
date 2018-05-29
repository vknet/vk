using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если подпись неверна.
	/// Проверьте правильность формирования подписи запроса:
	/// https://vk.com/dev/api_nohttps
	/// Код ошибки - 4
	/// </summary>
	[Serializable]
	public class InvalidSignatureException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidSignatureException
		/// </summary>
		public InvalidSignatureException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidSignatureException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public InvalidSignatureException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidSignatureException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public InvalidSignatureException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса InvalidSignatureException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public InvalidSignatureException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public InvalidSignatureException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}