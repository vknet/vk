﻿using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при включенном ТЕСТОВОМ приложении, либо если
/// пользователь не вошел в систему.
/// Выключите приложение в настройках https://vk.com/editapp?id={Ваш API_ID}
/// Код ошибки - 11
/// </summary>
[Serializable]
[VkError(VkErrorCode.OffAppOrLogin)]
public sealed class OffAppOrLoginException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public OffAppOrLoginException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private OffAppOrLoginException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}