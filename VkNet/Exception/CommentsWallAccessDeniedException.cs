using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к комментариям на стене
	/// запрещен.
	/// Код ошибки - 211
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.CommentsWallAccessDenied)]
	public sealed class CommentsWallAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CommentsWallAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}