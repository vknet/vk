using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Приложение.
/// </summary>
[Serializable]
public class Application
{
	/// <summary>
	/// Магазин.
	/// </summary>
	[JsonProperty("store")]
	public Store Store { get; set; }

	/// <summary>
	/// Идентификатор приложения в магазине.
	/// </summary>
	[JsonProperty("app_id")]
	public long? AppId { get; set; }
}