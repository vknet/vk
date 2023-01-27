using System;

namespace VkNet.Model;

/// <summary>
/// Статус пользователя.
/// </summary>
[Serializable]
public class OwnerState
{
	/// <summary>
	/// Состояние
	/// </summary>
	public int State { get; set; }

	/// <summary>
	/// Описание
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// Фотографии
	/// </summary>
	public OwnerStatePhoto Photos { get; set; }
}