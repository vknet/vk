﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Массив объектов UserSpecification
/// </summary>
[Serializable]
public class ClientSpecification
{
	/// <summary>
	/// Общий лимит объявления в рублях. 0 — лимит не задан.
	/// </summary>
	[JsonProperty("all_limit")]
	public long AllLimit { get; set; }

	/// <summary>
	/// Дневной лимит объявления в рублях. 0 — лимит не задан.
	/// </summary>
	[JsonProperty("day_limit")]
	public long DayLimit { get; set; }

	/// <summary>
	/// Название объявления.
	/// </summary>
	[JsonProperty(propertyName: "name")]
	public string Name { get; set; }
}