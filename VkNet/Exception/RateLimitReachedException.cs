using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <inheritdoc />
	[VkError(VkErrorCode.RateLimitReached)]
	public sealed class RateLimitReachedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public RateLimitReachedException(VkError response) : base(response)
		{
		}
	}
}