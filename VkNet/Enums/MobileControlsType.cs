namespace VkNet.Enums;

/// <summary>
/// Описывает, как отображаются элементы управления для игр в вебвью в нативных клиентах
/// </summary>
public enum MobileControlsType
{
	/// <summary>
	/// Чёрная полоска над областью с игрой
	/// </summary>
	BlackLine = 0,

	/// <summary>
	/// Прозрачный элемент управления поверх области с игрой;
	/// </summary>
	Transparent = 1,

	/// <summary>
	/// Только для vk apps, без контроллов
	/// </summary>
	WithoutControllers = 2
}