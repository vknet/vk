using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если рекламный пост уже недавно
	/// публиковался.
	/// Код ошибки - 219
	/// </summary>
	[Serializable]
	public sealed class AdsRecentlyPostedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AdsRecentlyPostedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.AdsRecentlyPosted;
	}
}