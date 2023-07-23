using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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
	Instagram
}