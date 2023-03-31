using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается в случае, если параметр принимал
/// недействительное значение.
/// Код ошибки - 120
/// </summary>
[Serializable]
[VkError(VkErrorCode.InvalidParameter)]
public sealed class InvalidParameterException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public InvalidParameterException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private InvalidParameterException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}