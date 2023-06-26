using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Строковая ссылка
/// </summary>
[Serializable]
public class StringLink : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "string";

	/// <summary>
	/// Ссылка
	/// </summary>
	[JsonProperty("link")]
	public string Link { get; set; }

	/// <inheritdoc />
	public override string ToString() => Link;
}