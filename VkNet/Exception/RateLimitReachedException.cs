using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <inheritdoc />
	public sealed class RateLimitReachedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public RateLimitReachedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.RateLimitReached;
	}
}