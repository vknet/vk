using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при исчерпании лимита публикации постов в день (не
	/// более 50 в день)
	/// Код ошибки - 214
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.AccessToAddingPostDenied)]
	public sealed class PostLimitException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public PostLimitException(VkError response) : base(response)
		{
		}
	}
}