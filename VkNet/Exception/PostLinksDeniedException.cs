using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке разместить ссылку.
	/// Код ошибки - 222
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.PostLinksDenied)]
	public sealed class PostLinksDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public PostLinksDeniedException(VkError response) : base(response)
		{
		}
	}
}