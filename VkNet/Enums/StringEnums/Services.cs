using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Сервисы
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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