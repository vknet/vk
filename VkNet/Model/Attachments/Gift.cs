using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Подарок.
/// </summary>
[Serializable]
public class Gift : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "gift";

	/// <summary>
	/// Изображение 48х48.
	/// </summary>
	[JsonProperty("thumb_48")]
	public Uri Thumb48 { get; set; }

	/// <summary>
	/// Изображение 96х96.
	/// </summary>
	[JsonProperty("thumb_96")]
	public Uri Thumb96 { get; set; }

	/// <summary>
	/// Изображение 256х256.
	/// </summary>
	[JsonProperty("thumb_256")]
	public Uri Thumb256 { get; set; }
}