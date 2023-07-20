using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода downloadedGames.getPaidStatus
/// </summary>
[Serializable]
public class GetPaidStatusResult
{
	/// <summary>
	/// Оплачено пользователем
	/// </summary>
	[JsonProperty("is_paid")]
	public bool IsPaid { get; set; }
}