using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Сообщение слишком длинное
/// Код ошибки - 914
/// </summary>
[Serializable]
[VkError(VkErrorCode.MessageIsTooLong)]
public sealed class MessageIsTooLongException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public MessageIsTooLongException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private MessageIsTooLongException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}