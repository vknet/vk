﻿using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Определяет тип объекта
/// </summary>
[DebuggerDisplay(value: "Id = {Id}, Type = {Type}")]
[Serializable]
[JsonConverter(typeof(VkObjectJsonConverter))]
public class VkObject
{
	/// <summary>
	/// Идентификатор объекта
	/// </summary>
	[JsonProperty("object_id")]
	public long? Id { get; set; }

	/// <summary>
	/// Тип объекта
	/// </summary>
	[JsonProperty("type")]
	[JsonConverter(typeof(StringEnumConverter))]
	public VkObjectType Type { get; set; }
}