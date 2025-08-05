using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип платформы
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum Platform
{
	/// <summary>
	/// Android.
	/// </summary>
	Android,

	/// <summary>
	/// iPhone.
	/// </summary>

	// ReSharper disable once InconsistentNaming
	Iphone,

	/// <summary>
	/// Windows Phone
	/// </summary>
	Wphone,

	/// <summary>
	/// AdminApp
	/// </summary>
	AdminApp,

	/// <summary>
	/// Instagram
	/// </summary>
	Instagram,

	/// <summary>
	/// ipad
	/// </summary>
	Ipad
}