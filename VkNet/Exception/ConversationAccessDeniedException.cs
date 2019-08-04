using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Нет доступа к беседе
	/// Код ошибки - 917
	/// </summary>
	[Serializable]
	public sealed class ConversationAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ConversationAccessDeniedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.ConversationAccessDenied;
	}
}