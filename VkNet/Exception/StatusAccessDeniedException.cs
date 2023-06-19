using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если доступ к статусу запрещен.
/// Код ошибки - 220
/// </summary>
[Serializable]
[VkError(VkErrorCode.StatusAccessDenied)]
public sealed class StatusAccessDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public StatusAccessDeniedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private StatusAccessDeniedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}