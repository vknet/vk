using System;
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
	private StatusAccessDeniedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}