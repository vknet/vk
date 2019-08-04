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
	public sealed class CommentsWallAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CommentsWallAccessDeniedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.CommentsWallAccessDenied;
	}
}