using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// </summary>
	public sealed class TooMuchSentMessagesException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public TooMuchSentMessagesException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.TooMuchSentMessages;
	}
}