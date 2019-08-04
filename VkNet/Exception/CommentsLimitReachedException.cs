using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при превышении лимита комментариев на стене.
	/// Код ошибки - 223
	/// </summary>
	[Serializable]
	public sealed class CommentsLimitReachedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CommentsLimitReachedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.CommentsLimitReached;
	}
}