using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при отказе в доступе на выполнение операции
/// сервером ВКонтакте.
/// Код ошибки - 500
/// </summary>
[Serializable]
[VkError(VkErrorCode.PermissionDenied)]
public sealed class PermissionDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public PermissionDeniedException(VkError response) : base(response)
	{
	}

	private PermissionDeniedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}