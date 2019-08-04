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
	public sealed class VideoAlreadyAddedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public VideoAlreadyAddedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.VideoAlreadyAdded;
	}
}