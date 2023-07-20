namespace VkNet.Enums;

/// <summary>
/// Описывает, как отображаются элементы управления для игр в вебвью в нативных клиентах
/// </summary>
public enum MobileViewSupportType
{
	/// <summary>
	/// Игра не использует нижнюю часть экрана на iPhoneX, черная полоса есть.
	/// </summary>
	BlackLine = 0,

	/// <summary>
	/// Игра использует нижнюю часть экрана на iPhoneX, черной полосы нет.
	/// </summary>
	NotBlackLine = 1
}