using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace VkNet.Enums;

/// <inheritdoc />
[UsedImplicitly]
public enum AdsLinkType
{
	/// <summary>
	/// Сообщество
	/// </summary>
	[EnumMember(Value = "community")]
	Community,

	/// <summary>
	/// Запись в сообществе;
	/// </summary>
	[EnumMember(Value = "post")]
	Post,

	/// <summary>
	/// Приложение ВКонтакте;
	/// </summary>
	[EnumMember(Value = "application")]
	Application,

	/// <summary>
	/// Видеозапись;
	/// </summary>
	[EnumMember(Value = "video")]
	Video,

	/// <summary>
	/// Внешний сайт.
	/// </summary>
	[EnumMember(Value = "site")]
	Site
}