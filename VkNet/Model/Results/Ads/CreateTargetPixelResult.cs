using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода Ads.CreateTargetPixel
/// </summary>
[Serializable]
public class CreateTargetPixelResult
{
	/// <summary>
	/// Идентификатор пикселя
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Код для размещения на сайте рекламодателя
	/// </summary>
	[JsonProperty("pixel")]
	public string Pixel { get; set; }
}