using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Обложка
/// </summary>
[Serializable]
public class Cover
{
	/// <summary>
	/// Размеры
	/// </summary>
	[JsonProperty("sizes")]
	public ReadOnlyCollection<CoverSize> Sizes { get; set; }
}