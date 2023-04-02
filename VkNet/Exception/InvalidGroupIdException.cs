using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если идентификатор сообщества неверен.
/// Код ошибки - 125
/// </summary>
[Serializable]
[VkError(VkErrorCode.InvalidGroupId)]
public sealed class InvalidGroupIdException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public InvalidGroupIdException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private InvalidGroupIdException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}