using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип приложения.
/// </summary>
public class AppType : SafetyEnum<AppType>
{
	/// <summary>
	/// Социальное приложение;
	/// </summary>
	[EnumMember(Value = "app")]
	public static readonly AppType App = RegisterPossibleValue("app");

	/// <summary>
	/// Игра;
	/// </summary>
	[EnumMember(Value = "game")]
	public static readonly AppType Game = RegisterPossibleValue("game");

	/// <summary>
	/// Подключаемый сайт;
	/// </summary>
	[EnumMember(Value = "site")]
	public static readonly AppType Site = RegisterPossibleValue("site");

	/// <summary>
	/// Отдельное приложение (для мобильного устройства).
	/// </summary>
	[EnumMember(Value = "standalone")]
	public static readonly AppType Standalone = RegisterPossibleValue("standalone");

	/// <summary>
	/// VK App приложение
	/// </summary>
	[EnumMember(Value = "vk_app")]
	public static readonly AppType VkApp = RegisterPossibleValue("vk_app");

	/// <summary>
	/// VK App приложение
	/// </summary>
	[EnumMember(Value = "community_app")]
	public static readonly AppType CommunityApp = RegisterPossibleValue("community_app");

	/// <summary>
	/// HTML5 игра
	/// </summary>
	[EnumMember(Value = "html5_game")]
	public static readonly AppType Html5Game = RegisterPossibleValue("html5_game");
}