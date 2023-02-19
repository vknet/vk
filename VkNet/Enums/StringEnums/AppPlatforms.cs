using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Платформа для которой необходимо вернуть приложения.
/// </summary>
/// <remarks>
/// По умолчанию используется web.
/// </remarks>
public enum AppPlatforms
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	[EnumMember(Value = "ios")]
	Ios,

	/// <summary>
	/// По посещаемости
	/// </summary>
	[EnumMember(Value = "android")]
	Android,

	/// <summary>
	/// По дате создания приложения
	/// </summary>
	[EnumMember(Value = "winphone")]
	WinPhone,

	/// <summary>
	/// По скорости роста
	/// </summary>
	[EnumMember(Value = "web")]
	Web
}