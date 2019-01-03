using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при отсутствии пользователя в чате.
	/// </summary>
	/// <remarks>
	/// Код ошибки - 935
	/// </remarks>
	[Serializable]
	public class UserNotFoundInChatException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		/// <summary>
		/// Инициализирует новый экземпляр класса UserAuthorizationFailException
		/// </summary>
		public UserNotFoundInChatException(string message) : base(message)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Инициализирует новый экземпляр класса UserAuthorizationFailException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public UserNotFoundInChatException(string message, int code) : base(message, code)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Инициализирует новый экземпляр класса UserAuthorizationFailException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public UserNotFoundInChatException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
		}
	}
}