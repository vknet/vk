using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Возможные значения параметра display, задающего внешний вид окна авторизации.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum Display
{
	/// <summary>
	/// Форма авторизации в отдельном окне;
	/// </summary>
	Page,

	/// <summary>
	/// Всплывающее окно.
	/// </summary>
	Popup,

	/// <summary>
	/// Для мобильных устройств.
	/// </summary>
	Mobile
}