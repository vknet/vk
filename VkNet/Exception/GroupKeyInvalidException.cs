﻿using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <inheritdoc />
/// <summary>
/// Ключ доступа сообщества недействителен.
/// Код ошибки - 27
/// </summary>
[Serializable]
[VkError(VkErrorCode.GroupKeyInvalid)]
public sealed class GroupKeyInvalidException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public GroupKeyInvalidException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private GroupKeyInvalidException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}