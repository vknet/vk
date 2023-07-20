using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если комментарии к запрашиваемому видео
/// закрыты.
/// Код ошибки - 801
/// </summary>
[Serializable]
[VkError(VkErrorCode.VideoCommentsClosed)]
public sealed class VideoCommentsClosedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public VideoCommentsClosedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private VideoCommentsClosedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}