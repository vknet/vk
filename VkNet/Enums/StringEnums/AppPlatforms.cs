﻿using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Платформа для которой необходимо вернуть приложения.
/// </summary>
/// <remarks>
/// По умолчанию используется web.
/// </remarks>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum AppPlatforms
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	Ios,

	/// <summary>
	/// По посещаемости
	/// </summary>
	Android,

	/// <summary>
	/// По дате создания приложения
	/// </summary>
	Winphone,

	/// <summary>
	/// По скорости роста
	/// </summary>
	Web
}