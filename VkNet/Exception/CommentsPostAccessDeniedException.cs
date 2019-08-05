using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к комментариям записи запрещен.
	/// Код ошибки - 212
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.CommentsPostAccessDenied)]
	public sealed class CommentsPostAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CommentsPostAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}