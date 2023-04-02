using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Чат был отключен
/// Код ошибки - 945
/// </summary>
[Serializable]
[VkError(VkErrorCode.ChatWasDisabled)]
public sealed class ChatWasDisabledException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public ChatWasDisabledException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private ChatWasDisabledException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}