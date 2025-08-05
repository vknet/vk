using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат получения информации о причинах отказа
/// </summary>
[Serializable]
public class GetRejectionReasonResult
{
	/// <summary>
	/// Количество оставшихся методов;
	/// </summary>
	[JsonProperty("comment")]
	public string Comment { get; set; }

	/// <summary>
	/// Время до следующего обновления в секундах.
	/// </summary>
	[JsonProperty("rules")]
	public ReadOnlyCollection<RejectionRules> Rules { get; set; }
}