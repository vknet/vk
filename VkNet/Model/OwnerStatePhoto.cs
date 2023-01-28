using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Фотографии
/// </summary>
[Serializable]
public class OwnerStatePhoto
{
	/// <summary>
	/// Фотография размером 50x50px.
	/// </summary>
	[JsonProperty("photo_50")]
	public Uri Photo50 { get; set; }

	/// <summary>
	/// Фотография размером 100x100px.
	/// </summary>
	[JsonProperty("photo_100")]
	public Uri Photo100 { get; set; }

	/// <summary>
	/// Фотография размером 200x200px.
	/// </summary>
	[JsonProperty("photo_200")]
	public Uri Photo200 { get; set; }

	/// <summary>
	/// Фотография размером 400x400px.
	/// </summary>
	[JsonProperty("photo_400")]
	public Uri Photo400 { get; set; }

	/// <summary>
	/// Фотография размером 1440x960px.
	/// </summary>
	[JsonProperty("photo_1440_960")]
	public Uri Photo1440To960 { get; set; }
}