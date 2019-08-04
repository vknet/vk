using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если комментарии к запрашиваемому видео
	/// закрыты.
	/// Код ошибки - 801
	/// </summary>
	[Serializable]
	public sealed class VideoCommentsClosedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public VideoCommentsClosedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.VideoCommentsClosed;
	}
}