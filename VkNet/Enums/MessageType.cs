﻿using System;
using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Тип сообщения.
/// </summary>
[Serializable]
public enum MessageType
{
	/// <summary>
	/// Полученное сообщение.
	/// </summary>
	[DefaultValue]
	Received = 0,

	/// <summary>
	/// Отправленное сообщение.
	/// </summary>
	Sended = 1,
}