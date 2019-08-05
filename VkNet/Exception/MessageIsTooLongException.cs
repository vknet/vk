using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.MessageIsTooLong)]
	public sealed class MessageIsTooLongException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public MessageIsTooLongException(VkError response) : base(response)
		{
		}
	}
}