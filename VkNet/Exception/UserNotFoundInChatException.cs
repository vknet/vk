using System;
using VkNet.Model;
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
	public sealed class UserNotFoundInChatException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public UserNotFoundInChatException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.UserNotFoundInChat;
	}
}