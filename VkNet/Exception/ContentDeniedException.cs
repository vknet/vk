using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если контент недоступен
	/// Код ошибки - 19
	/// </summary>
	[Serializable]
	public sealed class ContentDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ContentDeniedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.ContentDenied;
	}
}