using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Достигнут количественный лимит на вызов метода
	/// Код ошибки - 29
	/// </summary>
	[VkError(VkErrorCode.RateLimitReached)]
	public sealed class RateLimitReachedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public RateLimitReachedException(VkError response) : base(response)
		{
		}
	}
}