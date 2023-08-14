using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Сервисы
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum Services
{
	/// <summary>
	/// The email
	/// </summary>
	Email,

	/// <summary>
	/// The phone
	/// </summary>
	Phone,

	/// <summary>
	/// The twitter
	/// </summary>
	Twitter,

	/// <summary>
	/// The facebook
	/// </summary>
	Facebook,

	/// <summary>
	/// The odnoklassniki
	/// </summary>
	Odnoklassniki,

	/// <summary>
	/// The instagram
	/// </summary>
	Instagram,

	/// <summary>
	/// The google
	/// </summary>
	Google
}