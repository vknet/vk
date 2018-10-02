using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Нет доступа к беседе
	/// Код ошибки - 917
	/// </summary>
	[Serializable]
	public class ConversationAccessDeniedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса ConversationAccessDeniedException
		/// </summary>
		public ConversationAccessDeniedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ConversationAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public ConversationAccessDeniedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ConversationAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public ConversationAccessDeniedException(string message, System.Exception innerException) : base(message: message
			, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса ConversationAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public ConversationAccessDeniedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public ConversationAccessDeniedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}