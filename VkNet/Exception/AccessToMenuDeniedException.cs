using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если доступ к меню запрещен.
/// Код ошибки - 148
/// </summary>
[Serializable]
[VkError(VkErrorCode.AccessToMenuDenied)]
public sealed class AccessToMenuDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public AccessToMenuDeniedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private AccessToMenuDeniedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}