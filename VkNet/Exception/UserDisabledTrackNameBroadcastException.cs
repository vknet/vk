using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если пользователь отключил вещание названия
	/// трека.
	/// Код ошибки - 221
	/// </summary>
	[Serializable]
	public sealed class UserDisabledTrackNameBroadcastException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public UserDisabledTrackNameBroadcastException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.UserDisabledTrackNameBroadcast;
	}
}