using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если произошла ошибка выполнения кода.
/// Код ошибки - 13
/// </summary>
[Serializable]
[VkError(VkErrorCode.ErrorExecutingCode)]
public sealed class ErrorExecutingCodeException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public ErrorExecutingCodeException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private ErrorExecutingCodeException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}