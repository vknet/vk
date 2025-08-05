using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат получения подсказок
/// </summary>
[Serializable]
public class GetSuggestionsResult
{
	/// <summary>
	/// Количество оставшихся методов;
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Время до следующего обновления в секундах.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Время до следующего обновления в секундах.
	/// </summary>
	[JsonProperty("desc")]
	public string Desc { get; set; }

	/// <summary>
	/// Время до следующего обновления в секундах.
	/// </summary>
	[JsonProperty("type")]
	public string Type { get; set; }

	/// <summary>
	/// Время до следующего обновления в секундах.
	/// </summary>
	[JsonProperty("parent")]
	public string Parent { get; set; }
}