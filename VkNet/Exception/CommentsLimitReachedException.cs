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
	[VkError(VkErrorCode.CommentsLimitReached)]
	public sealed class CommentsLimitReachedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CommentsLimitReachedException(VkError response) : base(response)
		{
		}
	}
}