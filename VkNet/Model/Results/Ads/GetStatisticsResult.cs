﻿using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Результат получения статистики
/// </summary>
[Serializable]
public class GetStatisticsResult
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
	public ReadOnlyCollection<StatisticsStats> Stats { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("type")]
	public IdsType? Type { get; set; }
}