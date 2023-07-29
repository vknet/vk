using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Статистика демографии
/// </summary>
[Serializable]
public class DemographicsStats
{
	/// <summary>
	/// Идентификатор рекламного кабинета. обязательный параметр, целое число
	/// </summary>
	[JsonProperty("day")]
	public string Day { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("month")]
	public string Month { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("overall")]
	public string OverAll { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("sex")]
	public ReadOnlyCollection<StatsSexAgeCities> Sex { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("age")]
	public ReadOnlyCollection<StatsSexAgeCities> Age { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("sex_age")]
	public ReadOnlyCollection<StatsSexAgeCities> SexAge { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("cities")]
	public ReadOnlyCollection<StatsSexAgeCities> Cities { get; set; }
}