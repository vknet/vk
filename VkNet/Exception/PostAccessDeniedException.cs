﻿using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если доступ к посту запрещен.
/// Код ошибки - 210
/// </summary>
[Serializable]
[VkError(VkErrorCode.PostAccessDenied)]
public sealed class PostAccessDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public PostAccessDeniedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private PostAccessDeniedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}