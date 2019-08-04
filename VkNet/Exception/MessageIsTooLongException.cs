using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// </summary>
	public sealed class MessageIsTooLongException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public MessageIsTooLongException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.MessageIsTooLong;
	}
}