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
	[VkError(VkErrorCode.ConversationAccessDenied)]
	public sealed class ConversationAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ConversationAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}