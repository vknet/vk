﻿using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Слишком много пересланных сообщений
/// Код ошибки - 913
/// </summary>
[VkError(VkErrorCode.TooMuchSentMessages)]
[Serializable]
public sealed class TooMuchSentMessagesException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public TooMuchSentMessagesException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private TooMuchSentMessagesException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}