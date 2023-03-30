using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Обновление в событиях группы
/// </summary>
[Serializable]
public class BotsLongPollHistoryResponse
{
	/// <summary>
	/// Номер последнего события, начиная с которого нужно получать данные;
	/// </summary>
	[JsonProperty("ts")]
	public string Ts { get; set; }

	/// <summary>
	/// Обновления группы
	/// </summary>
	[JsonConverter(typeof(GroupUpdateJsonConverter))]
	[JsonProperty("updates")]
	public List<GroupUpdate.GroupUpdate> Updates { get; set; }
}