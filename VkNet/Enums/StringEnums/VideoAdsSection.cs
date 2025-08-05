using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Это перечисление должно указывать на позиции, на которых можно воспроизводить рекламу.
/// </summary>
/// <remarks>
/// Недокументированное перечисление, которое является частью поля разделов в VideoAds.
/// </remarks>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum VideoAdsSection
{
	/// <summary>
	/// Это наверное в начале видео
	/// </summary>
	/// <remarks>
	/// Недокументированная функция
	/// </remarks>
	Preroll,

	/// <summary>
	/// Это наверное середина видео
	/// </summary>
	/// <remarks>
	/// Недокументированная функция
	/// </remarks>
	Midroll,

	/// <summary>
	/// Это наверное конец видео
	/// </summary>
	/// <remarks>
	/// Недокументированная функция
	/// </remarks>
	Postroll
}