using System;

namespace VkNet.Model;

/// <summary>
/// Список параметров для метода calls.forceFinish
/// </summary>
[Serializable]
public class CallsForceFinishParams
{
	/// <summary>
	/// Идентификатор звонка
	/// </summary>
	/// <remarks>Обязательный параметр Макс. длина = 36 Мин. длина = 36</remarks>
	public string CallId { get; set; }
}