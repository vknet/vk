using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при превышении лимита комментариев на стене.
	/// Код ошибки - 224
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.TooManyAdsPosts)]
	public sealed class TooManyAdsPostsException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public TooManyAdsPostsException(VkError response) : base(response)
		{
		}
	}
}