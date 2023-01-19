﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Список доступных размеров аудитории для сохранения.
/// </summary>
[Serializable]
public class SaveAudienceLevels
{
	/// <summary>
	/// Параметра level в ads.saveLookalikeRequestResult
	/// </summary>
	[JsonProperty("level")]
	public long? Level { get; set; }

	/// <summary>
	/// Размер похожей аудитории в данной опции.
	/// </summary>
	[JsonProperty("audience_count")]
	public long? AudienceCount { get; set; }
}