using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Точки градиента фона опроса.
/// </summary>
[Serializable]
public class PollBackgroundPoint
{
	/// <summary>
	/// Положение точки
	/// </summary>
	[JsonProperty("position")]
	public int Position { get; set; }

	/// <summary>
	/// HEX-код цвета точки
	/// </summary>
	[JsonProperty("color")]
	public string Color { get; set; }
}