using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке отправить сообщение пользователю,
	/// в связи с настройками приватности.
	/// Код ошибки - 902
	/// </summary>
	[Serializable]
	public class CannotSendDuePrivacyException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса CannotSendDuePrivacyException
		/// </summary>
		public CannotSendDuePrivacyException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotSendDuePrivacyException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public CannotSendDuePrivacyException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotSendDuePrivacyException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public CannotSendDuePrivacyException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CannotSendDuePrivacyException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public CannotSendDuePrivacyException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public CannotSendDuePrivacyException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}