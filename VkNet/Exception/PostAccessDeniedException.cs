using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если доступ к посту запрещен.
/// Код ошибки - 210
/// </summary>
[Serializable]
[VkError(VkErrorCode.PostAccessDenied)]
public sealed class PostAccessDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public PostAccessDeniedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private PostAccessDeniedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}