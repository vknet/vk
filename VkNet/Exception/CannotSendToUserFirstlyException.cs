﻿using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при попытке первым написать пользователю от
/// имени группы.
/// Код ошибки - 901
/// </summary>
[Serializable]
[VkError(VkErrorCode.CannotSendToUserFirstly)]
public sealed class CannotSendToUserFirstlyException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public CannotSendToUserFirstlyException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private CannotSendToUserFirstlyException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}