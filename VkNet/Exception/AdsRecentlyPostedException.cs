﻿using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если рекламный пост уже недавно
/// публиковался.
/// Код ошибки - 219
/// </summary>
[Serializable]
[VkError(VkErrorCode.AdsRecentlyPosted)]
public sealed class AdsRecentlyPostedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public AdsRecentlyPostedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private AdsRecentlyPostedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}