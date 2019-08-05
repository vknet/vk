using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке добавить уже добавленное видео.
	/// Код ошибки - 800
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.VideoAlreadyAdded)]
	public sealed class VideoAlreadyAddedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public VideoAlreadyAddedException(VkError response) : base(response)
		{
		}
	}
}