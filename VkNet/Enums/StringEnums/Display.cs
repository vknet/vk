using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Возможные значения параметра display, задающего внешний вид окна авторизации.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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