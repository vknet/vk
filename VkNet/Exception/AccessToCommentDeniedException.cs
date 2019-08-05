using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к комментированию записи
	/// запрещен.
	/// Код ошибки - 213
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.AccessToCommentDenied)]
	public sealed class AccessToCommentDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AccessToCommentDeniedException(VkError response) : base(response)
		{
		}
	}
}