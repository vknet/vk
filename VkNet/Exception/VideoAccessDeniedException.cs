using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к видео запрещен.
	/// Код ошибки - 204
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.VideoAccessDenied)]
	public sealed class VideoAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public VideoAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}