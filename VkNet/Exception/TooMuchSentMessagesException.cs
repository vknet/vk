using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// </summary>
	[VkError(VkErrorCode.TooMuchSentMessages)]
	public sealed class TooMuchSentMessagesException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public TooMuchSentMessagesException(VkError response) : base(response)
		{
		}
	}
}