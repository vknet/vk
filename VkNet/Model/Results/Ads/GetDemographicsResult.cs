using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
///
/// </summary>
[Serializable]
public class GetDemographicsResult
{
	/// <summary>
	/// Идентификатор рекламного кабинета. обязательный параметр, целое число
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("stats")]
	public ReadOnlyCollection<DemographicsStats> Stats { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("type")]
	public IdsType Type { get; set; }
}