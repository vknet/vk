using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если пользователь не найден, удален, либо
	/// заблокирован.
	/// Код ошибки - 18
	/// </summary>
	[Serializable]
	public class UserDeletedOrBannedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса UserDeletedOrBannedException
		/// </summary>
		public UserDeletedOrBannedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UserDeletedOrBannedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public UserDeletedOrBannedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UserDeletedOrBannedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public UserDeletedOrBannedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса UserDeletedOrBannedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public UserDeletedOrBannedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public UserDeletedOrBannedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}