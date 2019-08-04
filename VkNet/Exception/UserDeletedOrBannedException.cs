using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если пользователь не найден, удален, либо
	/// заблокирован.
	/// Код ошибки - 18
	/// </summary>
	[Serializable]
	public sealed class UserDeletedOrBannedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public UserDeletedOrBannedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.UserDeletedOrBanned;
	}
}