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
	public string Ts { get; set; }

	/// <summary>
	/// Обновления группы
	/// </summary>
	public List<GroupUpdate> Updates { get; set; }
}