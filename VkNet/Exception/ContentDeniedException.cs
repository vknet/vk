using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если контент недоступен
/// Код ошибки - 19
/// </summary>
[Serializable]
[VkError(VkErrorCode.ContentDenied)]
public sealed class ContentDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public ContentDeniedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private ContentDeniedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}